using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.Interfaces
{
    public interface IProperties
    {
        List<string> GetPropertiesNames();
        Dictionary<string, Type> GetPropretiesTypes();
        Dictionary<string, string> GetPropertiesTitles();
    }
}
