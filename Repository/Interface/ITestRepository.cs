using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface ITestRepository : IGenericRepository<Test>
    {
        Test GetById(long id);
        void InsertORUpdateORDelete(Test test);
    }
}
