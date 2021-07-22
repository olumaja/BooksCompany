using Books.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.FluentConfiguration
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            //Name of table

            //Primary key
            builder.HasKey(c => c.CompanyId);
            //Property configuration
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.StreetAddress).IsRequired();
            builder.Property(c => c.State).IsRequired();
            builder.Property(c => c.City).IsRequired();
            builder.Property(c => c.PhoneNumber).HasMaxLength(11).IsRequired();
            //Relationship
        }
    }
}
