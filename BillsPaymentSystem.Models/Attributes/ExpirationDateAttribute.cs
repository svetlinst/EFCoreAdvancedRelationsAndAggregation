﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillsPaymentSystem.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExpirationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentDate = DateTime.Now;
            var expDate = (DateTime)value;

            if (expDate > currentDate)
            {
                return new ValidationResult("Card is expired");
            }

            return ValidationResult.Success;
        }
    }
}
