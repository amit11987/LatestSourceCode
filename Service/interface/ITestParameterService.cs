using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{

    public interface ITestParameterService : IEntityService<TestParameter>
    {
        void InsertORUpdateORDelete(long testID);
    }
}
