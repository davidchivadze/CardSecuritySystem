using Business.Interface;
using Business.Services;
using Core.Helpers;
using Models.DeviceResponseModels;
using Models.ViewModels.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class DeviceController : ApiController
    {
        private IDeviceService _deviceService;
        public DeviceController()
        {
            this._deviceService = new DeviceService();
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
        [System.Web.Http.HttpPost]
        public async Task<IResponse<bool>> SyncUserLog()
        {
            return await _deviceService.SyncUserLog();
        }
        public IResponse<bool> ClearDeviceData()
        {
            return _deviceService.ClearDeviceData();
        }
        public Task<IResponse<bool>> UpdateUserListFromDevice()
        {
            return _deviceService.UpdateUserListFromDevice();
        }
        public IResponse<bool> InsertUserToDevice(int UserID)
        {
            return _deviceService.InsertUserToDevice(UserID);
        }
      
    }
}

