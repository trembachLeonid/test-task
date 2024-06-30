using GemicleTest.CSV.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemicleTest.CSV.DataAccess.DataAccess.Contracts
{
    public interface ICustomerDao
    {
        List<Customer> GetCustomers(
            int? minDeposit = null, int? maxDeposit = null,
            bool? isNewCustomer = null,
            string city = null,
            int? minAge = null,
            int? maxAge = null,
            string gender = null);
    }
}
