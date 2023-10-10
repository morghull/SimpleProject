using SimpleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SimpleProject.Helpers
{
    public class EntityHelper<T> where T : new()
    {
        private EntitySettings<T> _entitySettings;
        private IDataInitializer<T> _dataInitializer;

        public EntityHelper(EntitySettings<T> entitySettings, IDataInitializer<T> dataInitializer)
        {
            _entitySettings = entitySettings;
            _dataInitializer = dataInitializer;
        }
        public void CreateInitialData()
        {
            if (!File.Exists(_entitySettings.XmlFilePath))
            {
                List<T> initialEntities = _dataInitializer.GetInitialEntitiesList();

                SaveDataFromList(initialEntities);
            }
        }
        public DataTable GetDataAsDataTable()
        {
            List<T> entities = ReadFromXml();

            DataTable dataTable = CreateDataTableFromEntitiesList(entities);

            return dataTable;
        }
        public List<T> GetDataAsList()
        {
            return ReadFromXml();
        }
        public void SaveDataFromDataTale(DataTable dataTable)
        {
            SaveToXml(dataTable);
        }
        public void SaveDataFromList(List<T> list)
        {
            DataTable dataTable = CreateDataTableFromEntitiesList(list);
            SaveToXml(dataTable);
        }
        private List<T> ReadFromXml()
        {
            EntityXmlReader<T> xmlReader = new EntityXmlReader<T>();
            return xmlReader.Read(_entitySettings.XmlFilePath);
        }
        private void SaveToXml(DataTable dataTable)
        {
            DataSet dataSet = new DataSet(_entitySettings.EntityPluralName);

            dataSet.Tables.Add(dataTable);

            dataSet.WriteXml(_entitySettings.XmlFilePath);
        }
        private DataTable CreateDataTableFromEntitiesList(List<T> entities)
        {
            DataTable dataTable = new DataTable(_entitySettings.EntityName);

            foreach (EntityPropertyOption propOption in _entitySettings.PropertiesOptions)
            {
                dataTable.Columns.Add(propOption.Name, propOption.Type);
            }

            foreach (var entity in entities)
            {
                Type type = entity.GetType();
                List<PropertyInfo> properties = type.GetProperties().ToList();
                List<object> propertiesValues = new List<object>();
                properties.ForEach((prop) =>
                {
                    propertiesValues.Add(prop.GetValue(entity));
                });
                dataTable.Rows.Add(propertiesValues.ToArray());
            }

            return dataTable;
        }
    }
}
