using GemicleTest.Services.Contracts;
using GemicleTest.Services.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GemicleTest.Api
{
    [Route("api/campaigns")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            this.campaignService = campaignService;
        }

        [HttpPost]
        [Route("send")]
        public IActionResult SendCampaigns(DateTime startTime, PriorityEnum priority, TemplateEmailEnum emailType,
            int? minDeposit = null, int? maxDeposit = null,
            bool? isNewCustomer = null,
            string city = null,
            int? minAge = null, int? maxAge = null,
            string gender = null)
        {
            try
            {
                campaignService.SendCampaigns(startTime, priority, emailType, minDeposit, maxDeposit, isNewCustomer, city, minAge, maxAge, gender);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
