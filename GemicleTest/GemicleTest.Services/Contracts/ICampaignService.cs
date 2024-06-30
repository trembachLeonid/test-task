using GemicleTest.Services.Enums;

namespace GemicleTest.Services.Contracts;

public interface ICampaignService
{
    void SendCampaigns(DateTime startTime, PriorityEnum priority, TemplateEmailEnum emailType,
            int? minDeposit = null, int? maxDeposit = null,
            bool? isNewCustomer = null,
            string city = null,
            int? minAge = null,
            int? maxAge = null,
            string gender = null);
}
