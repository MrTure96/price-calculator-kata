using PriceCalculator.Models;
using PriceCalculator.Services;

namespace PriceCalculator.Services
{
    public class ReportService
    {
        public string GenerateReport(Receipt receipt)
        {
            return receipt.ToString();
        }
    }
}
