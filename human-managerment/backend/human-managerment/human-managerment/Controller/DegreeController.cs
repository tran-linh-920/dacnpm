
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HumanManagermentBackend.Controller
{
    [Route("/degrees")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        private readonly DegreeService _degreeService;


        public DegreeController(DegreeServiceImpl degreeService)
        {
            _degreeService = degreeService;
        }

        [HttpGet]
        public ActionResult<Api<List<DegreeDTO>>> GetAll()
        {
            List<DegreeDTO> dtos = _degreeService.FindAll();

            Api<List<DegreeDTO>> result = new Api<List<DegreeDTO>>(200, dtos, "Success");

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Api<DegreeDTO>> New(DegreeEntity newEntity)
        {
            DegreeDTO dto = _degreeService.Save(newEntity);
            Api<DegreeDTO> result = new Api<DegreeDTO>(200, dto, "Add Success");
            return Ok(result);
        }
    }
}
