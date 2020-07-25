using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using human_managerment_backend;
using human_managerment_backend.Entities;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanManagermentBackend.Controller
{
    [Route("/shifts")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly ShiftService _shiftService;

        public ShiftController(ShiftServiceImpl shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet]
        public ActionResult<Api<List<ShiftDTO>>> GetAll(//
                                                              [FromQuery(Name = "page"), DefaultValue(1), Required] int page,//
                                                              [FromQuery(Name = "page_limit"), DefaultValue(10),] int limit//
                                                              )
        {
            int totalItems = _shiftService.CountAll();

            int totalPages = (int)Math.Ceiling((double)totalItems / limit);

            List<ShiftDTO> dtos = _shiftService.FindAll(page, limit);

            Api<List<ShiftDTO>> result = new Api<List<ShiftDTO>>(200, dtos, "Success", new Paging(page, limit,totalPages, totalItems));

            return Ok(result);
        }


        [HttpPost]
        public ActionResult<Api<ShiftDTO>> New(ShiftEntity newEntity)
        {
            ShiftDTO dto = _shiftService.Save(newEntity);
            Api<ShiftDTO> result = new Api<ShiftDTO>(200, dto, "Add Success");
            return Ok(result);
        }


        //    [HttpPut("{id}")]
        //    public ActionResult<Api<WorkingTimeDTO>> Edit(long id, WorkingTimeEntity newEntity)
        //    {
        //        newEntity.Id = id;
        //        newEntity.WorkingTimeDetails.ForEach(wtd => wtd.WorkingTimeId = id);

        //        WorkingTimeDTO dto = _workingTimeService.Replace(newEntity);
        //        Api<WorkingTimeDTO> result = new Api<WorkingTimeDTO>(200, dto, "Edit Success");
        //        return Ok(result);
        //    }

        //    [HttpDelete("{id}")]
        //    public ActionResult<Api<WorkingTimeDTO>> Delete(long id, WorkingTimeEntity newEntity)
        //    {
        //        newEntity.Id = id;

        //        bool delResult = _workingTimeService.Delete(newEntity);
        //        Api<bool> result;
        //        if (delResult)
        //            result = new Api<bool>(200, delResult, "Delete Success");
        //        else
        //            result = new Api<bool>(200, delResult, "Delete Failure");
        //        return Ok(result);
        //    }

    }

}