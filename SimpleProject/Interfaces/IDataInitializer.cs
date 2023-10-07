using System.Collections.Generic;

namespace SimpleProject.Interfaces
{
    public interface IDataInitializer<T>
    {
        List<T> GetInitialEntitiesList();
    }
}
