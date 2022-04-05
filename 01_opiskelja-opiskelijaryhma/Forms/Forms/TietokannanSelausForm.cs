using static Operations.Commands;
using System.Data;
namespace Forms
{
    public partial class TietokannanSelausForm : Form
    {
 



        public TietokannanSelausForm()
        {
            InitializeComponent();
            dataGrid.DataSource = ReadDatabase();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = ReadDatabase();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            ChangeValue(dataGrid.DataSource as DataTable);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewRow addNewRow = new NewRow(dataGrid);
            addNewRow.Show();
            
        }
    }
}