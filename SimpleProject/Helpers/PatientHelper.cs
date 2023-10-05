using SimpleProject.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.Helpers
{
    public class PatientHelper
    {

        private static List<Patient> GetInitialPatientsList()
        {
            List<Patient> patients = new List<Patient>();

            // Define data for 20 different patients
            patients.Add(new Patient("Alice", "Smith", new DateTime(1990, 5, 15), 237, "123 Main St, Anytown, USA"));
            patients.Add(new Patient("John", "Doe", new DateTime(1985, 9, 20), 185, "456 Elm St, Smallville, USA"));
            patients.Add(new Patient("Sarah", "Johnson", new DateTime(1982, 12, 10), 302, "789 Oak St, Bigcity, USA"));
            patients.Add(new Patient("Michael", "Williams", new DateTime(1988, 7, 3), 124, "101 Pine St, Hometown, USA"));
            patients.Add(new Patient("Emily", "Brown", new DateTime(1992, 3, 25), 311, "222 Maple St, Suburbia, USA"));
            patients.Add(new Patient("Daniel", "Clark", new DateTime(1980, 11, 8), 149, "555 Cedar St, Metropolis, USA"));
            patients.Add(new Patient("Olivia", "Hall", new DateTime(1995, 6, 17), 201, "777 Birch St, Countryside, USA"));
            patients.Add(new Patient("Liam", "Adams", new DateTime(1987, 2, 14), 321, "888 Redwood St, Townsville, USA"));
            patients.Add(new Patient("Ava", "Wilson", new DateTime(1998, 9, 3), 289, "999 Elm St, Villageton, USA"));
            patients.Add(new Patient("Ethan", "Lee", new DateTime(1983, 4, 28), 134, "333 Oak St, Riverside, USA"));
            patients.Add(new Patient("Sophia", "Johnson", new DateTime(1991, 7, 12), 267, "444 Pine St, Lakeside, USA"));
            patients.Add(new Patient("Mia", "Smith", new DateTime(1986, 10, 7), 178, "666 Cedar St, Mountainside, USA"));
            patients.Add(new Patient("Noah", "Davis", new DateTime(1997, 1, 21), 294, "999 Birch St, Valleytown, USA"));
            patients.Add(new Patient("Isabella", "Wilson", new DateTime(1984, 8, 9), 132, "777 Cedar St, Brookville, USA"));
            patients.Add(new Patient("Logan", "Brown", new DateTime(1994, 2, 4), 312, "555 Oak St, Lakesville, USA"));
            patients.Add(new Patient("Lucas", "Hannah", new DateTime(1989, 12, 30), 209, "111 Elm St, Riversville, USA"));

            return patients;
        }
        public static void CreateXmlWithInitialData(string fileName, string dataMemerName)
        {
            var initialPatients = PatientHelper.GetInitialPatientsList();

            // Create a DataSet and DataTable to store patient data
            DataSet dataSet = new DataSet("Patients");
            DataTable dataTable = new DataTable(dataMemerName);

            // Define the columns for the DataTable
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Birthday", typeof(DateTime));
            dataTable.Columns.Add("RoomNo", typeof(int));
            dataTable.Columns.Add("HomeAdress", typeof(string));

            // Add rows to the DataTable from the list of patients
            foreach (var patient in initialPatients)
            {
                dataTable.Rows.Add(patient.FirstName, patient.LastName, patient.Birthday, patient.RoomNo, patient.HomeAdress);
            }

            // Add the DataTable to the DataSet
            dataSet.Tables.Add(dataTable);

            dataSet.WriteXml(fileName);
        }
    }
}
