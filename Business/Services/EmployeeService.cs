using Business.Interface;
using Core.Enums;
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

        public IResponse<List<GetEmployeeModReportResponse>> GetEmployeeModReport(int month,int year,int? EmployeeID)
        {
            try
            {
                var monthFirstDate = new DateTime(year, month, 1);
                var monthLastDate = monthFirstDate.AddMonths(1).AddDays(-1);
                var LoopStartDate = monthFirstDate;
                var ModReportData = UnitOfWork.EmployeeRepository.GetEmployeeMODReport(monthFirstDate, monthLastDate, EmployeeID).Where(m=>m.Status== "ნამუშევარი საათები");
                var result = new List<GetEmployeeModReportResponse>();

                //დასვენებების დღეების დათვლა
                var govermentHolidays = UnitOfWork.GovernmentHolidaysRepository.GetGovernmentHolidays().Where(m => m.HolidayDate >= monthFirstDate && m.HolidayDate <= monthLastDate);
                var govermentHolidaysCount = govermentHolidays.Count();
                if (ModReportData.Count() > 0)
                {
                    foreach (var employee in ModReportData.GroupBy(m => m.EmployeeID).Select(x => x.FirstOrDefault()))
                    {
                        var employeeData = new GetEmployeeModReportResponse()
                        {
                            WorkingLog = ModReportData.Where(m => m.EmployeeID == employee.EmployeeID).Select(m => new GetEmployeeModReportItems()
                            {
                                Date = m.DateRecord,
                                WorkedTime = m.MinutesSum / 60,
                                WorkedTimeHoures = (Math.Floor(decimal.Parse((m.MinutesSum / 60).ToString())).ToString().Length >= 2 ?
                                 Math.Floor(decimal.Parse((m.MinutesSum / 60).ToString())).ToString() : "0" + Math.Floor(decimal.Parse((m.MinutesSum / 60).ToString())).ToString()) + ":" +
                              ((m.MinutesSum % 60).ToString().Length >= 2 ? (m.MinutesSum % 60).ToString() : "0" + (m.MinutesSum % 60).ToString())
                            }).ToList(),
                            EmployeeFullname = employee.FullName,
                            PersonalNumber = employee.PersonalNumber,
                            Position = employee.Position,
                            SumFirstHalf = ModReportData.Where(m => m.EmployeeID == employee.EmployeeID && m.DateRecord <= monthFirstDate.AddDays(14)).Sum(x => x.MinutesSum) / 60,
                            SumSecondHalf = ModReportData.Where(m => m.EmployeeID == employee.EmployeeID && m.DateRecord > monthFirstDate.AddDays(14)).Sum(x => x.MinutesSum) / 60,
                            
                        };
                        while (LoopStartDate.Date <= monthLastDate.Date)
                        {
                            if (employeeData.WorkingLog.Where(m => m.Date.Date == LoopStartDate.Date).FirstOrDefault() == null)
                            {
                                employeeData.WorkingLog.Add(new GetEmployeeModReportItems() { Date = LoopStartDate, WorkedTime = 0, WorkedTimeHoures = "00:00" });
                            }
                            LoopStartDate = LoopStartDate.AddDays(1);
                         }
                        employeeData.SumHouresInMonth = (employeeData.SumFirstHalf + employeeData.SumSecondHalf);
                        employeeData.SumDaysInMonth = ModReportData.Where(m => m.EmployeeID == employee.EmployeeID).Count();
                        employeeData.WorkingLog.OrderBy(m => m.Date);
                        var employeeHolidays = UnitOfWork.EmployeeHolidayRequestRepository.GetHolidayRequestByEmployee(employee.EmployeeID).Where(m => m.FromDate >= monthFirstDate && m.ToDate <= monthLastDate);
                        var employeeSchedule = UnitOfWork.EmployeeRepository.GetEmployeeSchedule(employee.EmployeeID);
                        
                        employeeData.SumHolidayes = 0;
                        employeeData.SumHolidaysWithoutCompensate = 0;
                        employeeData.OverTime = 0;
                        employeeData.NightHoures = 0;
                        employeeData.SumGovermentHolidays = govermentHolidaysCount;
                        employeeData.WorkedHouresInGovermentHolidays = 0;
                        //შვებულების დღეების დათვლა
                        foreach (var holiday in employeeHolidays)
                        {
                            if (holiday.HolidayTypeID == 3)
                            {
                                employeeData.SumHolidaysWithoutCompensate = employeeData.SumHolidaysWithoutCompensate + holiday.AmountWorkDays;
                            }
                            else { 
                            employeeData.SumHolidayes = employeeData.SumHolidayes + holiday.AmountWorkDays;
                            }
                        }
                        employeeData.WorkedHouresInGovermentHolidays = 0;
                        foreach(var govermentHolid in govermentHolidays)
                        {
                            var holiday = employeeData.WorkingLog.Where(m => m.Date.Date == govermentHolid.HolidayDate.Date).FirstOrDefault();
                            if (holiday != null)
                            {
                                employeeData.WorkedHouresInGovermentHolidays = employeeData.WorkedHouresInGovermentHolidays + holiday.WorkedTime;
                            }
                        }

                        result.Add(employeeData);
                    }


                    return Ok(result);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return Fail<List<GetEmployeeModReportResponse>>(ex.Message);
            }
        }

        public IResponse<GetEmployeeFullReportResponse> GetEmployeeFullReport(int month,int year,int? EmployeeID)
        {
            try
            {
                var monthFirstDate = new DateTime(year, month, 1);
                var monthLastDate = monthFirstDate.AddMonths(1).AddDays(-1);
                var LoopStartDate = monthFirstDate;
                var result = UnitOfWork.EmployeeRepository.GetEmployeeFullReport(monthFirstDate, monthLastDate, EmployeeID);
                var returnModel = new GetEmployeeFullReportResponse() { GetEmployeeFullReportItems = new List<GetEmployeeFullReportItem>() };
                foreach (var employee in result.GroupBy(m => m.EmployeeID).Select(x => x.FirstOrDefault()))
                {
                    var employeeResult = UnitOfWork.EmployeeListRepository.GetEmployeeList().Where(m => m.ID == employee.EmployeeID).FirstOrDefault();
                    var employeeData = new GetEmployeeFullReportItem();
                    employeeData.EmployeeID = employee.EmployeeID;
                    employeeData.Department = employeeResult.EmployeeDetails?.Department.Description;
                    employeeData.ServiceCenter = employeeResult.EmployeeDetails?.Branch.BranchName;
                    employeeData.FullName = employee.FullName;
                    employeeData.SalaryAmount = employeeResult.EmployeeDetails.Salary!=null? employeeResult.EmployeeDetails.Salary.Amount:0;
                    employeeData.SumWorkedHoures = result.Where(m => m.EmployeeID == employee.EmployeeID).Sum(n => n.WorkedMinutess).Value;
                    employeeData.SumWorkedInSchedule = result.Where(m => m.EmployeeID == employee.EmployeeID).Sum(n => n.WorkedInSchedule).Value;
                    employeeData.SumWorkedOutOfSchedule = result.Where(m => m.EmployeeID == employee.EmployeeID).Sum(n => n.WorkedOutSchedule).Value;
                    employeeData.SumEarlyCheckInCount = result.Where(m => m.EmployeeID == employee.EmployeeID && m.EarlyCheckInMinutes != null && m.EarlyCheckInMinutes != 0).Count();
                    employeeData.SumEarlyCheckOutCount = result.Where(m => m.EmployeeID == employee.EmployeeID && m.EarlyCheckOutMinutes != null && m.EarlyCheckOutMinutes != 0).Count();
                    employeeData.SumEarlyCheckOut = result.Where(m => m.EmployeeID == employee.EmployeeID).Sum(n => n.EarlyCheckOutMinutes).Value;
                    employeeData.SumEarlyMinutes = result.Where(m => m.EmployeeID == employee.EmployeeID).Sum(n => n.EarlyCheckInMinutes).Value;
                    employeeData.SumLateCheckOut = result.Where(m => m.EmployeeID == employee.EmployeeID && m.LateCheckOutMinutes != null && m.LateCheckOutMinutes != 0).Count();
                    employeeData.SumLateMinutes = result.Where(m => m.EmployeeID == employee.EmployeeID).Sum(n => n.LateCheckInMinutes).Value;
                    employeeData.SumLateCheckInCount = result.Where(m => m.EmployeeID == employee.EmployeeID && m.LateCheckInMinutes != null && m.LateCheckInMinutes != 0).Count();
                    employeeData.IndRegID = employee.EmployeeID;
                    employeeData.SumWorkedOutOfSchedule = result.Where(m => m.EmployeeID == employee.EmployeeID).Sum(n => n.WorkedOutSchedule).Value;
                    employeeData.SumMissedDays = result.Where(m => m.EmployeeID == employee.EmployeeID && m.WorkStatus == "გააცდინა").Count();
                    employeeData.EmployeeWorkingLogs = result.Where(m => m.EmployeeID == employee.EmployeeID).Select(m => m.AsViewModel()).OrderBy(m => m.ScheduleFromTime.Value).ToList();
                    returnModel.GetEmployeeFullReportItems.Add(employeeData);

                    var foregivenessType = employeeResult.EmployeeDetails.Forgiveness.ForgivenessTypeID;
                    var foregivenessAmount = employeeResult.EmployeeDetails.Forgiveness.Amount;
                    
                    //ხელფასის დაანგარიშება 

                    switch (employeeResult.EmployeeDetails.Salary?.SalaryTypeID)
                    {
                        case (int)SalaryTypes.EveryMonth:
                            employeeData.SalaryAmount = employeeData.SalaryAmount;
                            break;
                        case (int)SalaryTypes.Hourly:
                            employeeData.SalaryAmount = employeeData.SalaryAmount * (employeeData.SumWorkedHoures / 60);
                            break;
                        case (int)SalaryTypes.Weekly:
                            employeeData.SalaryAmount = employeeData.SalaryAmount * 4;
                            break;
                        case (int)SalaryTypes.Year:
                            employeeData.SalaryAmount = employeeData.SalaryAmount / 12;
                            break;
                        default:
                            employeeData.SalaryAmount = employeeData.SalaryAmount;
                            break;
                    }
                    if (employeeResult.EmployeeDetails.Fine != null) { 
                    switch (employeeResult.EmployeeDetails.Fine?.FineTypeID)
                    {
                        case (int)FineType.WithoutFine:
                            employeeData.FineAmount = 0;
                            break;
                        case (int)FineType.PersentPerMinute:
                                employeeData.FineAmount =
                                   //თუ არ ეპატიება 
                                   foregivenessType == (int)ForgivenessType.WithoutForgivenes ? ((employeeData.SumEarlyCheckOut + employeeData.SumLateMinutes) * (employeeData.SalaryAmount*employeeResult.EmployeeDetails.Fine.Amount / 100)) :
                                   //თუ რაოდენობრივი პატიება აქვს 
                                   foregivenessType == (int)ForgivenessType.XCountForgivenessInMonth ?
                                    (result.Where(m => m.EmployeeID == employee.EmployeeID).OrderBy(m => m.ScheduleFromTime).Skip(foregivenessAmount).Sum(m => m.LateCheckInMinutes + m.EarlyCheckOutMinutes).Value * (employeeData.SalaryAmount*employeeResult.EmployeeDetails.Fine.Amount / 100)) :
                                   foregivenessType == (int)ForgivenessType.XMinuteForgivenessInMonth ? (employeeData.SumEarlyCheckOut + employeeData.SumLateMinutes - foregivenessAmount) * (employeeResult.EmployeeDetails.Fine.Amount / 100) :
                                   0;
                                break;
                            case (int)FineType.FixedPerMinute:
                                employeeData.FineAmount =
                                   //თუ არ ეპატიება 
                                   foregivenessType == (int)ForgivenessType.WithoutForgivenes ?  ((employeeData.SumEarlyCheckOut + employeeData.SumLateMinutes) * (employeeResult.EmployeeDetails.Fine.Amount)) :
                                   //თუ რაოდენობრივი პატიება აქვს 
                                   foregivenessType == (int)ForgivenessType.XCountForgivenessInMonth ?
                                   (result.Where(m => m.EmployeeID == employee.EmployeeID).OrderBy(m => m.ScheduleFromTime).Skip(foregivenessAmount).Sum(m => m.LateCheckInMinutes + m.EarlyCheckOutMinutes).Value * (employeeResult.EmployeeDetails.Fine.Amount )) :
                                   foregivenessType == (int)ForgivenessType.XMinuteForgivenessInMonth ? (employeeData.SumEarlyCheckOut + employeeData.SumLateMinutes - foregivenessAmount) * (employeeResult.EmployeeDetails.Fine.Amount) :
                                   0;
                                break;
                            case (int)FineType.PersentFine:
                                employeeData.FineAmount=(employeeData.SumLateCheckInCount+employeeData.SumEarlyCheckOutCount-(foregivenessType==(int)ForgivenessType.XCountForgivenessInMonth?foregivenessAmount:0))*((employeeData.SalaryAmount*employeeResult.EmployeeDetails.Fine.Amount)/100);
                                break;
                            case (int)FineType.FixedFine:
                               employeeData.FineAmount = (employeeData.SumLateCheckInCount + employeeData.SumEarlyCheckOutCount - (foregivenessType == (int)ForgivenessType.XCountForgivenessInMonth ? foregivenessAmount : 0)) * employeeResult.EmployeeDetails.Fine.Amount;
                                break;
                            default:
                                employeeData.FineAmount = 0;
                                break;
                        }
                        employeeData.SalaryAfterFine = employeeData.SalaryAmount - employeeData.FineAmount;
                    }

                }
                return Ok(returnModel);
            }catch(Exception ex)
            {
                return Fail<GetEmployeeFullReportResponse>(ex.Message);
            }
 
        }

        public IResponse<GetEmployeeHolidayReqListResponse> GetEmployeeHolidayRequestList(int? EmployeeID)
        {
            var result = UnitOfWork.EmployeeHolidayRequestRepository.GetHolidayRequestByEmployee(EmployeeID).Select(m => m.AsViewModel()).ToList();
            return Ok(new GetEmployeeHolidayReqListResponse()
            {
                 GetEmployeeHolidayRequestList=result
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

        public IResponse<bool> GenerateEmployeeModReportData(int month, int year)
        {
            try { 
            var monthFirstDate = new DateTime(year, month, 1);
            var monthLastDate = monthFirstDate.AddMonths(1).AddDays(-1);
            var result = UnitOfWork.EmployeeRepository.GenerateModReportData(monthFirstDate, monthLastDate);
            return Ok(result);
            }catch(Exception ex)
            {
                return Fail<bool>(ex.Message);
            }
        }
    }
}
