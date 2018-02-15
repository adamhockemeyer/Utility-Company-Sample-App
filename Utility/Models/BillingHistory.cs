using System;
namespace Utility.Models
{
    public class BillingHistory
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string PdfUrl { get; set; }
    }
}
