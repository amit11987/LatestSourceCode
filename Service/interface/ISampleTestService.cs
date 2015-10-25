using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface ISampleTestService : IEntityService<SampleTest>
    {
        SampleTest GetById(long Id);
    }
}
