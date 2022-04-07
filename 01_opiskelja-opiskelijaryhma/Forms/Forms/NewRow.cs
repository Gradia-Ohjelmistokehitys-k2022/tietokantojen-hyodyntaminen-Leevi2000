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

        List<string> groupIDList = new List<string>();
        List<string> groupNameList = new List<string>();

        public NewRow(DataGridView DataGridView)
        {
            InitializeComponent();
            dataGrid = DataGridView;

            var groupTable = GetGroups();
            var rows = groupTable.Rows;
            foreach (DataRow row in rows)
            {
                List<string> temp = new List<string>();
                foreach(DataColumn column in groupTable.Columns)
                {
                    temp.Add(row[column].ToString());
                }
                groupIDList.Add(temp[0]);
                groupNameList.Add(temp[1]);

               
            }
      
            cbGroups.DataSource = groupNameList;
        }

        private void GroupNamesIntoList()
        {

        }

        private void NewRow_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //ExecuteCommand($"SELECT * FROM OpiskelijaryhmaTaulu.Ryhmanimi WHERE OpiskelijaryhmaTaulu = {cbGroups.Text}");
            int i = 0;
            foreach(var item in groupNameList)
            {
                if (item == cbGroups.Text)
                {
                    break;
                }
                else
                {
                    i++;
                }
            }


            AddRow(tbFirstName.Text, tbLastName.Text, groupIDList[i]);
            RefreshDataGrid();
            this.Close();
        }
        private void RefreshDataGrid()
        {
            dataGrid.DataSource = ReadGroupDataBase();
            dataGrid.Columns["RyhmaId"].Visible = false;
            dataGrid.Columns["Id1"].Visible = false;

        }

        private void cbGroups_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
