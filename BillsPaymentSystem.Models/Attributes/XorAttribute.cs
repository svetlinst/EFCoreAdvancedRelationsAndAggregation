using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillsPaymentSystem.Data
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XorAttribute : ValidationAttribute
    {
        private string targetProperty;

        public XorAttribute(string targetProperty)
        {
            this.targetProperty = targetProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetAttribute = validationContext.ObjectType
                .GetProperty(targetProperty)
                .GetValue(validationContext.ObjectInstance);

            if ((targetAttribute==null) ^ (value==null))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("The two properties must have opposite values!");

        }
    }
}
