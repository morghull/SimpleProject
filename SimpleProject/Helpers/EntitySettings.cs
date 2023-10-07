using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleProject.Helpers
{
    public class EntitySettings<T>
    {
        public string EntityName { get; set; }
        public string EntityPluralName { get; set; }
        public string XmlFilePath { get; set; }
        public Dictionary<string, Type> PropretiesTypes { get; set; }
        public List<string> PropertiesNames { get; set; }
        public List<string> PropertiesTitles { get; set; }
        public EntitySettings()
        {
            Type entityType = typeof(T);
            
            EntityName = entityType.Name;
            EntityPluralName = NounHelper.GetPluralForm(EntityName);
            XmlFilePath = String.Format(@"./{0}.xml", EntityPluralName);
            PropretiesTypes = new Dictionary<string, Type>();
            PropertiesNames = new List<string>();

            PropertyInfo[] properties = entityType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                PropretiesTypes.Add(property.Name, property.PropertyType);
                PropertiesNames.Add(property.Name);
            }
        }
    }
}
