using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleProject
{
    static class Program
    {
        /// <summary>
        /// Головна программа додатку
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();//системний метод, створюється за замовчуванням з файлом проекту
            Application.SetCompatibleTextRenderingDefault(false);//системний метод, створюється за замовчуванням з файлом проекту
            // Запуск головної форми
            Application.Run(new frmMain());

            // Також можете подивитись іншу форму з блоками
            //Application.Run(new frmBlocks());
        }
    }
}
