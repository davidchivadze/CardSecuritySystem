using Business.Interface;
using Core.Helper;
using Core.Helper.RepositoryHelperClasses;
using Core.Helpers;
using Models.ViewModels;
using Models.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public IResponse<List<GetEmployeeListItem>> GetFilteredEmployees()
        {
            var result = UnitOfWork.EmployeeRepository.GetFilteredEmployees(new EmployeeFilter() { }).Select(m => m.AsViewModel()).ToList();
            return Ok(result);

        }
        public IResponse<AddEmployeeResposeModel> AddEmployee(AddEmployeeRequestModel request)
        {
            try
            {
                var result = UnitOfWork.EmployeeRepository.AddEmployee(request.AsDatabaseModel());
                return Ok(new AddEmployeeResposeModel() { });
            }
            catch (Exception ex)
            {
                return Fail<AddEmployeeResposeModel>(ex.Message + " Inner Exception:"+ex.InnerException.Message);
            }
        }

        public void get()
        {
            
        }

        public IResponse<GetEmployeeHolidayListResponse> GetEmployeeHolidayList(GetEmployeeHolidayListRequest model)
        {
            var result = UnitOfWork.EmployeeHolidayRepository.GetHolidayByEmployee(model.EmployeeID).Select(m => m.AsViewModel());
            return Ok(new GetEmployeeHolidayListResponse()
            {
                    
            });
        }

        public IResponse<GetEmployeeListResponse> GetEmployeeList()
        {
            var result = UnitOfWork.EmployeeListRepository.GetEmployeeList().Where(m=>m.IsActive==true).Select(m => m.AsViewModel()).ToList();
            return Ok<GetEmployeeListResponse>(new GetEmployeeListResponse()
            {
                GetEmployeeList = result
            });
        }

        public IResponse<bool> DeleteEmployee(int employeeID)
        {
            try
            {
                return Ok(UnitOfWork.EmployeeRepository.DeleteEmployee(employeeID));
            }catch(Exception ex)
            {
                return Fail<bool>(ex.Message);
            }
        }

        public IResponse<EditEmployeeResposeModel> EditEmployee(GetEmployeeForEdit request)
        {
            try
            {
                var result = UnitOfWork.EmployeeRepository.EditEmployee(request.AsDatabaseModel());
                return Ok(new EditEmployeeResposeModel() { });
            }
            catch (Exception ex)
            {
                return Fail<EditEmployeeResposeModel>(ex.Message + " დეერხა " + ex.InnerException.Message);
            }
        }

        public IResponse<GetEmployeeForEdit> GetEmployeeForEdit(int EmployeeID)
        {
            try
            {
                var result = UnitOfWork.EmployeeRepository.GetEmployeeForEdit(EmployeeID);
                return Ok(result.EditViewModel());
            }catch(Exception ex)
            {
                return Fail<GetEmployeeForEdit>(ex.Message + " Inner Exception:" + ex.InnerException?.Message);
            }
        }

        public IResponse<bool> DeleteEmployees(int[] EmployeeIDs)
        {
            try
            {
                foreach (var employeeID in EmployeeIDs)
                {

                    if (!UnitOfWork.EmployeeRepository.DeleteEmployee(employeeID))
                    {

                        return Fail<bool>("მომხმარებლების წაშლა შეჩერდა ნომერზე:" + employeeID);
                    }
                }
                return Ok(true);
            }catch(Exception ex)
            {

                return Fail<bool>(ex.Message);
            }
        }

        public IResponse<GetGovernmentHolidayListResponse> GetGovernmentHolidayList()
        {
            var result = UnitOfWork.GovernmentHolidaysRepository.GetGovernmentHolidays().Select(m => m.AsViewModel()).ToList();
            return Ok<GetGovernmentHolidayListResponse>(new GetGovernmentHolidayListResponse()
            {
                GovernmentHolidayList = result
            });
        }

        public IResponse<AddGovernmentResponse> AddGovernmentHoliday(AddGovernmentRequest model)
        {
            try
            {
                var result = UnitOfWork.GovernmentHolidaysRepository.AddGHoliday(model.AsDatabaseModel());
                if (result != null)
                {
                    return Ok(new AddGovernmentResponse() { });
                }
                else
                {
                    return Fail<AddGovernmentResponse>("ვერ მოხერხდა სამთავრობო შვებულების დამატება");
                }
            }
            catch (Exception ex)
            {
                return Fail<AddGovernmentResponse>(ex.Message);
            }
        }

        public IResponse<EditGovernmentHolidayResponse> EditGovernmentHoliday(EditGovernmentHolidayRequest model)
        {
            try
            {
                var result = UnitOfWork.GovernmentHolidaysRepository.UpdateGHoliday(model.AsDatabaseModel());
                return Ok(new EditGovernmentHolidayResponse() { });
            }
            catch (Exception ex)
            {
                return Fail<EditGovernmentHolidayResponse>(ex.Message + " ვერ მოხერხდა სახელმწიფო შვებულების რედაქტირება " + ex.InnerException.Message);
            }
        }

        public IResponse<bool> DeleteGovernmentHoliday(int governmentHolidayID)
        {
            try
            {
                return Ok(UnitOfWork.GovernmentHolidaysRepository.Delete(governmentHolidayID));
            }
            catch (Exception ex)
            {
                return Fail<bool>(ex.Message);
            }
        }

        public IResponse<GetEmployeeHolidayReqListResponse> GetEmployeeHolidayRequestList(GetEmployeeHolidayReqListRequest model)
        {
            var result = UnitOfWork.EmployeeHolidayRequestRepository.GetHolidayRequestByEmployee(model.EmployeeID).Select(m => m.AsViewModel()).ToList();
            return Ok(new GetEmployeeHolidayReqListResponse()
            {

            });
        }

        public IResponse<AddEmployeeHolidayReqResponse> AddEmployeeHolidayRequest(AddEmployeeHolidayReqRequest model)
        {
            try
            {
                var result = UnitOfWork.EmployeeHolidayRequestRepository.AddHolidayRequest(model.AsDatabaseModel());
                if (result != null)
                {
                    return Ok(new AddEmployeeHolidayReqResponse() { });
                }
                else
                {
                    return Fail<AddEmployeeHolidayReqResponse>("ვერ მოხერხდა შვებულების დამატება");
                }
            }
            catch (Exception ex)
            {
                return Fail<AddEmployeeHolidayReqResponse>(ex.Message);
            }
        }

        public IResponse<EditEmployeeHolidayReqResponse> EditEmployeeHolidayRequest(EditEmployeeHolidayReqRequest model)
        {
            try
            {
                var result = UnitOfWork.EmployeeHolidayRequestRepository.UpdateHolidayRequest(model.AsDatabaseModel());
                return Ok(new EditEmployeeHolidayReqResponse() { });
            }
            catch (Exception ex)
            {
                return Fail<EditEmployeeHolidayReqResponse>(ex.Message + " ვერ მოხერხდა შვებულების რედაქტირება " + ex.InnerException.Message);
            }
        }

        public IResponse<bool> DeleteEmployeeHolidayRequest(int holidayID)
        {
            try
            {
                return Ok(UnitOfWork.EmployeeHolidayRequestRepository.Delete(holidayID));
            }
            catch (Exception ex)
            {
                return Fail<bool>(ex.Message);
            }
        }
    }
}
