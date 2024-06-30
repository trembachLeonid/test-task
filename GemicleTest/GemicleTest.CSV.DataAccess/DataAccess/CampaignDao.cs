using CsvHelper;
using CsvHelper.Configuration;
using GemicleTest.CSV.DataAccess.DataAccess.Contracts;
using GemicleTest.CSV.DataAccess.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GemicleTest.CSV.DataAccess.DataAccess
{
    public class CampaignDao : ICampaignDao
    {
        private readonly string filePath;

        public CampaignDao(IOptions<CsvConnectionOptions> options)
        {
            filePath = options.Value.FilePath;
        }

        public void AddCampaign(DateTime startDate, int priority)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var stream = File.Open(filePath + "/campaigns.csv", FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.NextRecord();
                csv.WriteRecord(new Campaign
                {
                    StartDate = startDate,
                    Priority = priority,
                });

            }

            File.Create(filePath + $"/sends_{startDate.ToString("MM-dd-yyyy-HH-mm")}.csv").Close();
        }

        public void AssignCustomers(DateTime startDate, List<int> customerIds)
        {
            using (var reader = new StreamWriter(filePath + $"/sends_{startDate.ToString("MM-dd-yyyy-HH-mm")}.csv"))
            using (var csv = new CsvWriter(reader, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(customerIds.Select(id => new CustomerCampaign { CustomerId = id }));
            }
        }

        public void RemoveCustomers(DateTime startDate, List<int> idsToRemove)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            List<CustomerCampaign> customers;
            using (var reader = new StreamReader(filePath + $"/sends_{startDate.ToString("MM-dd-yyyy-HH-mm")}.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                customers = csv.GetRecords<CustomerCampaign>().ToList();
            }

            var filteredCustomers = customers.Where(c => !idsToRemove.Contains(c.CustomerId)).ToList();

            using (var writer = new StreamWriter(filePath + $"/sends_{startDate.ToString("MM-dd-yyyy-HH-mm")}.csv"))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(filteredCustomers);
            }
        }

        public List<Campaign> GetCampaignsOnDate(DateTime date)
        {
            using (var reader = new StreamReader(filePath + "/campaigns.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var campaigns = csv.GetRecords<Campaign>();

                return campaigns.Where(c => c.StartDate.ToString("MM-dd-yyyy") == date.ToString("MM-dd-yyyy")).ToList();
            }
        }

        public List<int> GetCustomerIdsForCampaign(DateTime startDate)
        {
            using (var reader = new StreamReader(filePath + $"/sends_{startDate.ToString("MM-dd-yyyy-HH-mm")}.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var customers = csv.GetRecords<CustomerCampaign>();

                return customers.Select(c => c.CustomerId).ToList();
            }
        }
    }
}
