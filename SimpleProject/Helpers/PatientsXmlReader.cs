using SimpleProject.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleProject.Helpers
{
    class PatientsXmlReader
    {
        public List<Patient> Read(string fileName)
        {
            List<Patient> patients = new List<Patient>();
            try
            {
                // Create an XmlReader for the XML file
                using (XmlReader xmlReader = XmlReader.Create(fileName))
                {
                    xmlReader.Read();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(xmlReader);

                    XmlNode patientNodes = xmlDocument.DocumentElement;

                    foreach (XmlNode patientNode in patientNodes)
                    {
                        Patient patient = new Patient();
                        foreach (XmlNode patientAttributeNode in patientNode.ChildNodes)
                        {
                            if (patientAttributeNode.Name == "FirstName")
                                patient.FirstName = patientAttributeNode.InnerText;
                            else if (patientAttributeNode.Name == "LastName")
                                patient.LastName = patientAttributeNode.InnerText;
                            else if (patientAttributeNode.Name == "Birthday")
                                patient.Birthday = DateTime.Parse(patientAttributeNode.InnerText);
                            else if (patientAttributeNode.Name == "RoomNo")
                                patient.RoomNo = int.Parse(patientAttributeNode.InnerText);
                            else if (patientAttributeNode.Name == "HomeAdress")
                                patient.HomeAdress = patientAttributeNode.InnerText;
                        }
                        patients.Add(patient);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("An error occurred: {0}", ex.Message));
            }
            return patients;
        }
    }
}
