using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.Helpers
{
    /// <summary>
    /// клас для кастомних аннотацій, що описують опції для властивостей класу сутності
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class OptionsAttribute : Attribute
    {
        public readonly string Title;//для заголовку
        public bool IsMultiline { get; set; }//для визначення чи текст є довгим і йому потрібно розширяти текстове поле
        public int ColumnWidth { get; set; }//ширина колонки у гріді для відображення
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="title"></param>
        public OptionsAttribute(string title)
        {
            Title = title;
        }
    }
}
