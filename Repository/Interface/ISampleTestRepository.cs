using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interface
{
    public interface ISampleTestRepository : IGenericRepository<SampleTest>
    {
        SampleTest GetById(long sampleTestID);
    }
}
