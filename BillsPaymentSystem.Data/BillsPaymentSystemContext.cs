﻿using BillsPaymentSystem.Data.EntityConfigurations;
using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BillsPaymentSystem.Data
{
    public class BillsPaymentSystemContext:DbContext
    {
        public BillsPaymentSystemContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfig());
            modelBuilder.ApplyConfiguration(new BankAccountConfig());
            modelBuilder.ApplyConfiguration(new CreditCardConfig());

        }
    }
}
