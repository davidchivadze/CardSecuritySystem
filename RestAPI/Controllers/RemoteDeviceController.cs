using Business.Interface;
using Core.Helpers;
using Models.DeviceResponseModels;
using Models.ViewModels.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using zkemkeeper;

namespace RestAPI.Controllers
{
    public class RemoteDeviceController : ApiController
    {
        private IDeviceService _deviceService;
       public RemoteDeviceController(IDeviceService deviceService)
        {
            this._deviceService = deviceService;
        }
        //public bool Connect(string ipAddress,string port)
        //{
        //    var result=_deviceClient.Connect_Net(ipAddress, int.Parse(port));
        //    return result;
        //}
        public IResponse<DateTime> GetMachineDateTime()
        {
            return _deviceService.GetDeviceDateTime();
        }
        public IResponse<bool> AddDevice(AddDeviceRequest model)
        {
            return _deviceService.AddDevice(model);
        }
        public IResponse<GetDeviceUserLogResponse> GetDeviceUserLogList()
        {
            return _deviceService.GetDeviceUserLogList();
        }
        public IResponse<GetDeviceListResponse> GetDeviceList()
        {
            return _deviceService.GetDeviceList();
        }
        public async Task<IResponse<bool>> SyncUserLog()
        {
            return  await _deviceService.SyncUserLog();
        }
        public IResponse<bool> ClearDeviceData()
        {
            return _deviceService.ClearDeviceData();
        }
        public  Task<IResponse<bool>> UpdateUserListFromDevice()
        {
            return  _deviceService.UpdateUserListFromDevice();
        }
        public IResponse<bool> InsertUserToDevice(int UserID)
        {
            return _deviceService.InsertUserToDevice(UserID);
        }
        public static void SetStrCardNumber(IZKEM axCZKEM1, string sIp = "192.168.1.201", int iPort = 4370,
                                      bool bEnabled = true, string sdwEnrollNumber = "6969",
                                      string sName = "MVC Datoie", string sPassword = "123456",
                                      int iPrivilege = 0, string sCardnumber = "0"
  )
        {
            //Create Standalone SDK class dynamicly.

                  int iMachineNumber = 1;
                  //axCZKEM1.Connect_Net(sIp, iPort);

                  int idwErrorCode = 0;

                  axCZKEM1.EnableDevice(iMachineNumber, false);
                  axCZKEM1.SetStrCardNumber(sCardnumber);//Before you using function SetUserInfo,set the card number to make sure you can upload it to the device
                  if (axCZKEM1.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload the user's information(card number included)
                  {
                      throw new Exception("(SSR_)SetUserInfo,UserID:" + sdwEnrollNumber + " Privilege:" + iPrivilege.ToString() + " Enabled:" + bEnabled.ToString());
                  }
                  else
                  {
                      axCZKEM1.GetLastError(ref idwErrorCode);
                      throw new Exception("Operation failed,ErrorCode=" + idwErrorCode.ToString());
                  }

                  axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                  axCZKEM1.EnableDevice(iMachineNumber, true);
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
    }
}