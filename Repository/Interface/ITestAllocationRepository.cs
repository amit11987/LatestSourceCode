using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interface
{
    public interface ITestAllocationRepository : IGenericRepository<TestAllocation>
    {
        TestAllocation GetById(long id);
        void InsertORUpdateORDelete(List<TestAllocation> lstTestAllocation);
    }
}
