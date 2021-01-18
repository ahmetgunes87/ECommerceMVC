using ECommerce.Business.Abstract;
using ECommerce.Business.ValidationRules.FluentValidation;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using Framework.Aspects.Postsharp.AuthorizationAspects;
using Framework.Aspects.Postsharp.CacheAspects;
using Framework.Aspects.Postsharp.TransactionAspects;
using Framework.Aspects.Postsharp.ValidationAspects;
using Framework.CrossCuttingConcerns.Caching.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(UserValidator))]
        public void Add(User user)
        {
            CheckUserNameValidate(user.Id, user.UserName);
            _userDal.Add(user);
        }

        //[SecuredOperation(Roles = "Admin")]
        //public void DeleteById(int id)
        //{
        //    var user = _userDal.Get(u => u.Id == id);
        //    _userDal.Update(user);
        //}

        [CacheAspect(typeof(MemoryCacheManager))]
        public User Get(Expression<Func<User, bool>> filter)
        {
            return _userDal.Get(filter);
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(u => u.UserName == userName & u.Password == password);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        //[SecuredOperation(Roles = "Admin")]
        public List<User> GetList(Expression<Func<User, bool>> filter = null)
        {
            return _userDal.GetList(filter).ToList();
        }

        public List<UserRoleItem> GetRoles(User user)
        {
            return _userDal.GetRoles(user);
        }

        [FluentValidationAspect(typeof(UserValidator))]
        public void Update(User user)
        {
            CheckUserNameValidate(user.Id, user.UserName);
            _userDal.Update(user);
        }

        public bool CheckUserNameValidate(int userId, string userName)
        {
            bool result = _userDal.CheckUserNameValidate(userId, userName);
            if (result)
            {
                throw new Exception(userName + " adlı kullanıcı sistemde zaten kayıtlı!");
            }
            return result;
        }

        public List<UserRoleName> GetUserRolesName(User user)
        {
            return _userDal.GetUserRolesName(user);
        }

        //public void AddUserRoles(List<UserRole> userRoles)
        //{
        //    _userDal.AddUserRoles(userRoles);
        //}

        //public void DeleteUserRoles(int userId)
        //{
        //    _userDal.DeleteUserRoles(userId);
        //}

        [TransactionScopeAspect]
        public void AddDeleteUserRolesTransaction(List<UserRole> userRoles, int userId)
        {
            _userDal.DeleteUserRoles(userId);
            _userDal.AddUserRoles(userRoles);
        }
    }
}
