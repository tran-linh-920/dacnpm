using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
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
    [Route("/logs")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly LogService _logService;

        public LogController(LogServiceImpl logService)
        {
            _logService = logService;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<Api<List<LogDTO>>> GetAllLog(//
                                                              [FromQuery(Name = "page"), DefaultValue(1)] int page,//
                                                              [FromQuery(Name = "page_limit"), DefaultValue(10),] int limit//
                                                              )
        {

            int totalItems = _logService.CountAll();

            int totalPages = (int)Math.Ceiling((double)totalItems / limit);

            List<LogDTO> dtos = _logService.FindAll(page, limit);

            Api<List<LogDTO>> result = new Api<List<LogDTO>>(200, dtos, "Success", new Paging(page, limit, totalPages, totalItems));

            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<Api<LogDTO>> AddLog(LogEntity log)
        {
            LogDTO dto = _logService.Save(log);

            Api<LogDTO> result = new Api<LogDTO>(200, dto, "Success", null);

            return Ok(result);
        }
    }
}

