using Core.Helpers;
using Models.ViewModels.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IDeviceService
    {
        IResponse<DateTime> GetDeviceDateTime();
        IResponse<bool> AddDevice(AddDeviceRequest model);
        IResponse<bool> EditDevice(AddDeviceRequest model);
        IResponse<AddDeviceRequest> GetDeviceForEdit(int deviceID);
        IResponse<bool> DeleteDevice(int id);
        IResponse<GetDeviceListResponse> GetDeviceList();
        IResponse<GetDeviceUserLogResponse> GetDeviceUserLogList();
        Task<IResponse<bool>> SyncUserLog();
        Task<IResponse<bool>> UpdateUserListFromDevice();
        IResponse<DeviceUserListResponse> GetDeviceUserList(DeviceUserListRequest request);
        IResponse<bool> InsertUserToDevice(int UserID);
        IResponse<bool> ClearDeviceData();
        IResponse<bool> SyncIsRunning();
    }
}
