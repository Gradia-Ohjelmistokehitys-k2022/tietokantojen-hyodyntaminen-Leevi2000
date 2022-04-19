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
using System.Globalization;

namespace Autokauppa.view
{
    public partial class MainMenu : Form
    {
        
        model.Auto tempCar = new model.Auto();

        readonly KaupanLogiikka registerHandler;

        private bool editing = false;
        TextBox tbSearch;
        DateTimePicker dtSearch;
        ComboBox cbSearch;
        ComboBox cbSearch2;

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

            CBKategoria.ValueMember = "Id";
            CBKategoria.DisplayMember = "Name";
            CBKategoria.DataSource = registerHandler.GetCarDBColumns();

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

        /// <summary>
        /// Change model combobox items after after choosin different brand.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Save the car after altering info.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTallenna_Click(object sender, EventArgs e)
        {
            var newCar = CarInfo();
            EditMode(false);
            registerHandler.SaveCar(newCar);
        }

        /// <summary>
        /// Enables/disables buttons that user shouldn't press after unsaved changes. (Save and Cancel buttons.)
        /// </summary>
        /// <param name="enterEditMode"></param>
        private void EditMode(bool enterEditMode = true)
        {
            if (enterEditMode)
            {
                editing = true;
                btnTallenna.Enabled = true;
                btnPeruuta.Enabled = true;
                btnSeuraava.Enabled = false;
                btnEdellinen.Enabled = false;
                btnPoista.Enabled = false;
                dtpPaiva.Enabled = true;
                tempCar = CarInfo();
            }
            else
            {
                btnTallenna.Enabled = false;
                btnPeruuta.Enabled = false;
                btnSeuraava.Enabled = true;
                btnEdellinen.Enabled = true;
                btnPoista.Enabled = true;
                dtpPaiva.Enabled = false;
                editing = false;
            }
        }

        /// <summary>
        /// Writes the car info from object to the screen/form text boxes.
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
            if (car.Id != 0) tbId.Text = car.Id.ToString();
        }

        /// <summary>
        /// Gets values from text boxes and returns a Car (Auto) object.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// After making changes and canceling them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPeruuta_Click(object sender, EventArgs e)
        {
            EditMode(false);
            WriteCarInfo(tempCar);
        }

        /// <summary>
        /// Gets next car from database. (By id)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeuraava_Click(object sender, EventArgs e)
        {
            tempCar = registerHandler.GetNextCar(tempCar.Id);
            WriteCarInfo(tempCar);
        }

        /// <summary>
        /// Gets previous car from database. (By id)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdellinen_Click(object sender, EventArgs e)
        {
            tempCar = registerHandler.GetNextCar(tempCar.Id, true);
            WriteCarInfo(tempCar);
        }

        /// <summary>
        /// If user starts editing currently shown info, enter edit mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueChanged(object sender, KeyEventArgs e)
        {
            if (!editing)
            {
                EditMode();
            }
        }

        private void ModifyComboBox(object sender, EventArgs e)
        {
            if (!editing)
            {
                EditMode();
            }
        }

        private void BtnHae_Click(object sender, EventArgs e)
        {

            model.Haku haku;
            
            if (tbSearch != null && tbSearch.Text != "")
            {
                haku = new model.Haku(CBKategoria.SelectedValue.ToString(), tbSearch.Text);
                dataGrid.DataSource = registerHandler.UserSearch(haku);
            }
            if (cbSearch != null && cbSearch2 == null)
            {
                haku = new model.Haku(CBKategoria.SelectedValue.ToString(), cbSearch.SelectedValue.ToString());
                dataGrid.DataSource = registerHandler.UserSearch(haku);
            }
            if (cbSearch != null && cbSearch2 != null)
            {
                haku = new model.Haku(CBKategoria.SelectedValue.ToString(), cbSearch2.SelectedValue.ToString());
                dataGrid.DataSource = registerHandler.UserSearch(haku);
            }
            if (dtSearch != null)
            {
                haku = new model.Haku(CBKategoria.SelectedValue.ToString(), DateTime.Parse(dtSearch.Text).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).ToString());
                dataGrid.DataSource = registerHandler.UserSearch(haku);
            }
            //Hae datatable perustuen haun parametreihin
            
            // Aseta datatable datagridviewille
        }

        private void CBKategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            tbSearch = null;
            cbSearch = null;
            cbSearch2 = null;
            dtSearch = null;


            if(CBKategoria.Text == "Hinta") 
            {
                flowLayoutPanel1.Controls.Add(tbSearch = new TextBox());
                tbSearch.Width = 184;
            } //Hae hinnan mukaan

            if(CBKategoria.Text == "Moottorin tilavuus") 
            {
                flowLayoutPanel1.Controls.Add(tbSearch = new TextBox());
                tbSearch.Width = 184;
            }
            if (CBKategoria.Text == "Rekisteröintipäivä")
            {
                flowLayoutPanel1.Controls.Add(dtSearch = new DateTimePicker()); 
            }
            if (CBKategoria.Text == "Mittarilukema") 
            {
                flowLayoutPanel1.Controls.Add(tbSearch = new TextBox());
                tbSearch.Width = 184;

            }
            if (CBKategoria.Text == "Auton Merkki")
            {
                flowLayoutPanel1.Controls.Add(cbSearch = new ComboBox());
                cbSearch.ValueMember = "Id";
                cbSearch.DisplayMember = "Merkki";
                cbSearch.DataSource = registerHandler.getAllAutoMakers();
                cbSearch.Width = 92;
            }
            if (CBKategoria.Text == "Auton Malli") 
            {
                flowLayoutPanel1.Controls.Add(cbSearch = new ComboBox()); flowLayoutPanel1.Controls.Add(cbSearch2 = new ComboBox());
                cbSearch.ValueMember = "Id";
                cbSearch.DisplayMember = "Merkki";
                cbSearch.DataSource = registerHandler.getAllAutoMakers();
                cbSearch.SelectedIndexChanged += cbSearchIndexChange;

                cbSearch.Width = 92; cbSearch2.Width = 92;

            }
            if (CBKategoria.Text == "Väri")
            {
                flowLayoutPanel1.Controls.Add(cbSearch = new ComboBox());
                cbSearch.ValueMember = "Id";
                cbSearch.DisplayMember = "Name";
                cbSearch.DataSource = registerHandler.GetColors();
                cbSearch.Width = 92;
            }
            if (CBKategoria.Text == "Polttoaine")
            {
                flowLayoutPanel1.Controls.Add(cbSearch = new ComboBox());
                cbSearch.ValueMember = "Id";
                cbSearch.DisplayMember = "Name";
                cbSearch.DataSource = registerHandler.GetFuelType();
                cbSearch.Width = 92;
            }

            
        }
        private void cbSearchIndexChange(object sender, EventArgs e)
        {
            if (cbSearch != null)
            {
                if (cbSearch.SelectedIndex != -1)
                {
                    cbSearch2.ValueMember = "Id";
                    cbSearch2.DisplayMember = "Nimi";
                    cbSearch2.DataSource = registerHandler.getAutoModels(int.Parse(cbSearch.SelectedValue.ToString()));
                }
            }
    
        }

    }
}
