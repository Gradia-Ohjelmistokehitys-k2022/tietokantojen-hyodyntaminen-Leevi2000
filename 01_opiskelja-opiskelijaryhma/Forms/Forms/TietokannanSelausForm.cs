using static Operations.Commands;
using System.Data;
namespace Forms
{
    public partial class TietokannanSelausForm : Form
    {
        List<int> idsOfChangedRows = new List<int>();
        List<DataGridViewRow> rowChanges = new List<DataGridViewRow>();


        public TietokannanSelausForm()
        {
            InitializeComponent();
            dataGrid.DataSource = ReadDatabase();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        // Saves all changes
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            var unmodified = ReadDatabase();
            var current = dataGrid.DataSource as DataTable;

            int i = 0;
            foreach (var id in idsOfChangedRows)
            {
                var etuN = rowChanges[i].Cells[1].Value.ToString();
                var sukuN = rowChanges[i].Cells[2].Value.ToString();
                string command = ($"UPDATE Opiskelija SET Etunimi = '{etuN}', Sukunimi = '{sukuN}' WHERE Id = {id}");
                ExecuteCommand(command);
                i++;
            }

            idsOfChangedRows.Clear();
            rowChanges.Clear();
            dataGrid.DataSource = ReadDatabase();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewRow addNewRow = new NewRow(dataGrid);
            addNewRow.Show();
            
        }

        private void dataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGrid.CurrentCell.RowIndex.ToString();
            DataGridViewRow row = dataGrid.Rows[e.RowIndex];


            var rowIndex = row.Cells[0].Value.ToString();
            try
            {
                idsOfChangedRows.Add(int.Parse(rowIndex));
            }
            catch (System.FormatException)
            {

            }
                
            
            
           
        }

        private void dataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Send the new information how the text changed
        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGrid.CurrentCell.RowIndex.ToString();
            DataGridViewRow row = dataGrid.Rows[e.RowIndex];
            DataGridViewRow changedRow = row;
            try
            {
                rowChanges.Add(changedRow);
            }
            catch (System.FormatException)
            {

            }
        
               
        }
    }
}