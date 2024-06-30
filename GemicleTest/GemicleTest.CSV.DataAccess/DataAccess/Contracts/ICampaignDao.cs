using GemicleTest.CSV.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemicleTest.CSV.DataAccess.DataAccess.Contracts
{
    public interface ICampaignDao
    {
        void AddCampaign(DateTime startDate, int priority);
        List<Campaign> GetCampaignsOnDate(DateTime date);
        void AssignCustomers(DateTime startDate, List<int> customerIds);
        List<int> GetCustomerIdsForCampaign(DateTime startDate);
        void RemoveCustomers(DateTime startDate, List<int> idsToRemove);
    }
}
