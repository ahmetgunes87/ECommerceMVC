﻿using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerItem> GetListWithCityName();
    }
}
