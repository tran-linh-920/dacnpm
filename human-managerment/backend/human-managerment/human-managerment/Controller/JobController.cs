using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using human_managerment_backend;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HumanManagermentBackend.Controller
{
    [Route("/jobs")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobService _jobService;


        public JobController(JobServiceImpl jobService)
        {
            _jobService = jobService;
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult<Api<List<JobDTO>>> GetAll()
        {
            List<JobDTO> dtos = _jobService.FindAll();

            Api<List<JobDTO>> result = new Api<List<JobDTO>>(200, dtos, "Success");

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Api<JobDTO>> New(JobEntity newEntity)
        {
            JobDTO dto = _jobService.Save(newEntity);
            Api<JobDTO> result = new Api<JobDTO>(200, dto, "Add Success");
            return Ok(result);
        }


        [HttpPut("{id}")]
        public ActionResult<Api<JobDTO>> Edit(long id, JobEntity newEntity)
        {
            newEntity.Id = id;
            newEntity.JobHistorys.ForEach(jh => jh.JobId = id);

            JobDTO dto = _jobService.Replace(newEntity);
            Api<JobDTO> result = new Api<JobDTO>(200, dto, "Edit Success");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<Api<JobDTO>> Delete(long id, JobEntity newEntity)
        {
            newEntity.Id = id;
            bool delResult = _jobService.Delete(newEntity);
            Api<bool> result;
            if (delResult)
                result = new Api<bool>(200, delResult, "Delete Success");
            else
                result = new Api<bool>(200, delResult, "Delete Failure");
            return Ok(result);
        }
    }

}
