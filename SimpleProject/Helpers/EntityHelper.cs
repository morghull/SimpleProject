using SimpleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SimpleProject.Helpers
{
    /// <summary>
    /// хелпер що відповідає за обслуговування класу сутності
    /// </summary>
    /// <typeparam name="T">тип сутності</typeparam>
    public class EntityHelper<T> where T : new()
    {
        private EntitySettings<T> _entitySettings;//для збереження налаштувань сутності
        private IDataInitializer<T> _dataInitializer;//для збереження ініціалізатора даних
        private EntityXmlReader<T> _xmlReader = new EntityXmlReader<T>();//об'єкт, що допомагає читати з xml-файлу

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="entitySettings">налаштування сутності</param>
        /// <param name="dataInitializer">об'єкт ініціалізатор даних, для створення початкових значень сутності</param>
        public EntityHelper(EntitySettings<T> entitySettings, IDataInitializer<T> dataInitializer)
        {
            _entitySettings = entitySettings;
            _dataInitializer = dataInitializer;
        }
        /// <summary>
        /// створити початкові дані
        /// </summary>
        public void CreateInitialData()
        {
            //перевірка чи існує xml-файл, якщо ні то можемо створювати початкові дані
            //якщо існує, то дані вже створені раніше і нічого не робимо
            if (!File.Exists(_entitySettings.XmlFilePath))
            {
                List<T> initialEntities = _dataInitializer.GetInitialEntitiesList();//отримуємо початкові дані

                SaveDataFromList(initialEntities);//зберігаємо у файл
            }
        }
        /// <summary>
        /// отримати дані у вигляді таблиці даних
        /// </summary>
        /// <returns>таблиця з даними для сутності</returns>
        public DataTable GetDataAsDataTable()
        {
            List<T> entities = ReadFromXml();//прочитати з файлу, та отримати колекцію об'єктів

            DataTable dataTable = CreateDataTableFromEntitiesList(entities);//створити з колекції об'єктів таблицю

            return dataTable;
        }
        /// <summary>
        /// отримати дані у вигляді колекції обєктів для сутності
        /// </summary>
        /// <returns></returns>
        public List<T> GetDataAsList()
        {
            return ReadFromXml(); //читаємо з xml
        }
        /// <summary>
        /// зберегти дані з таблиці
        /// </summary>
        /// <param name="dataTable"></param>
        public void SaveDataFromDataTale(DataTable dataTable)
        {
            SaveToXml(dataTable); //записуємо у xml
        }
        /// <summary>
        /// зберегти дані з колекції список
        /// </summary>
        /// <param name="list"></param>
        public void SaveDataFromList(List<T> list)
        {
            DataTable dataTable = CreateDataTableFromEntitiesList(list); //отримуємо таблицю
            SaveToXml(dataTable);//записуємо у xml
        }
        /// <summary>
        /// прочитати з xml
        /// </summary>
        /// <returns>колекція у вигляді списка сутностей</returns>
        private List<T> ReadFromXml()
        {
            return _xmlReader.Read(_entitySettings.XmlFilePath);//читаємо з xml
        }
        /// <summary>
        /// зберегти таблицю у xml
        /// </summary>
        /// <param name="dataTable"></param>
        private void SaveToXml(DataTable dataTable)
        {
            DataSet dataSet = new DataSet(_entitySettings.EntityPluralName);//створюємо датасет з назвою сутності у множині (для кращого вигляду)

            dataSet.Tables.Add(dataTable);//додаємо у датасет таблицю

            dataSet.WriteXml(_entitySettings.XmlFilePath);//визиваємо вбудований метод збереження у xml
        }
        /// <summary>
        /// створити таблицю з колекції у вигляді списку об'єктів сутності
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        private DataTable CreateDataTableFromEntitiesList(List<T> entities)
        {
            DataTable dataTable = new DataTable(_entitySettings.EntityName);//створюємо таблицю

            //створюємо в таблиці колонки для кожної властивості нашого об'єкту, відповідно до налаштувань для нашої сутності
            foreach (EntityPropertyOption propOption in _entitySettings.PropertiesOptions)
            {
                dataTable.Columns.Add(propOption.Name, propOption.Type);
            }

            //перетворюємо список об'єктів сутностей на рядки таблиці
            foreach (var entity in entities)
            {
                Type type = entity.GetType();//отримуємо тип нашої сутності, щоб потім отримати доступ до її властивостей
                List<PropertyInfo> properties = type.GetProperties().ToList();//отримуємо дескриптори властивостей сутності
                List<object> propertiesValues = new List<object>();//список для збереження значень властивостей

                //отримуємо для кожної властивості їх значення
                properties.ForEach((prop) =>
                {
                    propertiesValues.Add(prop.GetValue(entity));
                });
                dataTable.Rows.Add(propertiesValues.ToArray());//створюємо рядок
            }

            return dataTable;
        }
    }
}
