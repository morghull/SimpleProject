using System;
using System.Collections.Generic;

namespace SimpleProject.Helpers
{
    public class EntitySettings
    {
        public string EntityName { get; set; }
        public string EntityPluralName { get; set; }
        public string XmlFilePath { get; set; }
        public Dictionary<string, Type> EntityPropreties { get; set; }
        public EntitySettings(string entityName)
        {
            EntityName = entityName;
            EntityPluralName = NounHelper.GetPluralForm(entityName);
            XmlFilePath = String.Format(@"./{0}.xml", EntityPluralName);
            EntityPropreties = new Dictionary<string, Type>();
        }
    }
}
