using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface ITestAllocationService : IEntityService<TestAllocation>
    {
        TestAllocation GetById(long Id);
        void InsertORUpdateORDelete(List<TestAllocation> lstTestAllocation);
    }
}
