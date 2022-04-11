using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Autokauppa.controller;

namespace Autokauppa.view
{
    public partial class MainMenu : Form
    {
        

        KaupanLogiikka registerHandler;

        public MainMenu()
        {
            registerHandler = new KaupanLogiikka();
            InitializeComponent();
            cbMerkki.ValueMember = "Id";
            cbMerkki.DisplayMember = "Merkki";
            cbMerkki.DataSource = registerHandler.getAllAutoMakers();
        }

        private void cbMerkkiText()
        {
           // cbMerkki.ValueMember
        }

        private void btnLisaa_Click(object sender, EventArgs e)
        {
            //tbTilavuus = Moottorin tilavuus
            //tbHinta = hinta
            //tbMittarilukema = mittarin lukema
            //cbMerkki =
            //cbMalli = 
            //dtpPaiva = 
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void testaaTietokantaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registerHandler.TestDatabaseConnection();
        }

        private void tbTilavuus_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void cbMerkki_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMalli.ValueMember = "Id";
            cbMalli.DisplayMember = "Nimi";
            cbMalli.DataSource = registerHandler.getAutoModels(int.Parse(cbMerkki.SelectedValue.ToString()));
        }
    }
}
