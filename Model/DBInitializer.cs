using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Model
{
    public class DBInitializer : CreateDatabaseIfNotExists<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            IList<FieldType> defaultFieldTypes = new List<FieldType>();

            defaultFieldTypes.Add(new FieldType() { FieldTypeName = "SingleLineTextBox", IsActive = true});
            defaultFieldTypes.Add(new FieldType() { FieldTypeName = "MultiLineTextBox", IsActive = true});


            foreach (FieldType std in defaultFieldTypes)
                context.fieldType.Add(std);

            base.Seed(context);
        }


    }
    
}
