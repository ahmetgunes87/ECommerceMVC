using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework.Mappings
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            ToTable(@"Logs", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Detail).HasColumnName("Detail").IsRequired();
            Property(x => x.Date).HasColumnName("Date").IsRequired();
            Property(x => x.Audit).HasColumnName("Audit").IsRequired().HasMaxLength(50).HasColumnType("varchar");
        }
    }
}
