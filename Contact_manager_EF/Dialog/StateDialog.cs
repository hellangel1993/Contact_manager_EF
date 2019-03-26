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

namespace Contact_manager_EF.Dialog
{
    public partial class StateDialog : Form
    {
        public StateDialog()
        {
            InitializeComponent();
            BindCountries();
        }
        //to access the interaction of the repose
        Interaction Interaction = new Interaction();
        //variable
        public void BindCountries()
        {
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "PKCountryId";
            cmbCountry.DataSource = Interaction.Getdetails(1);
        }
        public string StateName
        {
            get
            {
                return txtStateName.Text;
            }
            set
            {
                txtStateName.Text = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return chkIsActive.Checked;
            }
            set
            {
                chkIsActive.Checked = value;
            }
        }
        public int CountryId
        {
            get
            {
                return (int)cmbCountry.SelectedValue;
            }
            set
            {
                cmbCountry.SelectedValue = value;
            }
        }
        public string CountryName
        {
            get
            {
                return cmbCountry.SelectedItem.ToString();
            }
            set
            {
                cmbCountry.SelectedItem = value;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool errorFlag = false;
            epStateDialog.Clear();
            if (txtStateName.Text.Trim()==" ")
            {
                errorFlag = true;
                epStateDialog.SetError(txtStateName, "Please enter the state Name");
            }
            if (errorFlag==false)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void StateDialog_Load(object sender, EventArgs e)
        {
            cmbCountry.SelectedValue = CountryId;
            txtStateName.Text = StateName;
            chkIsActive.Checked = IsActive;
        }
    }
}
