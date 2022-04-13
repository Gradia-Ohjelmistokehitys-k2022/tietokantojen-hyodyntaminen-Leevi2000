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
        
        model.Auto tempCar = new model.Auto();

        readonly KaupanLogiikka registerHandler;

        public MainMenu()
        {
            registerHandler = new KaupanLogiikka();
            InitializeComponent();
            cbMerkki.ValueMember = "Id";
            cbMerkki.DisplayMember = "Merkki";
            cbMerkki.DataSource = registerHandler.getAllAutoMakers();

            cbVari.ValueMember = "Id";
            cbVari.DisplayMember = "Name";
            cbVari.DataSource = registerHandler.GetColors();

            cbPolttoaine.ValueMember = "Id";
            cbPolttoaine.DisplayMember = "Name";
            cbPolttoaine.DataSource = registerHandler.GetFuelType();
        }

 
        /// <summary>
        /// Adds new car to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLisaa_Click(object sender, EventArgs e)
        {
            EditMode();
            ClearText();

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
            if (cbMerkki.SelectedIndex != -1)
            {
                cbMalli.ValueMember = "Id";
                cbMalli.DisplayMember = "Nimi";
                cbMalli.DataSource = registerHandler.getAutoModels(int.Parse(cbMerkki.SelectedValue.ToString()));
            }
        }

        private void tbId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpPaiva_ValueChanged(object sender, EventArgs e)
        {

        }
        private void ClearText()
        {
            cbMalli.Text = null;
            cbMalli.SelectedIndex = -1;

            cbMerkki.Text = null;
            cbMerkki.SelectedIndex = -1;

            cbPolttoaine.Text = null;
            cbPolttoaine.SelectedIndex = -1;

            cbVari.Text = null;
            cbVari.SelectedIndex = -1;

            tbHinta.Text = null;
            tbId.Text = null;
            tbMittarilukema.Text = null;
            tbTilavuus.Text = null;
            dtpPaiva.Text = DateTime.Now.ToString();
        }

        private void btnTallenna_Click(object sender, EventArgs e)
        {
            var newCar = CarInfo();
            EditMode(false);
            registerHandler.SaveCar(newCar);
        }

        private void EditMode(bool enterEditMode = true)
        {
            if (enterEditMode)
            {
                btnTallenna.Enabled = true;
                btnPeruuta.Enabled = true;
                btnSeuraava.Enabled = false;
                btnEdellinen.Enabled = false;
                btnPoista.Enabled = false;
                var car = CarInfo();
                tempCar = car;
            }
            else
            {
                btnTallenna.Enabled = false;
                btnPeruuta.Enabled = false;
                btnSeuraava.Enabled = false;
                btnEdellinen.Enabled = true;
                btnPoista.Enabled = true;
            }
        }

        /// <summary>
        /// Writes the car info from object to the user.
        /// </summary>
        /// <param name="car"></param>
        private void WriteCarInfo(model.Auto car)
        {
            tbHinta.Text = car.Price.ToString();
            tbTilavuus.Text = car.EngineVolume.ToString();
            tbMittarilukema.Text = car.Meter.ToString();
            dtpPaiva.Text = car.RegistryDate.ToString();
            cbMerkki.SelectedValue = car.CarBrandId;
            cbMalli.SelectedValue = car.CarModelId;
            cbPolttoaine.SelectedValue = car.FuelTypeId;
            cbVari.SelectedValue = car.ColorId;
        }

        private model.Auto CarInfo()
        {
            model.Auto car = new model.Auto();
            if (tbHinta.Text != "") car.Price = float.Parse(tbHinta.Text);
            if (tbTilavuus.Text != "") car.EngineVolume = float.Parse(tbTilavuus.Text);
            if (tbMittarilukema.Text != "") car.Meter = int.Parse(tbMittarilukema.Text);
            car.RegistryDate = DateTime.Parse(dtpPaiva.Text);
            if (cbMerkki.SelectedValue != null) car.CarBrandId = int.Parse(cbMerkki.SelectedValue.ToString());
            if (cbMalli.SelectedValue != null) car.CarModelId = int.Parse(cbMalli.SelectedValue.ToString());
            if (cbPolttoaine.SelectedValue != null) car.FuelTypeId = int.Parse(cbPolttoaine.SelectedValue.ToString());
            if (cbVari.SelectedValue != null) car.ColorId = int.Parse(cbVari.SelectedValue.ToString());
            return car;
        }
        private void btnPeruuta_Click(object sender, EventArgs e)
        {
            EditMode(false);
            WriteCarInfo(tempCar);
        }
    }
}
