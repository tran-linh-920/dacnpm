using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Forms;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HumanManagermentBackend.Controller
{
    [Route("/schedules")]
    [ApiController]
    public class ScheduleController: ControllerBase
    {
        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleServiceImpl scheduleService)
        {
            _scheduleService = scheduleService;
        }


        [HttpGet]
        public ActionResult<Api<List<ScheduleDTO>>> GetAll()
        {


            List<ScheduleDTO> dtos = _scheduleService.FindAll();

            Api<List<ScheduleDTO>> result = new Api<List<ScheduleDTO>>(200, dtos, "Success", null);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Api<ScheduleDTO>> Save(ScheduleEntity schedule)
        {


            ScheduleDTO dto = _scheduleService.Save(schedule);

            Api<ScheduleDTO> result = new Api<ScheduleDTO>(200, dto, "Success", null);

            return Ok(result);
        }
    }
}
