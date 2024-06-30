using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemicleTest.CSV.DataAccess.Models
{
    public class Customer
    {
        [Name("CUSTOMER_ID")]
        public int CustomerId { get; set; }

        [Name("Age")]
        public int Age { get; set; }

        [Name("Gender")]
        public string Gender { get; set; }

        [Name("City")]
        public string City { get; set; }

        [Name("Deposit")]
        public int Deposit { get; set; }

        [Name("NewCustomer")]
        public bool NewCustomer { get; set; }
    }
}
