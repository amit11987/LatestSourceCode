using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Repository
{
    public class TestAllocationRepository : GenericRepository<TestAllocation>, ITestAllocationRepository
    {
        public DbContext Context;
       public TestAllocationRepository(DbContext context)
            : base(context)
        {
            this.Context = context;
        }

       public TestAllocation GetById(long testAllocationId)
       {

           return _dbset.Where(x => x.TestAllocationID == testAllocationId).FirstOrDefault();
       }

       public void InsertORUpdateORDelete(List<TestAllocation> lstTestAllocation)
       {
           var dtTestAllocation = new DataTable();
           dtTestAllocation.Columns.Add("TestAllocationID", typeof(long));
           dtTestAllocation.Columns.Add("TargetDate", typeof(DateTime));
           dtTestAllocation.Columns.Add("SampleReceiveID", typeof(long));
           dtTestAllocation.Columns.Add("SRID", typeof(string));
           dtTestAllocation.Columns.Add("TestID", typeof(long));
           dtTestAllocation.Columns.Add("Status", typeof(string));
           dtTestAllocation.Columns.Add("AllocatedTo", typeof(string));
           dtTestAllocation.Columns.Add("QtyOfProduct", typeof(string));
           dtTestAllocation.Columns.Add("UOMID", typeof(long));
           dtTestAllocation.Columns.Add("CreatedDate", typeof(DateTime));
           dtTestAllocation.Columns.Add("CreatedBy", typeof(long));
           dtTestAllocation.Columns.Add("UpdatedDate", typeof(DateTime));
           dtTestAllocation.Columns.Add("UpdatedBy", typeof(long));
           dtTestAllocation.Columns.Add("IsActive", typeof(bool));

           for (int i = 0; i < lstTestAllocation.Count; i++)
           {
               DataRow dr = dtTestAllocation.NewRow();
               dr["TestAllocationID"] = lstTestAllocation[i].TestAllocationID;
               dr["TargetDate"] = lstTestAllocation[i].TargetDate;
               dr["SampleReceiveID"] = lstTestAllocation[i].SampleReceiveID;
               dr["SRID"] = lstTestAllocation[i].SRID;
               dr["TestID"] = lstTestAllocation[i].TestID;
               dr["Status"] = lstTestAllocation[i].Status;
              // dr["AllocatedTo"] = lstTestAllocation[i].AllocatedTo;
               dr["QtyOfProduct"] = lstTestAllocation[i].QtyOfProduct;
               dr["UOMID"] = lstTestAllocation[i].UOMID;
               dr["CreatedDate"] = DateTime.Now;
               dr["CreatedBy"] = lstTestAllocation[i].CreatedBy;
               dr["UpdatedDate"] = DateTime.Now;
               dr["UpdatedBy"] = lstTestAllocation[i].UpdatedBy;
               dr["IsActive"] = true;
               dtTestAllocation.Rows.Add(dr);
           }



           var productReceived = new SqlParameter("tblTestAllocationType", SqlDbType.Structured);
           productReceived.Value = dtTestAllocation;
           productReceived.TypeName = "dbo.TestAllocationType";



           Context.Database.ExecuteSqlCommand("EXEC INSERT_UPDATE_DELETE_TestAllocation @tblTestAllocationType", productReceived);
       }

    }
}
