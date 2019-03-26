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
using System.Text.RegularExpressions;

namespace Contact_manager_EF.Dialog
{
    public partial class AddressDialog : Form
    {
        public AddressDialog()
        {
            InitializeComponent();
        }
        //for loading the combo box 
        private void AddressDialog_Load(object sender, EventArgs e)
        {
            Interaction interaction = new Interaction();
            cmbStateName.DisplayMember = "StateName";
            cmbUserName.DisplayMember = "UserName";
            cmbStateName.ValueMember = "PKStateId";
            cmbUserName.ValueMember = "PKUserId";
            cmbStateName.DataSource = interaction.Getdetails(2);
            cmbUserName.DataSource = interaction.Getdetails(3);
        }
        //Variable
        public int FKSatteId
        {
            get
            {
                return (int)cmbStateName.SelectedValue;
            }
            set
            {
                cmbStateName.SelectedValue = value;
            }
        }
        public string StateName
        {
            get
            {
                return cmbStateName.SelectedItem.ToString();
            }
            set
            {
                cmbStateName.SelectedItem = value;
            }
        }

        public int FKuserID
        {
            get
            {
                return (int)cmbUserName.SelectedValue;
            }
            set
            {
                cmbUserName.SelectedValue = value;
            }
        }
        public string UserName
        {
            get
            {
                return cmbUserName.SelectedItem.ToString();
            }
            set
            {
                cmbUserName.SelectedItem = value;
            }
        }
        public string FirstName
        {
            get
            {
                return txtFirstName.Text;
            }
            set
            {
                txtFirstName.Text = value;
            }
        }
        public string LastName
        {
            get
            {
                return txtLastName.Text;
            }
            set
            {
                txtLastName.Text = value;
            }
        }
        public string EmailId
        {
            get
            {
                return txtEmailId.Text;
            }
            set
            {
                txtEmailId.Text = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return txtPhoneNo.Text;
            }
            set
            {
                txtPhoneNo.Text = value;
            }
        }
        public string Address1
        {
            get
            {
                return txtAddress1.Text;
            }
            set
            {
                txtAddress1.Text = value;
            }
        }
        public string Address2
        {
            get
            {
                return txtAddress2.Text;
            }
            set
            {
                txtAddress2.Text = value;
            }
        }
        public string Street
        {
            get
            {
                return txtStreet.Text;
            }
            set
            {
                txtStreet.Text = value;
            }
        }
        public string City
        {
            get
            {
                return txtCity.Text;
            }
            set
            {
                txtCity.Text = value;
            }
        }
        public long ZipCode
        {
            get
            {
                return Convert.ToInt64(txtZipCode.Text);
            }
            set
            {
                txtZipCode.Text = value.ToString();
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
        

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            bool flag = false;
            if (txtFirstName.Text.Trim() == "")
            {
                flag = true;
                epAddress.SetError(txtFirstName, "please the firt name");
            }
            if (txtLastName.Text.Trim() == "")
            {
                flag = true;
                epAddress.SetError(txtLastName, "please enter the last name");
            }
            if (txtEmailId.Text.Trim() == "")
            {
                flag = true;
                epAddress.SetError(txtEmailId, "please enter the  email");
            }
            else if (!Regex.IsMatch(txtEmailId.Text.Trim(), "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"))
            {
                flag = true;
                epAddress.SetError(txtEmailId, "please enter the corret email");
            }
            if (txtPhoneNo.Text.Trim() == "")
            {
                flag = true;
                epAddress.SetError(txtPhoneNo, "please your phone ");
            }
            if (txtAddress1.Text.Trim() == "")
            {
                flag = true;
                epAddress.SetError(txtAddress1, "please enter the address");
            }
            if (txtStreet.Text.Trim() == "")
            {
                flag = true;
                epAddress.SetError(txtStreet, "please enter the street");
            }
            if (txtCity.Text.Trim() == "")
            {
                flag = true;
                epAddress.SetError(txtCity, "please provide the city");
            }
            if (txtZipCode.Text.Trim() == "")
            {
                flag = true;
                epAddress.SetError(txtZipCode, "please enter the zipcode");
            }
            if (flag == false)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
