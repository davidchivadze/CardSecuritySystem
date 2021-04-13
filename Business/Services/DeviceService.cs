using Business.DeviceClient;
using Business.Interface;
using Core.Helper;
using Core.Helpers;
using Models.DeviceResponseModels;
using Models.ViewModels.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using zkemkeeper;

namespace Business.Services
{
    public class DeviceService : BaseService, IDeviceService
    {
        private IZKEM _deviceClient;
        
        public DeviceService()
        {
            this._deviceClient = this._deviceClient ?? new ZkemClient();
        }
        public IResponse<DateTime> GetDeviceDateTime()
        {
            this._deviceClient.Connect_Net("192.168.1.201", 4370);
            int machineNumber = int.Parse("1");
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;
            bool result = _deviceClient.GetDeviceTime(machineNumber, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref dwSecond);

            DateTime deviceTime = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond);
            return Ok(deviceTime);
        }



        public IResponse<bool> AddDevice(AddDeviceRequest model)
        {
            try {
                var pingDevice = PingTheDevice(model.IPAddress);
                if (!pingDevice)
                {
                    throw new Exception("მოწყობილობა მისამართზე '" + model.IPAddress + "' ვერ მოიძებნა");
                }
            var result = UnitOfWork.DeviceRepository.AddDevice(model.AsDatabaseModel());
            if (result != null)
            {
                return Ok(true);
            }
            else
            {
                return Fail<bool>("მოწყობილობის დამატება ვერ მოხერხდა");
            }
            }catch(Exception ex)
            {
                return Fail<bool>(ex.Message);
            }
        }
        public IResponse<GetDeviceListResponse> GetDeviceList()
        {
            try {
            var result1 = UnitOfWork.DeviceRepository.GetDevices().ToList();
            var result = UnitOfWork.DeviceRepository.GetDevices().Where(m=>m.IsActive==true).Select(m => m.AsViewModel()).ToList();
            return Ok(new GetDeviceListResponse() { DeviceList = result });
            }catch(Exception ex)
            {
                return Fail<GetDeviceListResponse>(ex.Message);
            }
        }
        public static bool PingTheDevice(string ipAdd)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ipAdd);

                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;

                // Create a buffer of 32 bytes of data to be transmitted. 
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                PingReply reply = pingSender.Send(ipAddress, timeout, buffer, options);

                if (reply.Status == IPStatus.Success)
                    return true;
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IResponse<bool>> SyncUserLog()
        {
            var machineList = this.GetUserLogList();
            if (machineList != null && machineList.Count > 0)
            {
                var result = UnitOfWork.DeviceUserLogRepository.AddLogList(machineList.Select(m => m.AsDatabaseModel()).ToList());
                if (result) { 
                return Ok(true);
                }
                else
                {
                    throw new Exception("ვერ მოხერხდა მონაცემების ბაზაში ასახვა");
                }
            }
            return Fail<bool>("deendzra");
        }
        
        public async Task<IResponse<bool>> UpdateUserListFromDevice()
        {
            try { 
            var userListInDevice = GetUsersListFromDevice();
            if (userListInDevice != null && userListInDevice.Count > 0)
            {
                var result = UnitOfWork.DeviceRegistratedUsersRepository.AddDeviceRegistratedUsersList(userListInDevice.Select(m => m.AsDatabaseModel()).ToList());
                if (result)
                {
                    return Ok(true);
                }
                    return Fail<bool>("ვერ მოხერხდა მონაცემების დამატება ბაზაში");
                }
                else
                {
                    return Fail<bool>("აპარატში ჩანაწერები ვერ მოიძებნა");
                }
            }catch(Exception ex)
            {
                return Fail<bool>(ex.Message);
            }
        }

        public IResponse<bool> ClearDeviceData()
        {
            try
            {
                _deviceClient.Connect_Net("192.168.1.201", 4370);
                int iMachineNumber = 1;
                _deviceClient.ClearGLog(iMachineNumber);
                return Ok(true);
            }catch(Exception ex)
            {
                return Fail<bool>(ex.Message);
            }
        }

        private ICollection<DeviceUserLog> GetUserLogList()
        {
            var Devices = UnitOfWork.DeviceRepository.GetAll().Where(m => m.IsActive == true).FirstOrDefault();
            string dwEnrollNumber1 = "";
            int dwVerifyMode = 0;
            int dwInOutMode = 0;
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;
            int dwWorkCode = 0;

            ICollection<DeviceUserLog> lstEnrollData = new List<DeviceUserLog>();
            _deviceClient.Connect_Net(Devices.IPAddress, int.Parse(Devices.Port));
            for (var i=1;i<=Devices.NumberDevices;i++) {
              
            _deviceClient.ReadAllGLogData(i);

            while (_deviceClient.SSR_GetGeneralLogData(i, out dwEnrollNumber1, out dwVerifyMode, out dwInOutMode, out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkCode))


            {
                string inputDate = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond).ToString();

                    DeviceUserLog objInfo = new DeviceUserLog();
                objInfo.MachineNumber = i;
                objInfo.IndRegID = int.Parse(dwEnrollNumber1);
                objInfo.dwVerifyMode = dwVerifyMode;
                objInfo.dwInOutMode = dwInOutMode;
                objInfo.DateTimeRecord = inputDate;

                lstEnrollData.Add(objInfo);
            }
                _deviceClient.ClearGLog(i);
            }
            
            return lstEnrollData;
        }

        
        private ICollection<UserInfo> GetUsersListFromDevice()
        {
            var Devices = UnitOfWork.DeviceRepository.GetAll().Where(m => m.IsActive == true).FirstOrDefault();

            string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty, sTmpData = string.Empty;
            int iPrivilege = 0, iTmpLength = 0, iFlag = 0, idwFingerIndex;
            bool bEnabled = false;

            ICollection<UserInfo> lstFPTemplates = new List<UserInfo>();

            // objZkeeper.ReadAllUserID(machineNumber);
            //objZkeeper.ReadAllTemplate(machineNumber);
            _deviceClient.Connect_Net(Devices.IPAddress, int.Parse(Devices.Port));
            for (var i = 1; i <= Devices.NumberDevices; i++)
            {
                while (_deviceClient.SSR_GetAllUserInfo(i, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
                {
                    UserInfo fpInfo = new UserInfo();
                    fpInfo.FingerIndex = 0;
                    for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                    {
                        if (_deviceClient.GetUserTmpExStr(i, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
                        {
                            fpInfo = new UserInfo();
                            fpInfo.MachineNumber = i;
                            fpInfo.EnrollNumber = sdwEnrollNumber;
                            fpInfo.Name = sName;
                            fpInfo.FingerIndex += 1; //idwFingerIndex;
                            fpInfo.TmpData = sTmpData;
                            fpInfo.Privelage = iPrivilege;
                            fpInfo.Password = sPassword;
                            fpInfo.Enabled = bEnabled;
                            fpInfo.iFlag = iFlag.ToString();
                        }
                    }
                    lstFPTemplates.Add(fpInfo);

                }
            }
                return lstFPTemplates;
        }
        private bool InsertUserInDevice(int userID)
        {
            try { 
            var userFromDb = UnitOfWork.EmployeeRepository.GetAll().Where(m => m.ID == userID).FirstOrDefault();
                if (userFromDb != null)
                {
                    if (userFromDb.UserIDInDevice == null)
                    {
                        var deviceList = UnitOfWork.DeviceRepository.GetDevices().Where(m => m.IsActive).ToList();
                        foreach(var device in deviceList) {
                            if (this.SetStrCardNumber(device.IPAddress, int.Parse(device.Port), true, userFromDb.ID.ToString() + userFromDb.ID.ToString(), userFromDb.PersonalNumber, this.RandomDigits(6), 1, userFromDb.DeviceCardID)) {
                                UnitOfWork.EmployeeRepository.UpdateEmployeeSyncData(int.Parse(userFromDb.ID.ToString() + userFromDb.ID.ToString()), userFromDb.ID);
                            };

                                }
                        return true;
                    }
                    else
                    {
                        throw new Exception("თანამშრომელი უკვე დამატებულია მოწყობილობაში");
                    }
            }
                else
                {
                    throw new Exception("თანამშრომელი ვერ მოიძებნა");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public bool SetStrCardNumber(string sIp = "192.168.1.201", int iPort = 4370,
                                    bool bEnabled = true, string sdwEnrollNumber = "6969",
                                    string sName = "MVC Datoie", string sPassword = "123456",
                                    int iPrivilege = 0, string sCardnumber = "0"
)
        {
            //Create Standalone SDK class dynamicly.
            _deviceClient.Connect_Net(sIp, iPort);
            int iMachineNumber = 1;
            //axCZKEM1.Connect_Net(sIp, iPort);

            int idwErrorCode = 0;

            _deviceClient.EnableDevice(iMachineNumber, false);
            _deviceClient.SetStrCardNumber(sCardnumber);//Before you using function SetUserInfo,set the card number to make sure you can upload it to the device
            if (_deviceClient.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload the user's information(card number included)
            {

                _deviceClient.RefreshData(iMachineNumber);//the data in the device should be refreshed
                _deviceClient.EnableDevice(iMachineNumber, true);
                return true;
                
            }
            else
            {
                _deviceClient.GetLastError(ref idwErrorCode);
                throw new Exception("ვერ მოხერხდა ჩამატება: " + idwErrorCode.ToString());
            }

        }
        public ICollection<UserInfo> GetAllUserInfo(IZKEM objZkeeper, int machineNumber)
        {
            string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty, sTmpData = string.Empty;
            int iPrivilege = 0, iTmpLength = 0, iFlag = 0, idwFingerIndex;
            bool bEnabled = false;

            ICollection<UserInfo> lstFPTemplates = new List<UserInfo>();

            // objZkeeper.ReadAllUserID(machineNumber);
            //objZkeeper.ReadAllTemplate(machineNumber);

            while (objZkeeper.SSR_GetAllUserInfo(machineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
            {
                UserInfo fpInfo = new UserInfo();
                fpInfo.FingerIndex = 0;
                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (objZkeeper.GetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
                    {
                        fpInfo = new UserInfo();
                        fpInfo.MachineNumber = machineNumber;
                        fpInfo.EnrollNumber = sdwEnrollNumber;
                        fpInfo.Name = sName;
                        fpInfo.FingerIndex += 1; //idwFingerIndex;
                        fpInfo.TmpData = sTmpData;
                        fpInfo.Privelage = iPrivilege;
                        fpInfo.Password = sPassword;
                        fpInfo.Enabled = bEnabled;
                        fpInfo.iFlag = iFlag.ToString();
                    }
                }
                lstFPTemplates.Add(fpInfo);

            }
            return lstFPTemplates;
        }
        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        public IResponse<bool> InsertUserToDevice(int UserID)
        {
            try { 
            if (this.InsertUserInDevice(UserID))
            {
                return Ok(true);
            }
            else
            {
                return Fail<bool>("ვერ მოხერხდა თანამშრომლის ჩამატება მოწყობილობაში");
            }
            }catch(Exception ex)
            {
                return Fail<bool>(ex.Message);
            }
        }

        public IResponse<GetDeviceUserLogResponse> GetDeviceUserLogList()
        {
            try
            {
                var result = UnitOfWork.DeviceUserLogRepository.GetDeviceUserLogs()?.Where(m=>m.IsActive==true).Select(m => m.AsViewModel()).ToList();
                return Ok(new GetDeviceUserLogResponse()
                {
                    DeviceUserLogList = result
                });
            }catch(Exception ex)
            {
                return Fail<GetDeviceUserLogResponse>(ex.Message);
            }
        }

        public IResponse<bool> DeleteDevice(DeleteDeviceRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
