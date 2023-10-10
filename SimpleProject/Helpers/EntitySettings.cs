using SimpleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SimpleProject.Helpers
{
    public class EntitySettings<T> : IPropertiesOption
    {
        public string EntityName { get; set; }
        public string EntityPluralName { get; set; }
        public string XmlFilePath { get; set; }
        public List<EntityPropertyOption> PropertiesOptions { get; set; }
        public EntitySettings()
        {
            Type entityType = typeof(T);

            EntityName = entityType.Name;
            EntityPluralName = NounHelper.GetPluralForm(EntityName);
            XmlFilePath = String.Format(@"./{0}.xml", EntityPluralName);
            PropertiesOptions = new List<EntityPropertyOption>();

            PropertyInfo[] properties = entityType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var titleAttribute = (OptionsAttribute)Attribute.GetCustomAttribute(property, typeof(OptionsAttribute));
                PropertiesOptions.Add(new EntityPropertyOption(property.Name, titleAttribute.Title, property.PropertyType, titleAttribute.IsMultiline));
            }
        }
        public List<EntityPropertyOption> GetPropertiesOptions()
        {
            return PropertiesOptions;
        }
    }
}
