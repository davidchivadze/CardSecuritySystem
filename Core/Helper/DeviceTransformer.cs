using Models.EntityModels;
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
        public static Device AsDatabaseModel(this AddDeviceRequest model)
        {
            return new Device()
            {
                BranchID = model.BranchID,
                CreateDate = DateTime.Now,
                DeviceLocationInBranchID = model.DeviceLocationInBranchID,
                DeviceTypeID = model.DeviceTypeID,
                IPAddress = model.IPAddress,
                IsActive = true,
                Name = model.Name,
                NumberDevices = model.NumberDevices,
                Password = model.Password,
                Port = model.Port,
                UserName = model.UserName,
                LastSyncDate = DateTime.Now

            };
        }
        public static DeviceUserLog AsDatabaseModel(this Models.DeviceResponseModels.DeviceUserLog model)
        {
            return new DeviceUserLog()
            {
                DateTimeRecord = model.DateTimeRecord,
                dwInOutMode = model.dwInOutMode,
                dwVerifyMode = model.dwVerifyMode,
                IndRegID = model.IndRegID,
                MachineNumber = model.MachineNumber
            };
        }
        public static DeviceRegistratedUsers AsDatabaseModel(this Models.DeviceResponseModels.UserInfo model)
        {
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
                UserDeviceID = int.Parse(model.EnrollNumber)
            };
        }
    }
}
