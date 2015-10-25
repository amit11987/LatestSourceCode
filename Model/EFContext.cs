using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class EFContext : DbContext
    {

        public EFContext()
            : base("Name=EFContext")
        {
            Database.SetInitializer<EFContext>(new CreateDatabaseIfNotExists<EFContext>());
            //Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }
      
        public DbSet<Product> Product{ get; set; }
        public DbSet<Test> test { get; set; }
        public DbSet<SOP> sop { get; set; }
        public DbSet<FieldType> fieldType { get; set; }
        public DbSet<UOM> uom { get; set; }
        public DbSet<SampleReceive> sampleReceive { get; set; }
        public DbSet<TestAllocation> testAllocation { get; set; }
        public DbSet<DropDownList> DropDownList { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> userGroup { get; set; }
        public DbSet<UserGroupAssign> userGroupAssign { get; set; }
        public DbSet<TestAllocationUserGroup> testAllocationUserGroup { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        //// TODO Set Created by and Updated By
                        entity.CreatedBy = 0;
                        entity.CreatedDate = now;
                        entity.IsActive = true;
                    }
                    else {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                        base.Entry(entity).Property(x => x.IsActive).IsModified = false;     
                    }
                    entity.UpdatedBy = 0;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UOM>().Property(x => x.UOMMapping).HasPrecision(14, 4);

            base.OnModelCreating(modelBuilder);
        }
    }    
}
