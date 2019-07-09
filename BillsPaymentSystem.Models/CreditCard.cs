using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        public decimal Limit { get; set; }

        public decimal MoneyOwed { get; set; }

        public decimal LimitLeft { get; set; }

        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
