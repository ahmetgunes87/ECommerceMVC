using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.ServiceAdapters
{
    public interface IKpsService
    {
        bool ValidateCustomer(Customer customer);
    }
}
