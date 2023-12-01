using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace SimpleProject.Helpers
{
    /// <summary>
    /// дженерік клас. зчитає xml-файл де повинні зберігатись дані щодо колекції сутностей
    /// не прив'язуючись до конкрутної реалізації сутності
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityXmlReader<T> where T : new()
    {
        /// <summary>
        /// прочитати xml-файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<T> Read(string fileName)
        {
            List<T> entities = new List<T>();//створити пустий список
            try
            {
                using (XmlReader xmlReader = XmlReader.Create(fileName))//створили так званий "читач"
                {
                    xmlReader.Read();//прочитати файл
                    XmlDocument xmlDocument = new XmlDocument();//створити пустий документ
                    xmlDocument.Load(xmlReader);//вивантажити прочитаний файлу у створений документ

                    XmlNode entityNodes = xmlDocument.DocumentElement;//рутовий елемент

                    foreach (XmlNode entityNode in entityNodes)//дочірні елементи до рутового
                    {
                        T entity = new T();//створення екземпляру сутності
                        foreach (XmlNode entityAttributeNode in entityNode.ChildNodes)//до кожного дочірнього елементу взяти його дочірні
                        {
                            string propertyName = entityAttributeNode.Name;//отримати ім'я властивості суності
                            string propertyValue = entityAttributeNode.InnerText;//отримати її значення

                            SetProperty(entity, propertyName, propertyValue);//наповнення властівості сутності значенням
                        }
                        entities.Add(entity);//додати сутність у колекцію
                    }
                }
            }
            catch (Exception ex)//обробка помилок
            {
                Console.WriteLine(String.Format("An error occurred: {0}", ex.Message));
            }
            return entities;
        }
        /// <summary>
        /// виконує наповнення властівості сутності значенням
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        private void SetProperty(T entity, string propertyName, string propertyValue)
        {
            var propertyInfo = typeof(T).GetProperty(propertyName);//отримати дескриптор властивості

            if (propertyInfo != null)
            {
                Type propertyType = propertyInfo.PropertyType;//отримати тип властивості
                object typedValue = Convert.ChangeType(propertyValue, propertyType, CultureInfo.InvariantCulture);//конвертація данних
                propertyInfo.SetValue(entity, typedValue);//наповнення данними властивості об'єкту сутності
            }
        }
    }
}
