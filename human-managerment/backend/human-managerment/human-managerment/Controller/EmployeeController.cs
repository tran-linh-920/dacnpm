using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using human_managerment_backend.Forms;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace HumanManagermentBackend.Controller
{
    [Route("/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeServiceImpl employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<Api<List<EmployeeDTO>>> GetAll(//
                                                              [FromQuery(Name = "page"), DefaultValue(1), Required] int page,//
                                                              [FromQuery(Name = "page_limit"), DefaultValue(10),] int limit//
                                                              )
        {

            int totalItems = _employeeService.CountAll();

            int totalPages = (int)Math.Ceiling((double)totalItems / limit);

            List<EmployeeDTO> dtos = _employeeService.FindAll(page, limit);

            Api<List<EmployeeDTO>> result = new Api<List<EmployeeDTO>>(200, dtos, "Success", new Paging(page, limit, totalPages, totalItems));

            return Ok(result);
        }

        [HttpGet("job-informations")]
        public ActionResult<Api<List<EmployeeDTO>>> GetWithJobs(//
                                                             [FromQuery(Name = "page"), DefaultValue(1), Required] int page,//
                                                             [FromQuery(Name = "page_limit"), DefaultValue(10),] int limit//
                                                             )
        {

            int totalItems = _employeeService.CountAll();

            int totalPages = (int)Math.Ceiling((double)totalItems / limit);

            List<EmployeeDTO> dtos = _employeeService.FindWithJob(page, limit);

            Api<List<EmployeeDTO>> result = new Api<List<EmployeeDTO>>(200, dtos, "Success", new Paging(page, limit, totalPages, totalItems));

            return Ok(result);
        }

        [HttpPost, RequestSizeLimit(SystemContant.Uploaded_File_Size_Limit)]
        public ActionResult<Api<EmployeeDTO>> New([FromForm] EmployeeForm empForm)
        {
            EmployeeDTO dto = _employeeService.Save(empForm);
            Api<EmployeeDTO> result = new Api<EmployeeDTO>(200, dto, "Add Success");
            return Ok(result);
        }

        [HttpPost("accept")]
        public ActionResult<Api<EmployeeDTO>> Accept(EmployeeEntity emp)
        {
            emp.JobId = emp.Job.Id;
            EmployeeDTO dto = _employeeService.Save(emp);
            Api<EmployeeDTO> result = new Api<EmployeeDTO>(200, dto, "Add Success");
            return Ok(result);
        }

        //[HttpPut("{id}")]
        //public ActionResult<Api<WorkingTimeDTO>> Edit(long id, WorkingTimeEntity newEntity)
        //{
        //    newEntity.Id = id;
        //    newEntity.WorkingTimeDetails.ForEach(wtd => wtd.WorkingTimeId = id);

        //    WorkingTimeDTO dto = _workingTimeService.Replace(newEntity);
        //    Api<WorkingTimeDTO> result = new Api<WorkingTimeDTO>(200, dto, "Edit Success");
        //    return Ok(result);
        //}

        //[HttpDelete("{id}")]
        //public ActionResult<Api<WorkingTimeDTO>> Delete(long id, WorkingTimeEntity newEntity)
        //{
        //    newEntity.Id = id;

        //    bool delResult = _workingTimeService.Delete(newEntity);
        //    Api<bool> result;
        //    if (delResult)
        //        result = new Api<bool>(200, delResult, "Delete Success");
        //    else
        //        result = new Api<bool>(200, delResult, "Delete Failure");
        //    return Ok(result);
        //}

    }

}