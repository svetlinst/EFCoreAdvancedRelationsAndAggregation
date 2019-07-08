using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data
{
    public class BankAccountConfig:IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(x => x.BankAccountId);

            builder.HasOne(p => p.PaymentMethod).WithOne(b => b.BankAccount);

            builder.Property(b => b.BankName)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(s => s.SwiftCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
