﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IProductReceivedService : IEntityService<ProductRecieved>
    {
        ProductRecieved GetById(long Id);
    }
}