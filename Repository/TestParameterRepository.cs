using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Repository
{
    public class TestParameterRepository : GenericRepository<TestParameter>, ITestParameterRepository
    {

        public TestParameterRepository(DbContext context)
            : base(context)
        {
        }

        public void InsertORUpdateORDelete(long testID)
        {
            var test = _dbset.Where(x => x.TestID == testID).FirstOrDefault();
        }
    }
}
