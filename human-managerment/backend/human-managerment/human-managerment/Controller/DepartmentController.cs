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
        public ActionResult<Api<List<DepartmentDTO>>> GetAll()
        {
            List<DepartmentDTO> dtos = _departmentService.FindAll();

            Api<List<DepartmentDTO>> result = new Api<List<DepartmentDTO>>(200, dtos, "Success");

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
