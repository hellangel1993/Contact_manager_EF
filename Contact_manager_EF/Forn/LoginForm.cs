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
using Contact_manager_EF.Dialog;
using Contact_Manager_model;

namespace Contact_manager_EF.Forn
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '$';
            txtPassword.MaxLength = 10;
        }
        //varable
        Interaction interaction = new Interaction();
        UserDetail detail = new UserDetail();
         public string UserName
        {
            get
            {
                return txtUserName.Text;
            }
        }
        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
        }
       // Form frm;
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text=="Admin"&&txtPassword.Text=="Admin")
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                UserDetail detail= interaction.AuthenticUser(txtUserName.Text);
                if(CheckingPassword(detail.Password,txtPassword.Text)==true)
                {
                    helper.Id = detail.PKUserId;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }

            }
            
        }
        
        private static bool CheckingPassword(string checkPassword, string fromPassword)
        {
            bool flag = false;
            int[] orignalPasword = new int[10];
            foreach (var s in checkPassword)
            {
                int i = 0;
                orignalPasword[i] = Convert.ToInt32(s);
                i++;
            }
            int[] formPassword = new int[10];
            foreach (var s in fromPassword)
            {
                int i = 0;
                formPassword[i] = Convert.ToInt32(s);
                i++;
            }


            if (checkPassword.Length == fromPassword.Length)
            {
                for (int i = 0; i < checkPassword.Length; i++)
                {
                    if (orignalPasword[i] == formPassword[i])
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
        
        private void lkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserDialog dialog = new UserDialog();
            
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                if (interaction.UniqueUser(dialog.UserName)==false)
                {
                    detail.UserName = dialog.UserName;
                    detail.Password = dialog.Password;
                    detail.FirstName = dialog.FirstName;
                    detail.LastName = dialog.LastName;
                    detail.EmailId = dialog.EmailId;
                    detail.PhoneNo = dialog.PhoneNo;
                    detail.IsActive = dialog.IsActive;
                    interaction.AddData(detail, 3);
                }
                else
                {
                    MessageBox.Show("Fool you are already in the system.\nGo and ");
                }
            }
        }
    }
}
