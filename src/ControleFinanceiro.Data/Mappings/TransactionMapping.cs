using ControleFinanceiro.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.TransactionType)
                .HasColumnType("SMALLINT")
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnType("MONEY");

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.PaidOrReceivedAt)
                 .IsRequired(false);

            builder.Property(x => x.UserId)
                  .IsRequired()
                  .HasColumnType("VARCHAR")
                  .HasMaxLength(255);
        }
    }
}
