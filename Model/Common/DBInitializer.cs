using System.Data.Entity;


namespace Model
{
    public class DBInitializer : CreateDatabaseIfNotExists<EFContext>
    {
        protected override void Seed(EFContext context)
        {

        }
    }
}
