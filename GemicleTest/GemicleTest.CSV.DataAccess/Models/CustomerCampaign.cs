using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemicleTest.CSV.DataAccess.Models
{
    public class CustomerCampaign
    {
        [Name("CustomerId")]
        public int CustomerId { get; set; }
    }
}
