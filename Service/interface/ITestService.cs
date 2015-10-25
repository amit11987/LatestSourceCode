using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface ITestService : IEntityService<Test>
    {
        Test GetById(long Id);
        void InsertORUpdateORDelete(Test test);
    }
}
