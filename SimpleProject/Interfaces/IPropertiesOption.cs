using SimpleProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.Interfaces
{
    public interface IPropertiesOption
    {
        List<EntityPropertyOption> GetPropertiesOptions();
    }
}
