using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Operations.Commands;

namespace Forms
{
    public partial class NewRow : Form
    {
        DataGridView dataGrid;
        public NewRow(DataGridView DataGridView)
        {
            InitializeComponent();
            dataGrid = DataGridView;
        }

        private void NewRow_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow(tbFirstName.Text, tbLastName.Text);
            dataGrid.DataSource = ReadDatabase();
            this.Close();
        }
    }
}
