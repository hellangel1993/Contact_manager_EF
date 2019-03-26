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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        //objects
        Interaction Interaction = new Interaction();
        UserDetail user = new UserDetail();
        UserDialog userDialog = new UserDialog();

        private void UserForm_Load(object sender, EventArgs e)
        {
            dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUser.MultiSelect = false;
            dgvUser.ReadOnly = true;
            dgvUser.AllowUserToAddRows = false;
            dgvUser.AllowUserToDeleteRows = false;
            dgvUser.AllowUserToOrderColumns = false;
            dgvUser.AutoGenerateColumns = false;
            dgvUser.DataSource = Interaction.Getdetails(3);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (userDialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    user.UserName = userDialog.UserName;
                    user.Password = userDialog.Password;
                    user.FirstName = userDialog.FirstName;
                    user.LastName = userDialog.LastName;
                    user.EmailId = userDialog.EmailId;
                    user.PhoneNo = userDialog.PhoneNo;
                    user.IsActive = userDialog.IsActive;
                    Interaction.AddData(user, 3);
                }
                catch (Exception)
                {
                    MessageBox.Show("check the add in the user");
                }
            }
            dgvUser.DataSource = Interaction.Getdetails(3);
        }
        //for updating
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            user.PKUserId = (int)dgvUser.SelectedRows[0].Cells[0].Value;
            userDialog.UserName = dgvUser.SelectedRows[0].Cells[1].Value.ToString();
            userDialog.Password = dgvUser.SelectedRows[0].Cells[2].Value.ToString();
            userDialog.FirstName= dgvUser.SelectedRows[0].Cells[3].Value.ToString();
            userDialog.LastName= dgvUser.SelectedRows[0].Cells[4].Value.ToString();
            userDialog.EmailId= dgvUser.SelectedRows[0].Cells[5].Value.ToString();
            userDialog.PhoneNo= dgvUser.SelectedRows[0].Cells[6].Value.ToString();
            userDialog.IsActive=(bool)dgvUser.SelectedRows[0].Cells[7].Value;
            if (userDialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    user.Password = userDialog.Password;
                    user.FirstName = userDialog.FirstName;
                    user.LastName = userDialog.LastName;
                    user.UserName = userDialog.UserName;
                    user.EmailId = userDialog.EmailId;
                    user.PhoneNo = userDialog.PhoneNo;
                    user.IsActive = userDialog.IsActive;
                    Interaction.Update(user, 3);
                }
                catch (Exception)
                {
                    MessageBox.Show("check in the update in the user");
                }
            }
            dgvUser.DataSource = Interaction.Getdetails(3);
        }
        //for deleting 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            user.PKUserId = (int)dgvUser.SelectedRows[0].Cells[0].Value;
            DialogResult dr;
            if (dgvUser.RowCount!=0)
            {
                dr = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
                if (dr==DialogResult.Yes)
                {
                    Interaction.Delete(user, 3);
                }
            }
            dgvUser.DataSource = Interaction.Getdetails(3);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedIndex==0)
            {
                dgvUser.DataSource = Interaction.FilterUser(1);
            }
            else if (cmbStatus.SelectedIndex==1)
            {
                dgvUser.DataSource = Interaction.FilterUser(2);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvUser.DataSource = Interaction.Getdetails(3);
        }
        //for the combo box

    }
}
