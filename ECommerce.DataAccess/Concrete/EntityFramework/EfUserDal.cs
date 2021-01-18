using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using Framework.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ECommerceDbContext>, IUserDal
    {
        public List<UserRoleName> GetUserRolesName(User user)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var result = (from r in context.Roles
                              join ur in context.UserRoles
                              on r.Id equals ur.RoleId
                              where ur.UserId == user.Id
                              select new UserRoleName
                              {
                                  RoleName = r.RoleName

                              }).ToList();
                return result;
            }
        }

        public List<UserRoleItem> GetRoles(User user)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var result = (from r in context.Roles
                              select new UserRoleItem{
                                  RoleId = r.Id,
                                  RoleName = r.RoleName,
                                  IsExist = (from ur in context.UserRoles.Where(x => x.RoleId == r.Id && x.UserId == user.Id)
                                             select new { ur.Id }).Any()
                              }).ToList();
                return result;
            }
        }

        public bool CheckUserNameValidate(int userId, string userName)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                bool result = context.Users.Where(u => u.Id != userId && u.UserName == userName).ToList().Any();
                return result;
            }
        }

        public void AddUserRoles(List<UserRole> userRoles)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                context.UserRoles.AddRange(userRoles);
                context.SaveChanges();
            }
        }
        public void DeleteUserRoles(int userId)
        {
            using(ECommerceDbContext context = new ECommerceDbContext())
            {
                var userRoles = context.UserRoles.Where(u => u.UserId == userId).ToList();
                context.UserRoles.RemoveRange(userRoles);
                context.SaveChanges();
            }
        }
    }
}
