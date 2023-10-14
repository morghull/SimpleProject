using SimpleProject.DataObjects;
using SimpleProject.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleProject
{
    /// <summary>
    /// головна форма проекту
    /// </summary>
    public partial class frmMain : Form
    {
        private EntitySettings<Patient> _entitySettings; //налаштування "сутності"
        private EntityHelper<Patient> _entityHelper; //хелпер "сутності"
        /// <summary>
        /// головний метод форми. ініціює форму
        /// також тут створюємо екземпляри класів налаштування та хелпера для нашої "сутності"
        /// особливу увагу необхідно звернути на класи хелпера та налуштувань
        /// вони є так званими дженерік класами, тобто при їх створенні передається тип "сутності"
        /// це дозволяє уникнути змін у цих класах якщо нам необхідно змінити нашу "сутність"
        /// тобто, наприклад, замість Patient ставимо Movie, і при цьому змін у дженерік класах робити не треба
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            _entitySettings = new EntitySettings<Patient>(); //містить налаштування "сутності"
            PatiensDataInitializer dataInitializer = new PatiensDataInitializer(); //використовується для створення початкових даних
            //MoviesDataInitializer dataInitializer = new MoviesDataInitializer();
            _entityHelper = new EntityHelper<Patient>(_entitySettings, dataInitializer); //використовується для маніпуляції з даними

            DataGridViewSetup();
            GetInitialData();
        }
        /// <summary>
        /// налаштування відображення гріду. саме тут варто змінювати колір чи відображення
        /// для встановлення тексту заголовку, стилю відображення та ширини використовується
        /// екземпляр класу налаштувань нашої "сутності"
        /// </summary>
        private void DataGridViewSetup()
        {
            _dataGridView.AutoGenerateColumns = false;
            _dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//для того щоб по кліку виділявся увесь рядок
            _dataGridView.ReadOnly = true;//для того щоб заборонити редагування даних у самому гріді
            _dataGridView.AllowUserToAddRows = false;//також для заборони редагування
            _dataGridView.RowHeadersVisible = false;//приховує заголовки рядків
            _dataGridView.AllowUserToResizeRows = false;//забороняє міняти висоту рядка у гріді
            _dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;//встановлення кольору для парних рядків
            foreach (EntityPropertyOption propOption in _entitySettings.PropertiesOptions)
            {
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.Format = (propOption.Type == typeof(DateTime)) ? "d" : "";//для даних типу DateTime встановлюємо спеціальний формат відображення типу ДД.ММ.ВВРР
                _dataGridView.Columns.Add(
                    new DataGridViewTextBoxColumn()//створюємо колонку у гріді
                    {
                        Name = propOption.Name,//назва колонки, використовується для прив'язки даних
                        HeaderText = propOption.Title,//заголовок
                        DefaultCellStyle = cellStyle,//стиль відображення
                        Width = propOption.ColumnWidth//ширина
                    });
            }
            _dataGridView.Columns[_dataGridView.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //остання колонка займає все вільне місце
        }
        /// <summary>
        /// створення початкових даних, щоб не вводити їх вручну
        /// створюються за допомогою хелпера нашої "сутності"
        /// </summary>
        private void GetInitialData()
        {
            _entityHelper.CreateInitialData();
            LoadData();
        }
        /// <summary>
        /// отримання даних для гріда
        /// у нашому випадку йде читання xml-файлу за допомогою хелпера нашої "сутності"
        /// </summary>
        private void LoadData()
        {
            BindingSource bindingSource = new BindingSource();//створення зв'язаного джерела даних
            DataTable dataTable = _entityHelper.GetDataAsDataTable(); //отримання даних

            bindingSource.DataSource = dataTable;//зв'язуємо джерело з отриманою таблицею

            _dataGridView.DataSource = bindingSource;//прив'язка джерела до гріда

            //прив'язка проперті даних до колонок гріда
            foreach (EntityPropertyOption propOption in _entitySettings.PropertiesOptions)
            {
                _dataGridView.Columns[propOption.Name].DataPropertyName = propOption.Name;
            }
        }
        /// <summary>
        /// зьереження даних з гріда у xml-файл
        /// за допомогою хелпера нашої "сутності"
        /// </summary>
        private void SaveData()
        {
            BindingSource bindingSource = (BindingSource)_dataGridView.DataSource;
            DataTable dataTable = (DataTable)bindingSource.DataSource;
            _entityHelper.SaveDataFromDataTale(dataTable);
        }
        /// <summary>
        /// клік на кнопку "зберегти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _toolStripButton_Save_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        /// <summary>
        /// клік на кнопку "оновити"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _toolStripButton_Load_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        /// <summary>
        /// клік на кнопку "додати"
        /// тут отримуємо пустий рядок для таблиці та відкривається допоміжна форма веденя запису
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _toolStripButton_Add_Click(object sender, EventArgs e)
        {
            BindingSource bindingSource = (BindingSource)_dataGridView.DataSource;//з гріда отримуємо пов'язане джерело даних
            DataTable dataTable = (DataTable)bindingSource.DataSource;//з джерела отримуємо таблицю з даними
            DataRow newRow = dataTable.NewRow();//отримуємо пустий рядок, рядок має структуру що відповідає структурі "сутності"

            //для кожного поля для рядка яке має тип дати треба проставити значення "за замовчуванням"
            //щоб далі у формі ведення при роботі з DateTimePicker не було помилок
            List<EntityPropertyOption> datePropOptions = _entitySettings.PropertiesOptions.FindAll((propOption) => { return propOption.Type == typeof(DateTime); });
            foreach (var propOption in datePropOptions)
            {
                newRow[propOption.Name] = new DateTime(1900, 1, 1);
            }
            //для кожного поля для рядка яке має тип числовий треба проставити значення "за замовчуванням"
            //щоб далі у формі ведення при роботі з NumericUpDown не було помилок
            List<EntityPropertyOption> intPropOptions = _entitySettings.PropertiesOptions.FindAll((propOption) => { return propOption.Type == typeof(int); });
            foreach (var propOption in intPropOptions)
            {
                newRow[propOption.Name] = 0;
            }

            //створюємо дочірню форму ведення даних у режимі додавання та передаємо
            //туди посилання на таблицю з даними, на новостворений рядок та на екземпляр налаштувань "сутності"
            frmSub subForm = new frmSub(FormOpenMode.Add, dataTable, newRow, _entitySettings);
            subForm.ShowDialog();//запускаємо форму у режимі діалогу, що забороняє іншу інтерактивність окрім щойно відкритої форми
        }
        /// <summary>
        /// клік на кнопку "змінити"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            BindingSource bindingSource = (BindingSource)_dataGridView.DataSource;//з гріда отримуємо пов'язане джерело даних
            DataTable dataTable = (DataTable)bindingSource.DataSource;//з джерела отримуємо таблицю з даними

            //для наступного блоку слід розуміти що рядок гріду і рядок даних що відповідає за збереження даних то є різні об'єкти
            //грід існує для відображення даних, що зберігаються у таблиці з даними
            DataGridViewSelectedRowCollection selectedRows = _dataGridView.SelectedRows;//отримуємо виділені рядки з гріду (їх може бути декілька)
            if (selectedRows.Count > 0)//перевірка на кількість
            {
                DataGridViewRow selectedRow = selectedRows[0];//вибираємо лише перший рядок гріду з виділених, вважаємо що користувач хотів редагувати саме його
                DataRowView selectedRowView = (DataRowView)selectedRow.DataBoundItem;
                DataRow selectedDataRow = selectedRowView.Row;//отримуємо виділений рядок з даними

                //створюємо дочірню форму ведення даних у режимі редагування та передаємо
                //туди посилання на таблицю з даними, на виділений рядок з даними та на екземпляр налаштувань "сутності"
                frmSub subForm = new frmSub(FormOpenMode.Edit, dataTable, selectedDataRow, _entitySettings);
                subForm.ShowDialog();//запускаємо форму у режимі діалогу, що забороняє іншу інтерактивність окрім щойно відкритої форми
            }
        }
        /// <summary>
        /// клік на кнопку "видалити"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _toolStripButton_Delete_Click(object sender, EventArgs e)
        {
            //відображаємо діалогове вікно з певним питанням. якщо користувач відповів "так" видаляємо рядки з гріду що виділений, а з ним і рядок з даними
            if (MessageBox.Show(this.ParentForm,
                    "Ви дійсно бажаєте видалити обрані рядки?",
                    Application.ProductName,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection selectedRows = _dataGridView.SelectedRows;//отримуємо виділені рядки з гріду (їх може бути декілька)
                foreach (DataGridViewRow row in selectedRows)//видаляємо рядки один за одним
                {
                    _dataGridView.Rows.Remove(row);
                }
            }
        }
        /// <summary>
        /// клік на кнопку "вийти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _toolStripButton_Exit_Click(object sender, EventArgs e)
        {
            //відображаємо діалогове вікно з певним питанням. якщо користувач відповів "так", то виходимо з додатку
            if (MessageBox.Show(
                    this.ParentForm,
                    "Ви дійсно бажаєте завершити роботу з програмою?",
                    Application.ProductName,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
