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
        [HttpGet("/time-keepings/refet")]
        public ActionResult<Api<List<TimeKeepingDTO>>> RefetTimeKeeping()
        {
            List<TimeKeepingDTO> dtos = _timeKeepingService.RefetTimeKeeping();
            Api<List<TimeKeepingDTO>> result = new Api<List<TimeKeepingDTO>>(200, dtos, "Success");
            return Ok(result);
        }
        [HttpGet("/time-keepings/close")]
        public ActionResult<Api<List<TimeKeepingDTO>>> CloseTimeKeeping()
        {
            List<TimeKeepingDTO> dtos = _timeKeepingService.CloseTimeKeeping();
            Api<List<TimeKeepingDTO>> result = new Api<List<TimeKeepingDTO>>(200, dtos, "Success");
            return Ok(result);
        }
        [HttpGet("/time-keepings/morning")]
        public ActionResult<Api<List<TimeKeepingDTO>>> GetMorning()
        {
            List<TimeKeepingDTO> dtos = _timeKeepingService.findMorning();
            Api<List<TimeKeepingDTO>> result = new Api<List<TimeKeepingDTO>>(200, dtos, "Success");
            return Ok(result);
        }
        [HttpGet("/time-keepings/afternoon")]
        public ActionResult<Api<List<TimeKeepingDTO>>> GetAfternoon()
        {
            List<TimeKeepingDTO> dtos = _timeKeepingService.findAfternoon();
            Api<List<TimeKeepingDTO>> result = new Api<List<TimeKeepingDTO>>(200, dtos, "Success");
            return Ok(result);
        }
        [HttpPut("/time-keepings/morning/{id}")]
        public ActionResult<Api<TimeKeepingDTO>> StartUpMorning(long id, TimeKeepingEntity newEntity)
        {
            newEntity.Id = id;
            TimeKeepingDTO dto = _timeKeepingService.stardUp(newEntity, "morning");
            Api<TimeKeepingDTO> result = new Api<TimeKeepingDTO>(200, dto, "Edit Success");
            return Ok(result);
        }
        [HttpPut("/time-keepings/afternoon/{id}")]
        public ActionResult<Api<TimeKeepingDTO>> StartUpAfternoon(long id, TimeKeepingEntity newEntity)
        {
            newEntity.Id = id;

            TimeKeepingDTO dto = _timeKeepingService.stardUp(newEntity, "afternoon");
            Api<TimeKeepingDTO> result = new Api<TimeKeepingDTO>(200, dto, "Edit Success");
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Api<TimeKeepingDTO>> New()
        {
            List<TimeKeepingDTO> dtos = _timeKeepingService.Save();
            Api<List<TimeKeepingDTO>> result = new Api<List<TimeKeepingDTO>>(200, dtos, "Success");
            return Ok(result);
        }
       
    }
}
