using ControleFinanceiro.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160);
        }
    }
}
