using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        bool CheckUserNameValidate(int userId, string userName);
        List<UserRoleName> GetUserRolesName(User user);
        List<UserRoleItem> GetRoles(User user);
        void AddUserRoles(List<UserRole> userRoles);
        void DeleteUserRoles(int userId);
    }
}
