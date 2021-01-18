using ECommerce.Business.Abstract;
using ECommerce.Business.ServiceAdapters;
using ECommerce.Business.ValidationRules.FluentValidation;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using Framework.Aspects.Postsharp.CacheAspects;
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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IKpsService _kpsService;
        public CustomerManager(ICustomerDal customerDal, IKpsService kpsService)
        {
            _customerDal = customerDal;
            _kpsService = kpsService;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(CustomerValidator))]
        public void Add(Customer customer)
        {
            CheckIfCustomerEmailExists(customer);
            //CheckIfCustomerIdentificationNumberExists(customer); TC Kimlik Kontrolü (veri tabanından)
            //CheckIfCustomerValidFromKps(customer); TC Kimlik ile Kullanıcı Kontrolü (servis ile mernis den)
            _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            return _customerDal.Get(filter);
        }

        public Customer GetByEmailAndPassword(string email, string password)
        {
            return _customerDal.Get(c => c.Email == email && c.Password == password);
        }

        public List<CustomerItem> GetListWithCityName()
        {
            return _customerDal.GetListWithCityName();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Customer> GetList(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.GetList(filter).ToList();
        }

        [FluentValidationAspect(typeof(CustomerValidator))]
        public void Update(Customer customer)
        {
            CheckIfCustomerEmailExists(customer);
            //CheckIfCustomerIdentificationNumberExists(customer); TC Kimlik Kontrolü (veri tabanından)
            //CheckIfCustomerValidFromKps(customer); TC Kimlik ile Kullanıcı Kontrolü (servis ile mernis den)
            _customerDal.Update(customer);
        }

        private void CheckIfCustomerEmailExists(Customer customer)
        {
            if (_customerDal.Get(c => c.Id != customer.Id && c.Email == customer.Email) != null)
            {
                throw new Exception(customer.Email + " e-mail adresli müşteri sistemde zaten kayıtlı!");
            }
        }

        private void CheckIfCustomerIdentificationNumberExists(Customer customer)
        {
            if (_customerDal.Get(c => c.Id != customer.Id && c.IdentificationNumber == customer.IdentificationNumber) != null)
            {
                throw new Exception(customer.IdentificationNumber + " TC kimlik nolu müşteri sistemde zaten kayıtlı!");
            }
        }

        private void CheckIfCustomerValidFromKps(Customer customer)
        {
            if (_kpsService.ValidateCustomer(customer) == false)
            {
                throw new Exception("Kullanıcı doğrulaması geçerli değil!");
            }
        }
    }
}
