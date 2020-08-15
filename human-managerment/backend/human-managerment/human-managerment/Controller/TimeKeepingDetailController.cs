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
using System.ComponentModel;
using System.Linq;


namespace HumanManagermentBackend.Controller
{
    [Route("/time-keeping-detail")]
    [ApiController]
    public class TimeKeepingDetailController : ControllerBase
    {
        private readonly TimeKeepingDetailService _timekeepingDetailService;



        public TimeKeepingDetailController(TimeKeepingDetailServiceImpl timeKeepingDetialService)
        {
            _timekeepingDetailService = timeKeepingDetialService;
        }
        [HttpGet]
        public ActionResult<Api<List<TimeKeepingDetailDTO>>> GetAll(//
                                                              [FromQuery(Name = "page"), DefaultValue(1)] int page,//
                                                              [FromQuery(Name = "page_limit"), DefaultValue(10),] int limit//
                                                                )
        {
            List<TimeKeepingDetailDTO> dtos = _timekeepingDetailService.findAllHistory(page, limit);
            Api<List<TimeKeepingDetailDTO>> result = new Api<List<TimeKeepingDetailDTO>>(200, dtos, "Success");
            return Ok(result);
        }
        [HttpGet("/time-keeping-detail/morning")]
        public ActionResult<Api<List<TimeKeepingDetailDTO>>> getTimeKeepingDetailMonning()
        {
            List<TimeKeepingDetailDTO> dtos = _timekeepingDetailService.findAllMorning();
            Api<List<TimeKeepingDetailDTO>> result = new Api<List<TimeKeepingDetailDTO>>(200, dtos, "Success");
            return Ok(result);
        }
        [HttpGet("/time-keeping-detail/afternoon")]
        public ActionResult<Api<List<TimeKeepingDetailDTO>>> getTimeKeepingDetailAfteroon()
        {
            List<TimeKeepingDetailDTO> dtos = _timekeepingDetailService.findAllAfteroon();
            Api<List<TimeKeepingDetailDTO>> result = new Api<List<TimeKeepingDetailDTO>>(200, dtos, "Success");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public ActionResult<Api<List<TimeKeepingDetailDTO>>> endTimeKeeping(long id, TimeKeepingDetailEntity entity)
        {
            entity.Id = id;

            TimeKeepingDetailDTO dto = _timekeepingDetailService.endTimeKeepingforOneDay(entity);
            Api<TimeKeepingDetailDTO> result = new Api<TimeKeepingDetailDTO>(200, dto, "Edit Success");
            return Ok(result);
        }
        [HttpDelete("{id}")]
       public ActionResult<Api<List<TimeKeepingDetailDTO>>> removeTimeKeeping(long id)
       {
      
            TimeKeepingDetailDTO dto = _timekeepingDetailService.removeTimeKeeping(id);
            Api<TimeKeepingDetailDTO> result = new Api<TimeKeepingDetailDTO>(200, dto, " Success");
            return Ok(result);
        }

    }
}
