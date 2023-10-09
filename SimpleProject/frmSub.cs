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
        public frmSub(DataGridViewRow data, IProperties properties)
        {
            InitializeComponent();
            List<string> names = properties.GetPropertiesNames();
            Dictionary<string, Type> types = properties.GetPropretiesTypes();
            Dictionary<string, string> titles = properties.GetPropertiesTitles();

            foreach (string name in names)
            {
                
            }

            //textBox1.Text = data.Cells["FirstName"].Value.ToString();
            //dateTimePicker1.Value = (DateTime)data.Cells["Birthday"].Value;
        }

        private void _toolStripButton_No_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
