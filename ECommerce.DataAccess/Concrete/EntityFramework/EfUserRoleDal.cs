using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using Framework.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework
{
    public class EfUserRoleDal : EfEntityRepositoryBase<UserRole, ECommerceDbContext>, IUserRoleDal
    {
    }
}
