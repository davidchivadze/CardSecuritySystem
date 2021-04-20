using Models.EntityModels;
using Models.LinqJoinDatabaseModels;
using Models.ViewModels.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class DeviceTransformer
    {
        public static AddDeviceRequest AsViewModelEdit(this Device model)
        {
            return new AddDeviceRequest()
            {
                ID = model.ID,
                BranchID = model.BranchID,

                DeviceLocationInBranchID = model.DeviceLocationInBranchID,
                DeviceTypeID = model.DeviceTypeID,
                IPAddress = model.IPAddress,

                Name = model.Name,
                NumberDevices = model.NumberDevices == 0 ? 1 : model.NumberDevices,
                Password = model.Password,
                Port = model.Port,
                UserName = model.UserName

            };
        }
        public static Device AsDatabaseModel(this AddDeviceRequest model)
        {
            return new Device()
            {
                ID = model.ID.HasValue ? model.ID.Value : 0,
                BranchID = model.BranchID,
                CreateDate = DateTime.Now,
                DeviceLocationInBranchID = model.DeviceLocationInBranchID,
                DeviceTypeID = model.DeviceTypeID,
                IPAddress = model.IPAddress,
                IsActive = true,
                Name = model.Name,
                NumberDevices = model.NumberDevices == 0 ? 1 : model.NumberDevices,
                Password = model.Password,
                Port = model.Port,
                UserName = model.UserName,
                LastSyncDate = DateTime.Now

            };
        }
        //public static Device AsViewModel(this DeleteDeviceRequest model)
        //{
        //    return new Device()
        //    {
        //        ID=model.ID,
        //        CreateDate = DateTime.Now,
        //        IPAddress = model.IPAddress,
        //        IsActive = true,
        //        LastSyncDate = DateTime.Now

        //    };
        //}
        public static DeviceUserLog AsDatabaseModel(this Models.DeviceResponseModels.DeviceUserLog model)
        {
            return new DeviceUserLog()
            {
                DateTimeRecord = model.DateTimeRecord,
                dwInOutMode = model.dwInOutMode,
                dwVerifyMode = model.dwVerifyMode,
                IndRegID = model.IndRegID,
                MachineNumber = model.MachineNumber,
                IsActive = model.IsActive
            };
        }
        public static DeviceRegistratedUsers AsDatabaseModel(this Models.DeviceResponseModels.UserInfo model)
        {
            try { 
            return new DeviceRegistratedUsers()
            {
                Enabled = model.Enabled,
                FingerIndex = model.FingerIndex,
                iFlag = model.iFlag,
                MachineNumber = model.MachineNumber,
                Name = model.Name,
                Password = model.Password,
                Privelage = model.Privelage,
                TmpData = model.TmpData,
                UserDeviceID = model.EnrollNumber==""||String.IsNullOrEmpty(model.EnrollNumber)?0:int.Parse(model.EnrollNumber)

            };
            }catch(Exception ex)
            {
                throw new Exception("მეპერს დაერხა");
            }
        }
        public static GetDeviceListItem AsViewModel(this Device model)
        {
            return new GetDeviceListItem()
            {
                ID = model.ID,
                IPAddress = model.IPAddress,
                LastSyncDate = model.LastSyncDate,
                Branch = model.Branch.BranchName,
                LocationInBranch = model.DeviceLocationInBranch.Description,
                State = model.IsActive == true ? 1 : 0,
                Name = model.Name
            };
        }
        public static DeviceUserListItem AsViewModel(this DeviceRegistratedUsersToEmployee model)
        {
            return new DeviceUserListItem()
            {
                ID = model.ID,
                TmpData = model.TmpData,
                Enabled = model.Enabled,
                FingerIndex = model.FingerIndex,
                iFlag = model.iFlag,
                IsRegistratedSystem = model.IsRegistratedSystem,
                MachineNumber = model.MachineNumber,
                Name = model.Name,
                Password = model.Password,
                Privelage = model.Privelage,
                UserDeviceID = model.UserDeviceID
            };
        }
        public static GetDeviceUserLogItem AsViewModel(this DeviceAndDbUsersJoin model)
        {
            return new GetDeviceUserLogItem()
            {
                FirsName = model.FirsName,
                LastName = model.LastName,
                MachineNumber = model.MachineNumber,
                PersonalNumber = model.PersonalNumber,
                RecordTime = DateTime.Parse(model.RecordTime),
                UserIDInDevice = model.UserIDInDevice,
                VerifyMode = model.VerifyMode,

            };
        }
    }
}
