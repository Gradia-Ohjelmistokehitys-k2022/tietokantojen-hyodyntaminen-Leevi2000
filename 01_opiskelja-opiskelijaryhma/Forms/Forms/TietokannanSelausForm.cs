using static Operations.Commands;
using System.Data;
namespace Forms
{
    public partial class TietokannanSelausForm : Form
    {
        /// <summary>
        /// Contains the id's of rows that has been edited.
        /// </summary>
        List<int> idsOfChangedRows = new List<int>();

        /// <summary>
        /// Has the information about edited rows in a list.
        /// </summary>
        List<DataGridViewRow> rowChanges = new List<DataGridViewRow>();

        /// <summary>
        /// Contains sql commands in a string format. Can be later sent to sql database.
        /// </summary>
        List<string> commandsToRun = new List<string>();

        public TietokannanSelausForm()
        {
            InitializeComponent();

            // Load the database when the form starts
            dataGrid.DataSource = ReadDatabase();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        // Saves all changes
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {

            CreateCommandsOfEditedRows();
            RunCommandList();

            // Update the datagrid
            dataGrid.DataSource = ReadDatabase();

            // Clear the unsaved changes textbox
            TBLogClear();
        }

        /// <summary>
        /// Opens a form which is used in creating a new user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        // Is called after ending edit mode in a cell in datagridview
        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            // Get the infomation about edited row
            dataGrid.CurrentCell.RowIndex.ToString();
            DataGridViewRow row = dataGrid.Rows[e.RowIndex];
            DataGridViewRow changedRow = row;
            try
            {
                rowChanges.Add(changedRow);

                // Add a message to user log about unsaved changes
                TBLogAdd(CreateMSGFromRow(row));
            }
            catch (System.FormatException)
            {

            }
        }

        private void dataGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                var idOfDeletedRow = e.Row.Cells[0].Value;
                string command = $"DELETE FROM Opiskelija WHERE Id = {idOfDeletedRow}";
                commandsToRun.Add(command);
                TBLogAdd(CreateMSGFromRow(e.Row, true));
            }
            catch
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tbLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbLog_MouseEnter(object sender, EventArgs e)
        {
            tbLog.Height = 400;
        }

        private void tbLog_MouseLeave(object sender, EventArgs e)
        {
            tbLog.Height = 45;
        }

        /// <summary>
        /// Adds given string to tbLog texbox.
        /// </summary>
        /// <param name="message"></param>
        private void TBLogAdd(string message)
        {
            tbLog.Text = tbLog.Text + "\n" + message + "\n";   
        }

        /// <summary>
        /// Clears tbLog texbox. Used usually after saving changes.
        /// </summary>
        private void TBLogClear()
        {
            tbLog.Text = "Tallentamattomat Muutokset";
        }
        
        /// <summary>
        /// Creates commands from rowChanges list into commandsToRun list.
        /// </summary>
        private void CreateCommandsOfEditedRows()
        {
            int i = 0;
            foreach (var id in idsOfChangedRows)
            {
                var etuN = rowChanges[i].Cells[1].Value.ToString();
                var sukuN = rowChanges[i].Cells[2].Value.ToString();
                string command = ($"UPDATE Opiskelija SET Etunimi = '{etuN}', Sukunimi = '{sukuN}' WHERE Id = {id}");
                commandsToRun.Add(command);
                i++;
            }

            // Clear changes lists
            idsOfChangedRows.Clear();
            rowChanges.Clear();
        }

        private void RunCommandList()
        {
            // Run all pending commands to the database
            foreach (var cmd in commandsToRun)
            {
                try
                {
                    ExecuteCommand(cmd);
                }
                catch (Exception ex) { } // If user edited row and then deleted it, it could cause errors.

            }
            commandsToRun.Clear();
        }
    }
}