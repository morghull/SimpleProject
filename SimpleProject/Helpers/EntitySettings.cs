using SimpleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SimpleProject.Helpers
{
    /// <summary>
    /// містить налаштування сутності.
    /// при створені об'єкту екземпляру цього класу йде зчитування
    /// опцій для кожної властивості класу сутності
    /// також йде збереження базових налаштувань таких як шлях до xml-файлу,
    /// назва сутності в однині та в множині
    /// також реалізує інтерфейс IPropertiesOption, щоб була змога
    /// отримати список опцій не прив'язуючись до реалізації під конкретну сутність
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntitySettings<T> : IPropertiesOption
    {
        public string EntityName { get; set; }//назва сутності у однині
        public string EntityPluralName { get; set; }//назва сутності у множині
        public string XmlFilePath { get; set; }//шлях до xml-файлу
        public List<EntityPropertyOption> PropertiesOptions { get; set; }//список опцій для кожної властивості класу сутності
        /// <summary>
        /// конструктор
        /// </summary>
        public EntitySettings()
        {
            Type entityType = typeof(T);//визначаємо тип сутності

            EntityName = entityType.Name;//визначаємо назва сутності
            EntityPluralName = NounHelper.GetPluralForm(EntityName);//визначаємо назву у множині
            XmlFilePath = String.Format(@"./{0}.xml", EntityPluralName);//визначаємо шлях до файлу
            PropertiesOptions = new List<EntityPropertyOption>();//створюємо пустий список для опцій

            PropertyInfo[] properties = entityType.GetProperties();//отримуємо список дескрипторів властивостей сутності

            //для кожної властивості створ.ємо опції зчитуючи анотації та дескриптор властивості
            foreach (PropertyInfo property in properties)
            {
                //зчитаємо опції з аннотації
                var optionsAttribute = (OptionsAttribute)Attribute.GetCustomAttribute(property, typeof(OptionsAttribute));
                //наповнюємо список опцій
                PropertiesOptions.Add(new EntityPropertyOption(
                    property.Name,
                    optionsAttribute.Title,
                    property.PropertyType,
                    optionsAttribute.IsMultiline,
                    optionsAttribute.ColumnWidth
                    ));
            }
        }
        /// <summary>
        /// отримати список опцій для властивостей сутності
        /// </summary>
        /// <returns></returns>
        public List<EntityPropertyOption> GetPropertiesOptions()
        {
            return PropertiesOptions;
        }
    }
}
