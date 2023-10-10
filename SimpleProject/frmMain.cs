﻿using SimpleProject.DataObjects;
using SimpleProject.Helpers;
using SimpleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleProject
{
    public partial class frmMain : Form
    {
        private EntitySettings<Patient> _entitySettings;
        private EntityHelper<Patient> _entityHelper;
        public frmMain()
        {
            InitializeComponent();
            _entitySettings = new EntitySettings<Patient>();
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
            foreach (EntityPropertyOption propOption in _entitySettings.PropertiesOptions)
            {
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.Format = (propOption.Type == typeof(DateTime)) ? "d" : "";
                _dataGridView.Columns.Add(
                    new DataGridViewTextBoxColumn()
                    {
                        Name = propOption.Name,
                        HeaderText = propOption.Title,
                        DefaultCellStyle = cellStyle
                    });
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

            foreach (EntityPropertyOption propOption in _entitySettings.PropertiesOptions)
            {
                _dataGridView.Columns[propOption.Name].DataPropertyName = propOption.Name;
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
            BindingSource bindingSource = (BindingSource)_dataGridView.DataSource;
            DataTable dataTable = (DataTable)bindingSource.DataSource;
            DataRow newRow = dataTable.NewRow();

            List<EntityPropertyOption> datePropOptions = _entitySettings.PropertiesOptions.FindAll((propOption) => { return propOption.Type == typeof(DateTime); });
            foreach (var propOption in datePropOptions)
            {
                newRow[propOption.Name] = new DateTime(1900, 1, 1);
            }
            List<EntityPropertyOption> intPropOptions = _entitySettings.PropertiesOptions.FindAll((propOption) => { return propOption.Type == typeof(int); });
            foreach (var propOption in intPropOptions)
            {
                newRow[propOption.Name] = 0;
            }

            frmSub subForm = new frmSub(FormOpenMode.Add, dataTable, newRow, _entitySettings);
            subForm.ShowDialog();
        }
        private void _toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            BindingSource bindingSource = (BindingSource)_dataGridView.DataSource;
            DataTable dataTable = (DataTable)bindingSource.DataSource;


            DataGridViewSelectedRowCollection selectedRows = _dataGridView.SelectedRows;
            if (selectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = selectedRows[0];
                DataRowView selectedRowView = (DataRowView)selectedRow.DataBoundItem;
                DataRow selectedDataRow = selectedRowView.Row;

                frmSub subForm = new frmSub(FormOpenMode.Edit, dataTable, selectedDataRow, _entitySettings);
                subForm.ShowDialog();
            }
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
