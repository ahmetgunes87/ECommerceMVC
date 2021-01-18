using ECommerce.Business.KpsServiceReference;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.ServiceAdapters
{
    public class KpsServiceAdapter : IKpsService
    {
        public bool ValidateCustomer(Customer customer)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient();
            return client.TCKimlikNoDogrula(Convert.ToInt64(customer.IdentificationNumber), customer.FirstName.ToUpper(), customer.LastName.ToUpper(), customer.DateOfBirth.Value.Year);
        }
    }
}
