﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IFieldTypeService : IEntityService<FieldType>
    {
        IEnumerable<FieldType> GetAllByIsActive(bool IsActive);
    }
}
