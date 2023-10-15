using System;
using SimpleProject.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SimpleProject.Interfaces;

namespace SimpleProject
{
    /// <summary>
    /// дочірня форма для ведення запису
    /// </summary>
    public partial class frmSub : Form
    {
        private FormOpenMode _openMode; //режим відкриття форми
        private DataTable _dataTable; //таблиця що редагується, використовується для збереження даних
        private DataRow _dataRow; //рядок з даними
        private List<EntityPropertyOption> _propOptions; //налаштування

        //для зберігання контролів (елементів форми з якими взаємодіє користувач), що містять безпосередньо дані
        //використовується для отримання даних, зо ввів користувач
        private Dictionary<EntityPropertyOption, Control> _dataControls = new Dictionary<EntityPropertyOption, Control>();
        /// <summary>
        /// ініціалізація форми
        /// </summary>
        /// <param name="openMode">режим відкриття "на додавання" або "на редагування"</param>
        /// <param name="dataTable">таблиця з даними</param>
        /// <param name="dataRow">рядок з даними</param>
        /// <param name="properties">налаштування</param>
        public frmSub(FormOpenMode openMode, DataTable dataTable, DataRow dataRow, IPropertiesOption properties)
        {
            InitializeComponent();
            //нижче - збереження параметрів, що отримали при запуску форми
            _openMode = openMode;
            _dataTable = dataTable;
            _dataRow = dataRow;
            _propOptions = properties.GetPropertiesOptions(); //отримуємо налаштування

            //тут концепція така: динамічно створюються елементи на формі під кожна властивість класу "сутності"
            //для кожної властивості створюється блок Panel шириною у всю форму
            //ці блоки розмішаються в стовчик один під одним
            //у кожному блоку створюється заголовок Label, та контрол для даних, в залежності від типу
            //контроли можуть бути наступні: TextBox для тексту, NumericUpDown для чисел, DateTimePicker для дати

            int yCoordPanelDelta = _toolStrip.Height + 20; //змінна для підрахунку вертикального зміщення кожного блоку
            //int colorDelta = 0; //можна розкоментувати для того щоб видно було як блоки розміщаються
            int formBorderThickness = 16; //товщина країв самої форми, яку треба відняти для підрахунку ширини блоку
            int panelWidth = this.Width - formBorderThickness; //підрахунок ширини блоку

            //цикл для кожної опції налаштувань
            foreach (EntityPropertyOption propOption in _propOptions)
            {
                //colorDelta += 25; //можна розкоментувати для того щоб видно було як блоки розміщаються
                
                //створення контейнера
                Panel panel = new Panel();
                //panel.BackColor = Color.FromArgb(255, colorDelta, colorDelta, colorDelta); //можна розкоментувати для того щоб видно було як блоки розміщаються
                panel.Width = panelWidth;
                panel.Height = 40;
                panel.Left = 0;
                panel.Top = yCoordPanelDelta;

                //створення заголовку
                Label label = new Label() { Text = propOption.Title };
                label.TextAlign = ContentAlignment.TopRight;
                label.Top = 2;
                label.Width = 110;
                label.Height = 40;
                //label.ForeColor = Color.White; //можна розкоментувати для того щоб видно було як блоки розміщаються
                panel.Controls.Add(label);// додаємо щаголовок до контейнеру

                //в залежності від типу властивості "сутності" створюємо той чи інший контрол
                Type dataType = propOption.Type; //визначаэмо тип
                Control dataControl = null; //необхідна для того, щоб потім зберегти цей контрол у колекцію
                if (dataType == typeof(string))//для тексту
                {
                    TextBox textBox = new TextBox();
                    textBox.Text = dataRow[propOption.Name].ToString();

                    if (propOption.IsMultiline)//якщо текст у нас довгий, то робимо текстове поле більшим
                    {
                        textBox.Multiline = true;
                        textBox.Height *= 2;
                        textBox.Width *= 2;
                    }

                    dataControl = textBox;
                }
                else if (dataType == typeof(int))//для чисел
                {
                    NumericUpDown numericUpDown = new NumericUpDown();
                    numericUpDown.Minimum = 0;
                    numericUpDown.Maximum = 99999;
                    numericUpDown.Value = (int)dataRow[propOption.Name];


                    dataControl = numericUpDown;
                }
                else if (dataType == typeof(DateTime))//для дати
                {
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    dateTimePicker.Value = (DateTime)dataRow[propOption.Name];

                    dataControl = dateTimePicker;
                }

                if (dataControl != null)
                {
                    dataControl.Left = label.Width + 5;//позиціювання
                    dataControl.Top = 0;//позиціювання
                    _dataControls.Add(propOption, dataControl); //зберігаємо наш контрол у колекцію, це знадобиться потім для отримання змінених користувачем даних
                    panel.Controls.Add(dataControl);//додаємо контрол до контейнеру
                }

                yCoordPanelDelta += panel.Height;//визначаємо вертикальне зміщення для наступного контейнеру
                this.Controls.Add(panel);//додаємо контейнер на форму
            }

            this.Height = yCoordPanelDelta + _toolStrip.Height + 20;//визначаємо результуючу висоту форми
        }
        //клік на кнопці "підтвердити"
        private void _toolStripButton_Ok_Click(object sender, EventArgs e)
        {
            //ось тут і знадобилась колекція контролів де користувач вносить зміни
            //для кожного такого контролу визначаємо тип і в залежності від типу
            //вносимо нові значення у рядок, що тримали при ініціалізації форми
            //примітка: при створенні нового запису ми отримали пустий рядок,
            //         а при редагуванні - рядок, що вибрав користувач
            foreach (var dataControl in _dataControls)
            {
                EntityPropertyOption propOption = dataControl.Key;
                Control control = dataControl.Value;

                Type dataType = propOption.Type;
                if (dataType == typeof(string))//якщо текст
                {
                    _dataRow[propOption.Name] = ((TextBox)control).Text;
                }
                else if (dataType == typeof(DateTime))//якщо дата
                {
                    _dataRow[propOption.Name] = ((DateTimePicker)control).Value;
                }
                else if (dataType == typeof(int))//якщо число
                {
                    _dataRow[propOption.Name] = ((NumericUpDown)control).Value;
                }
            }
            //окремий випадок для нового рядка
            //новий рядок треба додати до таблиці
            if (_openMode == FormOpenMode.Add)
            {
                _dataTable.Rows.Add(_dataRow);//додаємо до таблиці
            }

            this.Close();//закриваємо форму
        }
        //клік на кнопці "вийти"
        private void _toolStripButton_No_Click(object sender, EventArgs e)
        {
            this.Close();//закриваємо форму
        }
    }
}
