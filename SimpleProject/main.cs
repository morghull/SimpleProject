using SimpleProject.DataObjects;
using SimpleProject.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SimpleProject
{
    public partial class main : Form
    {
        private EntityHelper _entityHelper;
        EntitySettings _entitySettings;
        public main()
        {
            InitializeComponent();
            _entitySettings = new EntitySettings("Patient");

            // Use reflection to get the property names
            Type entityType = typeof(Entity);
            PropertyInfo[] properties = entityType.GetProperties();

            // Extract and print the property names
            foreach (PropertyInfo property in properties)
            {
                _entitySettings.EntityPropreties.Add(property.Name, property.PropertyType);
            }

            _entityHelper = new EntityHelper(_entitySettings);
            GetInitialData();
        }

        private void _toolStripButton_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this.ParentForm, "Ви дійсно бажаєте завершити роботу з програмою?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        void GetInitialData()
        {
            _entityHelper.CreateInitialData();
            LoadData();
        }
        private void LoadData()
        {
            // Create a BindingSource
            BindingSource bindingSource = new BindingSource();

            // Get DataTable
            DataTable dataTable = _entityHelper.GetData();

            // Bind BindingSource to the DataTable
            bindingSource.DataSource = dataTable;

            // Torn off autogeneration of columns for DataGridView. We have predefined
            _dataGridView.AutoGenerateColumns = false;

            // Set the DataGridView selection mode to FullRowSelect
            _dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Bind the DataGridView to the BindingSource
            _dataGridView.DataSource = bindingSource;

            // Manually map DataGridView columns to DataTable columns
            foreach (var property in _entitySettings.EntityPropreties)
            {
                _dataGridView.Columns[property.Key].DataPropertyName = property.Key;
            }

            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridView.Columns[0].Width = 100;
            _dataGridView.Columns[1].Width = 100;
            _dataGridView.Columns[2].Width = 150;
            _dataGridView.Columns[3].Width = 120;

            _dataGridView.RowPrePaint += (sender, e) =>
            {
                if (e.RowIndex % 2 == 1) // Odd row
                {
                    // Set the background color for odd rows
                    _dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
            };

        }
        private void SaveData()
        {
            BindingSource bindingSource = (BindingSource)_dataGridView.DataSource;
            DataTable dataTable = (DataTable)bindingSource.DataSource;
            _entityHelper.SaveData(dataTable);
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
            if (MessageBox.Show(this.ParentForm, "Ви дійсно бажаєте видалити обрані рядки?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
    }
}
