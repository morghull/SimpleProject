using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            EntityPropreties = new Dictionary<string, Type>();
        }
    }
}
