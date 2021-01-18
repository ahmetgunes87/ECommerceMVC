using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.UserName).HasColumnName("UserName").IsRequired().HasMaxLength(50).HasColumnType("varchar");
            Property(x => x.Password).HasColumnName("Password").IsRequired().HasMaxLength(30).HasColumnType("varchar");
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50).HasColumnType("varchar");
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50).HasColumnType("varchar");
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(50).HasColumnType("varchar");
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
        }
    }
}
