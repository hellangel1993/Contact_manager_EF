using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contect_Manager_Repose;
using Contact_Manager_model;
using Contact_manager_EF.Dialog;

namespace Contact_manager_EF.Forn
{
    public partial class CountryForm : Form
    {
        public CountryForm()
        {
            InitializeComponent();
        }
        Interaction Interaction = new Interaction();
        CountryDialog CountryDialog;
        private void CountryForm_Load(object sender, EventArgs e)
        {
            dgvCountry.MultiSelect = false;
            dgvCountry.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCountry.ReadOnly = true;
            dgvCountry.AllowUserToAddRows = false;
            dgvCountry.AllowUserToDeleteRows = false;
            dgvCountry.AllowUserToOrderColumns = false;
            dgvCountry.DataSource = Interaction.Getdetails(1);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Country country = new Country();
            CountryDialog = new CountryDialog();
            if (CountryDialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    country.CountryName = CountryDialog.CountryName;
                    country.ZipCodeStart = CountryDialog.ZipStart;
                    country.ZipCodeEnd = CountryDialog.ZipEnd;
                    country.IsActive = CountryDialog.IsActive;
                    Interaction.AddData(country, 1);
                }
                catch (Exception)
                {
                    MessageBox.Show("In add button of the country");
                }
                dgvCountry.DataSource = Interaction.Getdetails(1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Country country = new Country();
            CountryDialog = new CountryDialog();
            country.PKCountryId = Convert.ToInt32(dgvCountry.SelectedRows[0].Cells[0].Value);
            CountryDialog.CountryName = dgvCountry.SelectedRows[0].Cells[1].Value.ToString();
            CountryDialog.ZipStart = Convert.ToInt32(dgvCountry.SelectedRows[0].Cells[2].Value);
            CountryDialog.ZipEnd = Convert.ToInt32(dgvCountry.SelectedRows[0].Cells[3].Value);
            CountryDialog.IsActive = Convert.ToBoolean(dgvCountry.SelectedRows[0].Cells[4].Value);
            if (CountryDialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    country.CountryName = CountryDialog.CountryName;
                    country.ZipCodeStart = CountryDialog.ZipStart;
                    country.ZipCodeEnd = CountryDialog.ZipEnd;
                    country.IsActive = CountryDialog.IsActive;
                    Interaction.Update(country,1);
                }
                catch (Exception)
                {
                    MessageBox.Show("In update button of the country");
                    
                }
            }
            dgvCountry.DataSource = Interaction.Getdetails(1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Country country = new Country();
            //CountryDialog = new CountryDialog();
            country.PKCountryId = Convert.ToInt32(dgvCountry.SelectedRows[0].Cells[0].Value);
            DialogResult dr;
            dr = MessageBox.Show("Are you sure you want to Delete", "Delete", MessageBoxButtons.YesNo);
            if (dr==DialogResult.Yes)
            {
                try
                {
                    Interaction.Delete(country, 1);
                }
                catch (Exception)
                {

                    MessageBox.Show("In the delete button of the country");
                }
            }
            else
            {
                return;
            }
            dgvCountry.DataSource = Interaction.Getdetails(1);
        }
        //for combo box
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbActive.SelectedIndex==0)
            {
                dgvCountry.DataSource=Interaction.Filteredlist(1, 1);
            }
            else if (cmbActive.SelectedIndex==1)
            {
                dgvCountry.DataSource = Interaction.Filteredlist(2, 1);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvCountry.DataSource = Interaction.Getdetails(1);
        }
    }
}
