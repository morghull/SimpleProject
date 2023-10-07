using SimpleProject.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace SimpleProject.Helpers
{
    public class EntityHelper
    {
        private EntitySettings _entitySettings;
        private string _xmlFileName;

        public EntityHelper(EntitySettings entitySettings, string xmlFileName)
        {
            _entitySettings = entitySettings;
            _xmlFileName = xmlFileName;
        }
        public void CreateInitialData()
        {
            if (!File.Exists(_xmlFileName))
            {
                List<Entity> initialEntities = EntityHelper.GetInitialEntitiesList();

                DataTable dataTable = CreateDataTableFromEntitiesList(initialEntities);

                SaveToXml(dataTable);
            }
        }
        public DataTable GetData()
        {
            List<Entity> patients = ReadFromXml();

            // Create DataTable to store patient data
            DataTable dataTable = CreateDataTableFromEntitiesList(patients);

            return dataTable;
        }
        public void SaveData(DataTable dataTable)
        {
            SaveToXml(dataTable);
        }

        private List<Entity> ReadFromXml()
        {
            EntityXmlReader xmlReader = new EntityXmlReader();
            return xmlReader.Read(_xmlFileName);
        }
        private void SaveToXml(DataTable dataTable)
        {
            // Create a DataSet and DataTable to store patient data
            DataSet dataSet = new DataSet("Patients");

            // Add the DataTable to the DataSet
            dataSet.Tables.Add(dataTable);

            dataSet.WriteXml(_xmlFileName);
        }
        private DataTable CreateDataTableFromEntitiesList(List<Entity> patients)
        {
            // Create DataTable to store patient data
            DataTable dataTable = new DataTable("Patient");

            // Define the columns for the DataTable
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Birthday", typeof(DateTime));
            dataTable.Columns.Add("RoomNo", typeof(int));
            dataTable.Columns.Add("HomeAdress", typeof(string));

            // Add rows to the DataTable from the list of patients
            foreach (var patient in patients)
            {
                dataTable.Rows.Add(patient.FirstName, patient.LastName, patient.Birthday, patient.RoomNo, patient.HomeAdress);
            }

            return dataTable;
        }
        private static List<Entity> GetInitialEntitiesList()
        {
            List<Entity> entities = new List<Entity>();

            // Define data for 20 different patients
            entities.Add(new Entity("Alice", "Smith", new DateTime(1990, 5, 15), 237, "123 Main St, Anytown, USA"));
            entities.Add(new Entity("John", "Doe", new DateTime(1985, 9, 20), 185, "456 Elm St, Smallville, USA"));
            entities.Add(new Entity("Sarah", "Johnson", new DateTime(1982, 12, 10), 302, "789 Oak St, Bigcity, USA"));
            entities.Add(new Entity("Michael", "Williams", new DateTime(1988, 7, 3), 124, "101 Pine St, Hometown, USA"));
            entities.Add(new Entity("Emily", "Brown", new DateTime(1992, 3, 25), 311, "222 Maple St, Suburbia, USA"));
            entities.Add(new Entity("Daniel", "Clark", new DateTime(1980, 11, 8), 149, "555 Cedar St, Metropolis, USA"));
            entities.Add(new Entity("Olivia", "Hall", new DateTime(1995, 6, 17), 201, "777 Birch St, Countryside, USA"));
            entities.Add(new Entity("Liam", "Adams", new DateTime(1987, 2, 14), 321, "888 Redwood St, Townsville, USA"));
            entities.Add(new Entity("Ava", "Wilson", new DateTime(1998, 9, 3), 289, "999 Elm St, Villageton, USA"));
            entities.Add(new Entity("Ethan", "Lee", new DateTime(1983, 4, 28), 134, "333 Oak St, Riverside, USA"));
            entities.Add(new Entity("Sophia", "Johnson", new DateTime(1991, 7, 12), 267, "444 Pine St, Lakeside, USA"));
            entities.Add(new Entity("Mia", "Smith", new DateTime(1986, 10, 7), 178, "666 Cedar St, Mountainside, USA"));
            entities.Add(new Entity("Noah", "Davis", new DateTime(1997, 1, 21), 294, "999 Birch St, Valleytown, USA"));
            entities.Add(new Entity("Isabella", "Wilson", new DateTime(1984, 8, 9), 132, "777 Cedar St, Brookville, USA"));
            entities.Add(new Entity("Logan", "Brown", new DateTime(1994, 2, 4), 312, "555 Oak St, Lakesville, USA"));
            entities.Add(new Entity("Lucas", "Hannah", new DateTime(1989, 12, 30), 209, "111 Elm St, Riversville, USA"));

            return entities;
        }
    }
}
