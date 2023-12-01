using SimpleProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.DataObjects
{
    public class Pharm
    {
        [Options("Назва", ColumnWidth = 300, IsMultiline = true)]
        public string Name { get; set; }

        [Options("Бренд", ColumnWidth = 150)]
        public string BrandName { get; set; }

        [Options("Форма випуску", ColumnWidth = 100)]
        public string ServingType { get; set; }

        [Options("Активні компоненти", ColumnWidth = 100, IsMultiline = true)]
        public string ActiveComponents { get; set; }

        [Options("Кількість в упаковці", ColumnWidth = 100)]
        public int PackSize { get; set; }

        [Options("Дозування", ColumnWidth = 100, IsMultiline = true)]
        public string Dose { get; set; }
        [Options("Ціна", ColumnWidth = 100)]
        public decimal Price { get; set; }

        [Options("Виробник", ColumnWidth = 100)]
        public string ManufacturerName { get; set; }

        [Options("Країна виробника", ColumnWidth = 100)]
        public string ManufacturerCountry { get; set; }

        public Pharm() { }

        public Pharm(
                string name
                , string brandName
                , string servingType
                , string activeCompopents
                , int packSize
                , string dose
                , decimal price
                , string manufacturerName
                , string manufacturerCountry
                )
        {
            Name = name;
            BrandName = brandName;
            ServingType = servingType;
            ActiveComponents = activeCompopents;
            PackSize = packSize;
            Dose = dose;
            Price = price;
            ManufacturerName = manufacturerName;
            ManufacturerCountry = manufacturerCountry;
        }
    }
}
