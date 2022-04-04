using static Operations.Commands;

namespace Forms
{
    public partial class TietokannanSelausForm : Form
    {
 



        public TietokannanSelausForm()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = ConnectAndReadDatabase();
        }
    }
}