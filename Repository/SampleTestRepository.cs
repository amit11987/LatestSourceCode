using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Repository
{
    public class SampleTestRepository : GenericRepository<SampleTest>, ISampleTestRepository
    {
        public SampleTestRepository(DbContext context)
            : base(context)
        {

        }

        public SampleTest GetById(long sampleTestID)
        {
            return _dbset.Where(x => x.SampleTestID == sampleTestID).FirstOrDefault();
        }
    }
}
