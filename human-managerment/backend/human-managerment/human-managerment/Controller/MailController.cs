using HumanManagermentBackend.Forms;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HumanManagermentBackend.Controller
{

    [Route("/mails")]
    [ApiController]
    public class MailController: ControllerBase
    {
        private readonly MailService _mailService;
        public MailController(MailServiceImpl mailService)
        {
            _mailService = mailService;
        }
        [HttpPost]
        public async Task<IActionResult> SendEmailAsync( MailForm mailForm)
        {
            await _mailService.SendEmail(mailForm.Address, mailForm.Title, mailForm.Content);
            return Ok();
        }
    }
}
