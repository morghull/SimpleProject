using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.Helpers
{
    public class EntityPropertyOption
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public Type Type { get; set; }
        public bool IsMultiline { get; set; }
        public int ColumnWidth { get; set; }
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
