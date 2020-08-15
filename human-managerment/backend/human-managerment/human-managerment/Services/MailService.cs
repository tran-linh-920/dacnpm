using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagermentBackend.Services
{
    public interface MailService
    {
        Task SendEmail(string email, string subject, string message);
    }
}
