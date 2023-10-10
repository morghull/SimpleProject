using System;
using SimpleProject.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleProject.Interfaces;

namespace SimpleProject
{
    public partial class frmSub : Form
    {
        private FormOpenMode _openMode;
        private DataTable _dataTable;
        private DataRow _dataRow;
        private List<EntityPropertyOption> _propOptions;

        private Dictionary<EntityPropertyOption, Control> _dataControls = new Dictionary<EntityPropertyOption, Control>();
        public frmSub(FormOpenMode openMode, DataTable dataTable, DataRow dataRow, IPropertiesOption properties)
        {
            InitializeComponent();
            _openMode = openMode;
            _dataTable = dataTable;
            _dataRow = dataRow;
            _propOptions = properties.GetPropertiesOptions();

            int xCoordToCalcNewControlPosition = this.Width / 2;
            int yCoordPanelDelta = _toolStrip.Height + 20;
            //int colorDelta = 0;
            int formBorderThickness = 16;
            int panelWidth = this.Width - formBorderThickness;

            foreach (EntityPropertyOption propOption in _propOptions)
            {
                //colorDelta += 25;
                Panel panel = new Panel();
                //panel.BackColor = Color.FromArgb(255, colorDelta, colorDelta, colorDelta);
                panel.Width = panelWidth;
                panel.Height = 40;
                panel.Left = 0;
                panel.Top = yCoordPanelDelta;

                Label label = new Label() { Text = propOption.Title };
                label.TextAlign = ContentAlignment.TopRight;
                label.Top = 2;
                label.Width = 110;
                label.Height = 40;
                //label.ForeColor = Color.White;
                panel.Controls.Add(label);

                Type dataType = propOption.Type;
                Control dataControl = null;
                if (dataType == typeof(string))
                {
                    TextBox textBox = new TextBox();
                    textBox.Text = dataRow[propOption.Name].ToString();

                    if (propOption.IsMultiline)
                    {
                        textBox.Multiline = true;
                        textBox.Height *= 2;
                        textBox.Width *= 2;
                    }

                    dataControl = textBox;
                }
                else if (dataType == typeof(int))
                {
                    NumericUpDown numericUpDown = new NumericUpDown();
                    numericUpDown.Minimum = 0;
                    numericUpDown.Maximum = 99999;
                    numericUpDown.Value = (int)dataRow[propOption.Name];


                    dataControl = numericUpDown;
                }
                else if (dataType == typeof(DateTime))
                {
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    dateTimePicker.Value = (DateTime)dataRow[propOption.Name];

                    dataControl = dateTimePicker;
                }
                if (dataControl != null)
                {
                    dataControl.Left = label.Width + 5;
                    dataControl.Top = 0;
                    _dataControls.Add(propOption, dataControl);
                    panel.Controls.Add(dataControl);
                }

                yCoordPanelDelta += panel.Height;
                this.Controls.Add(panel);
            }

            this.Height = yCoordPanelDelta + _toolStrip.Height + 20;
        }
        private void _toolStripButton_Ok_Click(object sender, EventArgs e)
        {
            foreach (var dataControl in _dataControls)
            {
                EntityPropertyOption propOption = dataControl.Key;
                Control control = dataControl.Value;

                Type dataType = propOption.Type;
                if (dataType == typeof(string))
                {
                    _dataRow[propOption.Name] = ((TextBox)control).Text;
                }
                else if (dataType == typeof(DateTime))
                {
                    _dataRow[propOption.Name] = ((DateTimePicker)control).Value;
                }
                else if (dataType == typeof(int))
                {
                    _dataRow[propOption.Name] = ((NumericUpDown)control).Value;
                }
            }
            if (_openMode == FormOpenMode.Add)
            {
                _dataTable.Rows.Add(_dataRow);
            }

            this.Close();
        }
        private void _toolStripButton_No_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
