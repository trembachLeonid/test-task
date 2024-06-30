using System;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using GemicleTest.CSV.DataAccess.DataAccess.Contracts;
using GemicleTest.CSV.DataAccess.Models;
using Microsoft.Extensions.Options;

namespace GemicleTest.CSV.DataAccess.DataAccess
{
    public class CustomerDao : ICustomerDao
    {
        private readonly string customersFilePath;
        private readonly string customerCampaignsFilePath;

        public CustomerDao(IOptions<CsvConnectionOptions> options)
        {
            customersFilePath = options.Value.FilePath + "/customers.csv";
            customerCampaignsFilePath = options.Value.FilePath + "/customer-campaigns.csv";
        }

        public List<Customer> GetCustomers(
            int? minDeposit = null, int? maxDeposit = null,
            bool? isNewCustomer = null,
            string city = null,
            int? minAge = null, int? maxAge = null,
            string gender = null)
        {
            using (var reader = new StreamReader(customersFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var customers = csv.GetRecords<Customer>();

                if (minDeposit.HasValue && maxDeposit.HasValue)
                    customers = customers
                        .Where(c => c.Deposit > minDeposit.Value && c.Deposit < maxDeposit.Value);
                else if (minDeposit.HasValue)
                    customers = customers
                        .Where(c => c.Deposit > minDeposit.Value);
                else if (maxDeposit.HasValue)
                    customers = customers
                        .Where(c => c.Deposit < maxDeposit.Value);

                if (isNewCustomer.HasValue)
                    customers = customers
                        .Where(c => c.NewCustomer == isNewCustomer.Value);

                if (!string.IsNullOrEmpty(city))
                    customers = customers
                        .Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase));

                if (minAge.HasValue && maxAge.HasValue)
                    customers = customers
                        .Where(c => c.Deposit > minAge.Value && c.Deposit < maxAge.Value);
                else if (minAge.HasValue)
                    customers = customers
                        .Where(c => c.Deposit > minAge.Value);
                else if (maxAge.HasValue)
                    customers = customers
                        .Where(c => c.Deposit < maxAge.Value);

                if (!string.IsNullOrEmpty(gender))
                    customers = customers
                        .Where(c => c.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase));

                return customers.ToList();
            }
        }
    }   
}
