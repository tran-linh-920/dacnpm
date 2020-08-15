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
    [Route("/notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly NoteService _noteService;

        public NoteController(NoteServiceImpl noteService)
        {
            _noteService = noteService;
        }


        [HttpGet("{id}")]
        public ActionResult<Api<NoteDTO>> GetOne(long id)
        {


            NoteDTO dto = _noteService.FindOne(id);

            Api<NoteDTO> result = new Api<NoteDTO>(200, dto, "Success", null);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<Api<NoteDTO>> Edit(long id, NoteEntity newEntity)
        {

            NoteDTO dto = _noteService.Replace(id, newEntity);
            Api<NoteDTO> result = new Api<NoteDTO>(200, dto, "Edit Success");
            return Ok(result);
        }

    }
}
