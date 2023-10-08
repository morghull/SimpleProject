using SimpleProject.DataObjects;
using SimpleProject.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleProject
{
    public partial class Mains : Form
    {
        private EntitySettings<Patient> _entitySettings;
        private EntityHelper<Patient> _entityHelper;
        public Mains()
        {
            InitializeComponent();
            _entitySettings = new EntitySettings<Patient>();
            _entitySettings.PropertiesTitles = new List<string>() {
                "Ім'я",
                "Прізвище",
                "Дата народження",
                "Номер палати",
                "Домашня адреса"
            };
            PatiensDataInitializer dataInitializer = new PatiensDataInitializer();
            _entityHelper = new EntityHelper<Patient>(_entitySettings, dataInitializer);

            DataGridViewSetup();
            GetInitialData();
        }
        private void DataGridViewSetup()
        {
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridView.AutoGenerateColumns = false;
            _dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dataGridView.ReadOnly = true;
            _dataGridView.AllowUserToAddRows = false;
            _dataGridView.RowHeadersVisible = false;
            _dataGridView.AllowUserToResizeRows = false;
            _dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            if (_entitySettings.PropertiesTitles.Count == _entitySettings.PropertiesNames.Count)
            {
                for (int i = 0; i < _entitySettings.PropertiesTitles.Count; i++)
                {
                    string propertyName = _entitySettings.PropertiesNames[i];
                    string propertyTitle = _entitySettings.PropertiesTitles[i];
                    Type propertyType = _entitySettings.PropretiesTypes[propertyName];
                    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                    cellStyle.Format = (propertyType == typeof(DateTime)) ? "d" : "";

                    _dataGridView.Columns.Add(
                        new DataGridViewTextBoxColumn()
                        {
                            Name = propertyName,
                            HeaderText = propertyTitle,
                            DefaultCellStyle = cellStyle
                        });
                }
            }
            else
            {
                throw new Exception("Some issue with user defined settings. Check your code");
            }
        }
        private void GetInitialData()
        {
            _entityHelper.CreateInitialData();
            LoadData();
        }
        private void LoadData()
        {
            BindingSource bindingSource = new BindingSource();
            DataTable dataTable = _entityHelper.GetDataAsDataTable();

            bindingSource.DataSource = dataTable;

            _dataGridView.DataSource = bindingSource;

            foreach (var propertyName in _entitySettings.PropertiesNames)
            {
                _dataGridView.Columns[propertyName].DataPropertyName = propertyName;
            }

            _dataGridView.Columns[0].Width = 100;
            _dataGridView.Columns[1].Width = 100;
            _dataGridView.Columns[2].Width = 150;
            _dataGridView.Columns[3].Width = 120;
        }
        private void SaveData()
        {
            BindingSource bindingSource = (BindingSource)_dataGridView.DataSource;
            DataTable dataTable = (DataTable)bindingSource.DataSource;
            _entityHelper.SaveDataFromDataTale(dataTable);
        }
        private void _toolStripButton_Save_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void _toolStripButton_Load_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void _toolStripButton_Add_Click(object sender, EventArgs e)
        {
            
        }
        private void _toolStripButton_Edit_Click(object sender, EventArgs e)
        {

        }
        private void _toolStripButton_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this.ParentForm,
                    "Ви дійсно бажаєте видалити обрані рядки?",
                    Application.ProductName,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) == DialogResult.Yes)
            {
                HashSet<int> uniqueRowIndexes = new HashSet<int>();
                foreach (DataGridViewCell cell in _dataGridView.SelectedCells)
                {
                    uniqueRowIndexes.Add(cell.RowIndex);
                }
                foreach (int rowIndex in uniqueRowIndexes)
                {
                    _dataGridView.Rows.RemoveAt(rowIndex);
                }
            }
        }
        private void _toolStripButton_Exit_Click(object sender, EventArgs e)
        {
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
