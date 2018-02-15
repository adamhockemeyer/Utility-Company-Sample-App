using System;
namespace Utility.Models
{
    public class PaymentHistory
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
