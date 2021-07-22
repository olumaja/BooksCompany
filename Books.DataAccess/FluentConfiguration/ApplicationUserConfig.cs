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
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            //Table name

            //Primary Key
            
            //Property configuration
            builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
            builder.Property(a => a.StreetAddress).IsRequired();
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.State).IsRequired();
            builder.Property(a => a.PostalCode).HasMaxLength(15);
            builder.Ignore(a => a.Role);
            //Relationship
            builder.HasOne(a => a.Company).WithMany(c => c.ApplicationUsers).HasForeignKey(a => a.CompanyId);
        }
    }
}
