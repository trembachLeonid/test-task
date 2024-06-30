using GemicleTest.Messaging;
using GemicleTest.Services.Contracts;
using GemicleTest.Services.Enums;

namespace GemicleTest.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailHelper emailHelper;

        public EmailService(IEmailHelper emailHelper)
        {
            this.emailHelper = emailHelper;
        }

        public void SendEmail(List<string> emails, DateTime startDate, PriorityEnum priority, TemplateEmailEnum emailType)
        {
            string templateMessage = string.Format("Dear {0}, you where invited to campaign which starts today at {1}. PRIORITY: {2}",
                        string.Join(", ", emails), startDate.ToString("MM-dd-yyyy"), priority.ToString());

            switch (emailType)
            {
                case TemplateEmailEnum.TemplateA:
                    emailHelper.SendTemplateA(templateMessage);
                    break; 
                case TemplateEmailEnum.TemplateB:
                    emailHelper.SendTemplateB(templateMessage);
                    break;
                case TemplateEmailEnum.TemplateC:
                    emailHelper.SendTemplateC(templateMessage);
                    break;
            }
        }
    }
}
