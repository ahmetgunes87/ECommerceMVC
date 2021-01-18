using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IUserService
    {
        User Get(Expression<Func<User, bool>> filter);
        List<User> GetList(Expression<Func<User, bool>> filter = null);
        void Add(User product);
        void Update(User product);
        //void DeleteById(int id);
        User GetByUserNameAndPassword(string userName, string password);
        bool CheckUserNameValidate(int userId, string userName);
        List<UserRoleName> GetUserRolesName(User user);
        List<UserRoleItem> GetRoles(User user);
        //void AddUserRoles(List<UserRole> userRoles);
        //void DeleteUserRoles(int userId);
        void AddDeleteUserRolesTransaction(List<UserRole> userRoles, int userId);
    }
}
