using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.Helpers
{
    /// <summary>
    /// для збереження Опцій властивостей класу сутності
    /// </summary>
    public class EntityPropertyOption
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public Type Type { get; set; }
        public bool IsMultiline { get; set; }
        public int ColumnWidth { get; set; }
        /// <summary>
        /// конструктор з початковими значеннями
        /// </summary>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <param name="isMultiline"></param>
        /// <param name="columnWidth"></param>
        public EntityPropertyOption(string name, string title, Type type, bool isMultiline, int columnWidth)
        {
            this.Name = name;
            this.Title = title;
            this.Type = type;
            this.IsMultiline = isMultiline;
            this.ColumnWidth = columnWidth;
        }
    }
}
