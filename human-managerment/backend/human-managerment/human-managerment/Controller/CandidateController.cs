using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using human_managerment_backend.Dto;
using human_managerment_backend.Forms;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Forms;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace HumanManagermentBackend.Controller
{
    [Route("/candidates")]
    [ApiController]
    public class CandidateController: ControllerBase
    {
        private readonly CandidateService _candidateService;

        public CandidateController(CandidateServiceImpl candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet("type/{id}")]
        public ActionResult<Api<List<CandidateDTO>>> GetAll(//
                                                             [FromQuery(Name = "page"), DefaultValue(1), Required] int page,//
                                                             [FromQuery(Name = "page_limit"), DefaultValue(10),] int limit,//
                                                             int id)
        {

            int totalItems = _candidateService.CountAll();

            int totalPages = (int)Math.Ceiling((double)totalItems / limit);

            List<CandidateDTO> dtos = _candidateService.FindAll(page, limit, id);

            Api<List<CandidateDTO>> result = new Api<List<CandidateDTO>>(200, dtos, "Success", new Paging(page, limit, totalPages, totalItems));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Api<CandidateDTO>> GetOne(long id)
        {


            CandidateDTO dto = _candidateService.FindOne(id);

            Api<CandidateDTO> result = new Api<CandidateDTO>(200, dto, "Success", null);

            return Ok(result);
        }


        [HttpPost, RequestSizeLimit(SystemContant.Uploaded_File_Size_Limit)]
        public ActionResult<Api<CandidateDTO>> New([FromForm] CandidateForm canForm)
        {
           
            CandidateDTO dto = _candidateService.Save(canForm);
            Api<CandidateDTO> result = new Api<CandidateDTO>(200, dto, "Add Success");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<Api<CandidateDTO>> Edit(long id, [FromBody] int status)
        {

            CandidateDTO dto = _candidateService.Replace(id, status);
            Api<CandidateDTO> result = new Api<CandidateDTO>(200, dto, "Edit Success");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<Api<CandidateDTO>> Delete(long id )
        {
            _candidateService.Delete(id);
            return Ok();
        }

    }
}
