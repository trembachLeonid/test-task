using CsvHelper.Configuration.Attributes;

namespace GemicleTest.CSV.DataAccess.Models
{
    public class Campaign
    {
        [Name("StartDate")]
        public DateTime StartDate { get; set; }

        [Name("Priority")]
        public int Priority { get; set; }
    }
}
