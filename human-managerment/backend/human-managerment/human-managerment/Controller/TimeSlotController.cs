using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using human_managerment_backend;
using human_managerment_backend.Dto;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanManagermentBackend.Controller
{
    [Route("/time-slots")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private readonly TimeSlotService _timeSlotService;

        public TimeSlotController(TimeSlotServiceImpl timeSlotService)
        {
            _timeSlotService = timeSlotService;
        }

        [HttpGet]
        public ActionResult<Api<List<TimeSlotDTO>>> GetAll()
        {
            List<TimeSlotDTO> dtos = _timeSlotService.FindAll();
            Api<List<TimeSlotDTO>> result = new Api<List<TimeSlotDTO>>(200,dtos,"Success");
            return Ok(result);
        }

    }

}