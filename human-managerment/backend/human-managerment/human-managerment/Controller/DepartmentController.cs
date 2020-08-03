using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

namespace HumanManagermentBackend.Controller
{
    [Route("/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;


        public DepartmentController(DepartmentServiceImpl departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public ActionResult<Api<List<DepartmentDTO>>> GetAll(
                                                              [FromQuery(Name = "page"), DefaultValue(1), Required] int page,//
                                                              [FromQuery(Name = "page_limit"), DefaultValue(10),] int limit//
                                                            )
        {
            int totalItems = _departmentService.CountAll();

            int totalPages = (int)Math.Ceiling((double)totalItems / limit);

            List<DepartmentDTO> dtos = _departmentService.FindAll( page,  limit);

            Api<List<DepartmentDTO>> result = new Api<List<DepartmentDTO>>(200, dtos, "Success", new Paging(page, limit, totalPages, totalItems));

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Api<DepartmentDTO>> New(DepartmentEntity newEntity)
        {
            DepartmentDTO dto = _departmentService.Save(newEntity);
            Api<DepartmentDTO> result = new Api<DepartmentDTO>(200, dto, "Add Success");
            return Ok(result);
        }



    }
}
