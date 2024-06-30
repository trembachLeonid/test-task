using GemicleTest.CSV.DataAccess.DataAccess.Contracts;
using GemicleTest.Services.Contracts;
using GemicleTest.Services.Enums;

namespace GemicleTest.Services.Services;

public class CampaignService : ICampaignService
{
    private readonly ICustomerDao customerDao;
    private readonly IEmailService emailService;
    private readonly ICampaignDao campaignDao;

    public CampaignService(ICustomerDao customerDao, ICampaignDao campaignDao, IEmailService emailService)
    {
        this.customerDao = customerDao;
        this.emailService = emailService;
        this.campaignDao = campaignDao;
    }

    public void SendCampaigns(DateTime startTime, PriorityEnum priority, TemplateEmailEnum emailType,
            int? minDeposit = null, int? maxDeposit = null,
            bool? isNewCustomer = null,
            string city = null,
            int? minAge = null, int? maxAge = null,
            string gender = null)
    {
        var customers = customerDao.GetCustomers(minDeposit, maxDeposit, isNewCustomer, city, minAge, maxAge, gender)
            .ToList();

        campaignDao.AddCampaign(startTime, (int)priority);

        var customerIds = customers.Select(c => c.CustomerId).ToList();
        campaignDao.AssignCustomers(startTime, customerIds);

        var campaignsWithLowerPriority = campaignDao.GetCampaignsOnDate(startTime)?.Where(c => c.Priority <= (int)priority);
        
        if (campaignsWithLowerPriority is not null)
        {
            foreach (var campaign  in campaignsWithLowerPriority)
            {
                var lowPriorityCampaignCustomerIds = campaignDao.GetCustomerIdsForCampaign(campaign.StartDate);

                var idsToRemove = lowPriorityCampaignCustomerIds.Intersect(customerIds).ToList();
                if (idsToRemove.Any())
                {
                    campaignDao.RemoveCustomers(campaign.StartDate, idsToRemove);
                }
            }
        }

        emailService.SendEmail(customers.Select(c => c.CustomerId.ToString()).ToList(), startTime, priority, emailType);
    }
}
