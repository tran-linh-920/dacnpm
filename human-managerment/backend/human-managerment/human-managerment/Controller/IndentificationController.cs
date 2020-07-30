
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HumanManagermentBackend.Controller
{
    [Route("/indentifications")]
    [ApiController]
    public class IndentificationController : ControllerBase
    {
        private readonly IndentificationService _indentificationService;


        public IndentificationController(IndentificationServiceImpl indentificationService)
        {
            _indentificationService = indentificationService;
        }

        [HttpGet]
        public ActionResult<Api<List<IndentificationDTO>>> GetAll()
        {
            List<IndentificationDTO> dtos = _indentificationService.FindAll();

            Api<List<IndentificationDTO>> result = new Api<List<IndentificationDTO>>(200, dtos, "Success");

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Api<IndentificationDTO>> New(IndentificationEntity newEntity)
        {
            IndentificationDTO dto = _indentificationService.Save(newEntity);
            Api<IndentificationDTO> result = new Api<IndentificationDTO>(200, dto, "Add Success");
            return Ok(result);
        }
    }
}
