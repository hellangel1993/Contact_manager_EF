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
    public partial class UserDialog : Form
    {
        public UserDialog()
        {
            InitializeComponent();
        }
        //variable
        public string UserName
        {
            get
            {
                return txtUserName.Text;
            }
            set
            {
                txtUserName.Text = value;
            }
        }
        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
            set
            {
                txtPassword.Text = value;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            epUserDialog.Clear();
            Interaction interaction = new Interaction();
            bool errorFlag = false;
            if (string.IsNullOrEmpty(txtUserName.Text)&&interaction.UniqueUser(txtUserName.Text)==true)
            {
                epUserDialog.SetError(txtUserName, "Please enter the correct the Username and unique");
                errorFlag = true;
            }//for checking null and the username should be unique also.
            if (txtFirstName.Text.Trim()=="")
            {
                epUserDialog.SetError(txtFirstName, "Please enter the First Name");
                errorFlag = true;
            }
            if (txtLastName.Text.Trim()=="")
            {
                epUserDialog.SetError(txtLastName, "Please enter the Last Name");
                errorFlag = true;
            }
            if (txtPassword.Text.Trim()=="")
            {
                epUserDialog.SetError(txtPassword, "Please enter the Password");
                errorFlag = true;
            }
            if (txtEmailId.Text.Trim()=="")
            {
                epUserDialog.SetError(txtEmailId, "Please enter the Email");
                errorFlag = true;
            }
            if (txtPhoneNo.Text.Trim()=="")
            {
                epUserDialog.SetError(txtPhoneNo, "Please enter the Phone No.");
                errorFlag = true;
            }
            else if (!Regex.IsMatch(txtEmailId.Text.Trim(), "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"))
            {
                epUserDialog.SetError(txtEmailId, "Enter Correct Email Id in the right format");
                errorFlag = true;
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
    }
}
