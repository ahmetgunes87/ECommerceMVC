﻿using ECommerce.Entities.Concrete;
using Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IRoleDal : IEntityRepository<Role>
    {
    }
}
