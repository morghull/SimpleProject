using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.Helpers
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class OptionsAttribute : Attribute
    {
        public readonly string Title;
        public bool IsMultiline { get; set; }
        public int ColumnWidth { get; set; }
        public OptionsAttribute(string title)
        {
            Title = title;
        }
    }
}
