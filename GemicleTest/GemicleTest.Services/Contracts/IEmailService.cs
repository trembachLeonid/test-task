using GemicleTest.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemicleTest.Services.Contracts
{
    public interface IEmailService
    {
        void SendEmail(List<string> emails, DateTime startDate, PriorityEnum priority, TemplateEmailEnum emailType);
    }
}
