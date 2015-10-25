using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface ISampleReceivingRepository : IGenericRepository<SampleReceive>
    {
        SampleReceive GetById(long SampleReceiveID);
        void InsertORUpdateORDelete(SampleReceive sampleReceive);
        SampleReceive GetBySRID(string SRID);
    }
}
