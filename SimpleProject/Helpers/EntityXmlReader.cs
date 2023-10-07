using System;
using System.Collections.Generic;
using System.Xml;

namespace SimpleProject.Helpers
{
    public class EntityXmlReader<T> where T : new()
    {
        public List<T> Read(string fileName)
        {
            List<T> entities = new List<T>();
            try
            {
                using (XmlReader xmlReader = XmlReader.Create(fileName))
                {
                    xmlReader.Read();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(xmlReader);

                    XmlNode entityNodes = xmlDocument.DocumentElement;

                    foreach (XmlNode entityNode in entityNodes)
                    {
                        T entity = new T();
                        foreach (XmlNode entityAttributeNode in entityNode.ChildNodes)
                        {
                            string propertyName = entityAttributeNode.Name;
                            string propertyValue = entityAttributeNode.InnerText;

                            SetProperty(entity, propertyName, propertyValue);
                        }
                        entities.Add(entity);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("An error occurred: {0}", ex.Message));
            }
            return entities;
        }
        private void SetProperty(T entity, string propertyName, string propertyValue)
        {
            var propertyInfo = typeof(T).GetProperty(propertyName);

            if (propertyInfo != null)
            {
                Type propertyType = propertyInfo.PropertyType;
                object typedValue = Convert.ChangeType(propertyValue, propertyType);
                propertyInfo.SetValue(entity, typedValue);
            }
        }
    }
}
