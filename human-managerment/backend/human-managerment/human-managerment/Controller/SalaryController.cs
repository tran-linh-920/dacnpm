using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using human_managerment_backend.Dto;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HumanManagermentBackend.Controller
{
    [Route("salaries")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly SalaryService _salaryService;
        private readonly EmployeeService _employeeService;
        public SalaryController(SalaryServiceImpl salaryService, EmployeeServiceImpl employeeService)
        {
            _salaryService = salaryService;
            _employeeService = employeeService;
        }

        [HttpGet("histories")]
        public ActionResult<Api<List<SalaryHistoryEntity>>> GetSalaryHistory(
              [FromQuery(Name = "page"), DefaultValue(1), Required] int page,//
              [FromQuery(Name = "page_limit"), DefaultValue(10)] int limit,//
              [FromQuery(Name = "month"), DefaultValue(1)] int month,//
              [FromQuery(Name = "year"), DefaultValue(1999)] int year//
            )
        {
            Date date = new Date() { month = month, year = year };
            int totalItems = _salaryService.CountAllSalaryHistoriesByDate(date);

            int totalPages = (int)Math.Ceiling((double)totalItems / limit);

            List<SalaryHistoryDTO> dtos = _salaryService.FindSalaryHistoriesByDate(page, limit, date);

            Api<List<SalaryHistoryDTO>> result = new Api<List<SalaryHistoryDTO>>((int)HttpStatusCode.OK, dtos, "Success", new Paging(page, limit, totalPages, totalItems));

            return Ok(result);
        }

        [HttpPost("counting")]
        public ActionResult<Api<Object>> CountSalary(Date countingDate)
        {
            int page = 1;
            int limit = 10;
            int totalItems = _employeeService.CountAll();
            int totalPages = (int)Math.Ceiling((double)totalItems / limit);
            string massage = SystemContant.SALARY_COUNTING_FIELD_DETAIL_MASSAGE;
            bool isErr = false;

            if(countingDate.day == 0)
                countingDate.day = DateTime.Today.Day;

            if (countingDate.month > DateTime.Today.Month || countingDate.year > DateTime.Today.Year)
                throw new Exception(SalaryMessageContant.OVER_TIME);

            //if (!_salaryService.CanCounting(new DateTime(countingDate.year, countingDate.month, countingDate.day)))
            //    return Ok(new Api<string>(200, "", SystemContant.SALARY_COUNTING_FIELD_MASSAGE));

                for (int i = page; i <= totalPages; i++)
            {
                List<EmployeeDTO> employees = _employeeService.FindAll(i, limit);
                foreach (EmployeeDTO emp in employees)
                {
                    if (!_salaryService.DoSalaryCounting(emp.Id, countingDate))
                    {
                        isErr = true;
                        massage += " " + emp.Id + ":" + emp.Lastname + emp.Firstname + " - ";
                    }
                }
            }

            if (!isErr)
                return Ok(new Api<Object>((int)HttpStatusCode.OK, null, SystemContant.SALARY_COUNTING_SUCCSESS_MASSAGE));

            return Ok(new Api<Object>((int)HttpStatusCode.InternalServerError, null, massage));
        }

        [HttpPut("increasing/{empId}/{jobLevel}")]
        public ActionResult<Api<JobHistoryDetailDTO>> IncreaseSalary(long empId, int jobLevel)
        {
            JobHistoryDetailDTO dto = _salaryService.DoSalaryIncreasing(empId, jobLevel);
            return Ok(new Api<JobHistoryDetailDTO>((int)HttpStatusCode.OK, dto, SalaryMessageContant.SALARY_INCREASING_SUCCESSFULL));
        }

    }
}
