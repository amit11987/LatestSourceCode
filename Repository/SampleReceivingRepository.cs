using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Repository
{
    public class SampleReceivingRepository : GenericRepository<SampleReceive>, ISampleReceivingRepository
    {
        public DbContext Context;
        public SampleReceivingRepository(DbContext context)
            : base(context)
        {
            this.Context = context;
        }

        public SampleReceive GetById(long SampleReceiveID)
        {
            return _dbset.Where(x => x.SampleReceiveID == SampleReceiveID).FirstOrDefault(); 
        }

        public void InsertORUpdateORDelete(SampleReceive sampleReceive)
        {
            var dtProductReceived = new DataTable();
            dtProductReceived.Columns.Add("ProductRecievedID",typeof(long));
            dtProductReceived.Columns.Add("Quantity",typeof(decimal));
            dtProductReceived.Columns.Add("UOMID", typeof(long));
            dtProductReceived.Columns.Add("ProductID", typeof(long));
            dtProductReceived.Columns.Add("SampleReceiveID", typeof(long));
            dtProductReceived.Columns.Add("CreatedDate", typeof(DateTime));
            dtProductReceived.Columns.Add("CreatedBy", typeof(long));
            dtProductReceived.Columns.Add("UpdatedDate", typeof(DateTime));
            dtProductReceived.Columns.Add("UpdatedBy", typeof(long));
            dtProductReceived.Columns.Add("IsActive", typeof(bool));

            for (int i = 0; i < sampleReceive.lstProductRecieved.Count; i++)
            {
                DataRow dr = dtProductReceived.NewRow();
                dr["ProductRecievedID"] = sampleReceive.lstProductRecieved[i].ProductRecievedID;
                dr["Quantity"] = sampleReceive.lstProductRecieved[i].Quantity;
                dr["UOMID"] = sampleReceive.lstProductRecieved[i].UOMID;
                dr["ProductID"] = sampleReceive.lstProductRecieved[i].ProductID;
                dr["SampleReceiveID"] = sampleReceive.lstProductRecieved[i].SampleReceiveID;
                dr["CreatedDate"] = DateTime.Now;
                dr["CreatedBy"] = sampleReceive.lstProductRecieved[i].CreatedBy;
                dr["UpdatedDate"] = DateTime.Now;
                dr["UpdatedBy"] = sampleReceive.lstProductRecieved[i].UpdatedBy;
                dr["IsActive"] = true;
                dtProductReceived.Rows.Add(dr);
            }


            var SampleTest = new DataTable();
            SampleTest.Columns.Add("SampleTestID", typeof(long));
            SampleTest.Columns.Add("TestID", typeof(long));
            SampleTest.Columns.Add("Repetition", typeof(int));
            SampleTest.Columns.Add("SampleReceiveID", typeof(long));
            SampleTest.Columns.Add("CreatedDate", typeof(DateTime));
            SampleTest.Columns.Add("CreatedBy", typeof(int));
            SampleTest.Columns.Add("UpdatedDate", typeof(DateTime));
            SampleTest.Columns.Add("UpdatedBy", typeof(int));
            SampleTest.Columns.Add("IsActive", typeof(bool));

            for (int i = 0; i < sampleReceive.lstSampleTest.Count; i++)
            {
                DataRow dr = SampleTest.NewRow();
                dr["SampleTestID"] = sampleReceive.lstSampleTest[i].SampleTestID;
                dr["TestID"] = sampleReceive.lstSampleTest[i].TestID;
                dr["Repetition"] = sampleReceive.lstSampleTest[i].Repetition;
                dr["SampleReceiveID"] = sampleReceive.lstSampleTest[i].SampleReceiveID;
                dr["CreatedDate"] = DateTime.Now;
                dr["CreatedBy"] = sampleReceive.lstSampleTest[i].CreatedBy;
                dr["UpdatedDate"] = DateTime.Now;
                dr["UpdatedBy"] = sampleReceive.lstSampleTest[i].UpdatedBy;
                dr["IsActive"] = true;
                SampleTest.Rows.Add(dr);
            }

            var productReceived = new SqlParameter("tblProductRecievedType", SqlDbType.Structured);
            productReceived.Value = dtProductReceived;
            productReceived.TypeName = "dbo.ProductRecievedType";

            var sampleTest = new SqlParameter("tblSampleTestType", SqlDbType.Structured);
            sampleTest.Value = SampleTest;
            sampleTest.TypeName = "dbo.SampleTestType";

            Context.Database.ExecuteSqlCommand("EXEC INSERT_UPDATE_DELETE_SampleReceive @SampleReceiveID,@SRID,@NoOfProductReceived,@NoOfTestRequired,@TargetDate,@CreatedDate,@CreatedBy,@UpdatedDate,@UpdatedBy,@IsActive,@tblProductRecievedType,@tblSampleTestType",
                       new SqlParameter("sampleReceiveID",sampleReceive.SampleReceiveID), 
                       new SqlParameter("sRID", sampleReceive.SRID), 
                       new SqlParameter("noOfProductReceived" ,sampleReceive.NoOfProductReceived),
                       new SqlParameter("noOfTestRequired", sampleReceive.NoOfTestRequired), 
                       new SqlParameter("targetDate", sampleReceive.TargetDate) , 
                       new SqlParameter("createdDate", DateTime.Now),
                       new SqlParameter("createdBy",  sampleReceive.CreatedBy),
                       new SqlParameter("updatedDate", DateTime.Now),
                       new SqlParameter("updatedBy",sampleReceive.UpdatedBy),
                       new SqlParameter("isActive", sampleReceive.IsActive), productReceived, sampleTest);
        }


        public SampleReceive GetBySRID(string SRID)
        {
            var a = _dbset.Where(x => x.SRID == SRID).FirstOrDefault();
            return a;
        }
    }
}
