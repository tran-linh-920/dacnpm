using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanManagermentBackend.Controller
{
    [Route("/time-keepings")]
    [ApiController]
    public class TimeKeepingController : ControllerBase
    {
        private TimeKeepingService _timeKeepingService;

        public TimeKeepingController(TimeKeepingServiceImpl timeKeepingServiceimpl)
        {
            _timeKeepingService = timeKeepingServiceimpl;
        }
        [HttpGet]
        public ActionResult<Api<List<TimeKeepingDTO>>> GetAll()
        {
            List<TimeKeepingDTO> dtos = _timeKeepingService.FindAll();
            Api<List<TimeKeepingDTO>> result = new Api<List<TimeKeepingDTO>>(200, dtos, "Success");
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Api<TimeKeepingDTO>> New()
        {
            List<TimeKeepingDTO> dtos = _timeKeepingService.Save();
            Api<List<TimeKeepingDTO>> result = new Api<List<TimeKeepingDTO>>(200, dtos, "Success");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public ActionResult<Api<TimeKeepingDTO>> Edit(long id, TimeKeepingEntity newEntity)
        {

            return null;
        }
    }
}
