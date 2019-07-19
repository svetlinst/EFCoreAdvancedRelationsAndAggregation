using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using BillsPaymentSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillsPaymentSystem.App
{
    public class DbInitializer
    {
        public static void Seed(BillsPaymentSystemContext context)
        {
            SeedUsers(context);
            SeedCreditCard(context);
            SeedBankAccount(context);
            SeedPaymentMethods(context);
            context.SaveChanges();
        }

        private static void SeedPaymentMethods(BillsPaymentSystemContext context)
        {
            var paymentMethods = new List<PaymentMethod>();

            for (int i = 1; i < 4; i++)
            {
                var paymentMethod = new PaymentMethod();
                Random rand = new Random();
                paymentMethod.UserId = i;
                paymentMethod.Type = (PaymentType)rand.Next(0, 1);
                if (i%3==0)
                {
                    paymentMethod.CreditCardId = i;
                    paymentMethod.BankAccountId = i;
                }
                else if (i%2==0)
                {
                    paymentMethod.BankAccountId = i;
                }
                else
                {
                    paymentMethod.CreditCardId = i;
                }

                if (IsValid(paymentMethod))
                {
                    paymentMethods.Add(paymentMethod);
                }
            }
            context.AddRange(paymentMethods);
        }

        private static void SeedBankAccount(BillsPaymentSystemContext context)
        {
            var bankAccounts = new List<BankAccount>();

            var bankNames = new List<string> {"UniCredit","FiBank","DSK","OBB" };
            var swiftCodes = new List<string> { "Test", "Test1", "Test2", "Test3"};

            foreach (var name in bankNames)
            {
                var curBankAccount = new BankAccount();
                curBankAccount.BankName = name;
                Random rand = new Random();
                curBankAccount.Balance = rand.Next(0, 1000000);
                curBankAccount.SwiftCode = swiftCodes[rand.Next(0,3)];
                if (IsValid(curBankAccount))
                {
                    bankAccounts.Add(curBankAccount);
                }
            }
            context.AddRange(bankAccounts);
        }

        private static void SeedCreditCard(BillsPaymentSystemContext context)
        {
            var creditCards = new List<CreditCard>();

            for (int i = 0; i < 4; i++)
            {
                var curCreditCard = new CreditCard();
                Random rand = new Random();
                curCreditCard.Limit = rand.Next(0, 10000);
                curCreditCard.MoneyOwed = rand.Next(0, 10000);
                DateTime today = DateTime.Now;
                curCreditCard.ExpirationDate = today.AddDays(rand.Next(0, 365));

                if (IsValid(curCreditCard))
                {
                    creditCards.Add(curCreditCard);
                }
            }
            context.CreditCards.AddRange(creditCards);
        }

        private static void SeedUsers(BillsPaymentSystemContext context)
        {
            var firstNames = new List<string> {"Pesho","Gosho","Stavri","Fichi" };
            var lastNames = new List<string> { "Petrov", "Georgiev", "Stavrev", "Filipov" };
            var emails = new List<string> { "123@abv.bg", "345@gmail.com", "697@mail.bg", "195@yahoo.com" };
            var passwords = new List<string> { "hash", "pass", "paspaspas", "ego" };
            var users = new List<User>();

            foreach (var name in firstNames)
            {
                var randUser = new User();
                Random rand = new Random();

                randUser.FirstName = name;
                randUser.LastName = lastNames[rand.Next(0,3)];
                randUser.Email = emails[rand.Next(0, 3)];
                randUser.Password = passwords[rand.Next(0, 3)];

                if (IsValid(randUser))
                {
                    users.Add(randUser);
                }
            }
            context.Users.AddRange(users);
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity,validationContext, validationResults, true);

            return isValid;
        }
    }
}
