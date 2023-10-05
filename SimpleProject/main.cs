using SimpleProject.DataObjects;
using SimpleProject.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleProject
{
    public partial class main : Form
    {
        private string _fileName = @".\patients.xml";
        private string _dataMemberName = "Patient";
        public main()
        {
            InitializeComponent();
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
            if (!File.Exists(_fileName))
            {
                PatientHelper.CreateXmlWithInitialData(_fileName, _dataMemberName);
            }
            LoadData();
        }
        private void LoadData()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(_fileName);

            // Create a BindingSource and bind it to the DataTable
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataSet.Tables["Patient"];

            _dataGridView.AutoGenerateColumns = false;

            // Bind the DataGridView to the BindingSource
            _dataGridView.DataSource = bindingSource;

            // Manually map DataGridView columns to DataTable columns
            _dataGridView.Columns["FirstName"].DataPropertyName = "FirstName";
            _dataGridView.Columns["LastName"].DataPropertyName = "LastName";
            _dataGridView.Columns["Birthday"].DataPropertyName = "Birthday";
            _dataGridView.Columns["RoomNo"].DataPropertyName = "RoomNo";
            _dataGridView.Columns["HomeAdress"].DataPropertyName = "HomeAdress";

            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void SaveData()
        {
            DataSet dataSet = (DataSet)_dataGridView.DataSource;
            dataSet.WriteXml(_fileName);
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
