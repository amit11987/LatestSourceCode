using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Model
{
    public class Helper<T> where T : class
    {
        public static List<ClassMetadata> GetPropertyInfo()
        {
            Type t = typeof(T);
            List<ClassMetadata> lstPropertyInfo = new List<ClassMetadata>();
            foreach (var prop in t.GetProperties())
                lstPropertyInfo.Add(new ClassMetadata { PropertyName = prop.Name,DataType= prop.PropertyType.Name});
            return lstPropertyInfo;
        }

        public static IList<SelectListItem> GetGender(Type T)
        {
            List<ClassMetadata> lstPropertyInfo = GetPropertyInfo();
            IList<SelectListItem> _result = new List<SelectListItem>();
            foreach (ClassMetadata classMetadata in lstPropertyInfo)
            {
                _result.Add(new SelectListItem { Value = classMetadata.DataType, Text = classMetadata.PropertyName });
            }
            return _result;
        }

    }

    public class ClassMetadata
    {
        public string PropertyName { get; set; }
        public string DataType { get; set; }

    }

}
