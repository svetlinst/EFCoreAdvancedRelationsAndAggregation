﻿using System;
using System.Collections.Generic;

namespace BillsPaymentSystem.Models
{
    public class User
    {

        public User()
        {
            this.PaymentMethods = new List<PaymentMethod>();
        }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; }
    }
}
