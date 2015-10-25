using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Repository
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
       
        public TestRepository(DbContext context)
            : base(context)
        {
            _entities = context;
        }

        public Test GetById(long testID)
        {
           
            return _dbset.Where(x => x.TestID == testID).FirstOrDefault();
        }

        public void InsertORUpdateORDelete(Test test)
        {
            _entities.Entry(null);
            List<TestParameter> lstTestParameter = _dbset.Where(x => x.TestID == test.TestID).FirstOrDefault().TestParameters;


            List<TestParameter> deletedTestParameters = lstTestParameter.Where(y => !test.TestParameters.Any(z => z.TestParameterID == y.TestParameterID)).ToList();
            foreach (var deletedTestParameter in deletedTestParameters)
            {
                _entities.Entry(deletedTestParameter).State = EntityState.Deleted;
            }

            foreach (var testParameter in test.TestParameters)
            {

                if (testParameter.TestParameterID == 0)
                {
                    _entities.Entry(testParameter).State = EntityState.Added;
                    testParameter.TestID = test.TestID;                          
                }
                else
                {
                    _entities.Entry(testParameter).State = EntityState.Modified;
                }
            }
            _entities.Entry(test).State = EntityState.Modified;
            this.Save();
        }

       
    }
}
