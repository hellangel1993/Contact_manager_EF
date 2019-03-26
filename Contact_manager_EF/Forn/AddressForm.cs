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
using Contect_Manager_Repose.DB;

namespace Contact_manager_EF.Forn
{
    public partial class AddressForm : Form
    {
        public AddressForm()
        {
            InitializeComponent();
        }
        //All object and variable
        Interaction interaction = new Interaction();
        AddressDialog dialog = new AddressDialog();
        Addressbook addressbook = new Addressbook();
        AddressBookDB objAddressBO = new AddressBookDB();
        StateDB stateDB = new StateDB();
        //to fill the form
        private void AddressForm_Load(object sender, EventArgs e)
        {
            dgvAddressBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAddressBook.ReadOnly = true;
            dgvAddressBook.MultiSelect = false;
            dgvAddressBook.AllowUserToAddRows = false;
            dgvAddressBook.AllowUserToDeleteRows = false;
            dgvAddressBook.AllowUserToOrderColumns = false;
            dgvAddressBook.AllowUserToResizeRows = false;
            dgvAddressBook.AutoGenerateColumns = false;
            dgvAddressBook.DataSource = interaction.GetfilterAddress(helper.Id);
            if (helper.Id==-1)
            {
                btnAdd.Enabled = false;
            }
            Fillcombo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    addressbook.FKStateId = dialog.FKSatteId;
                    addressbook.FKUserId = dialog.FKuserID;
                    addressbook.FirstName = dialog.FirstName;
                    addressbook.LastName = dialog.LastName;
                    addressbook.EmailId = dialog.EmailId;
                    addressbook.PhoneNo = dialog.PhoneNo;
                    addressbook.Address1 = dialog.Address1;
                    addressbook.Address2 = dialog.Address2;
                    addressbook.Street = dialog.Street;
                    addressbook.City = dialog.City;
                    addressbook.ZipCode = dialog.ZipCode;
                    addressbook.IsActive = dialog.IsActive;
                    interaction.AddData(addressbook, 4);
                }
                catch (Exception)
                {
                    MessageBox.Show("problem in the add of addressform");
                }
            }
            dgvAddressBook.DataSource = interaction.Getdetails(4);
        }
        // AddressBookDB objAddressBookDB;
        // Addressbook 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //dialog = new AddressDialog();
            //addressbook = new Addressbook();
            addressbook.PKAddressId = (int)(dgvAddressBook.SelectedRows[0].Cells[0].Value);
           
            dialog.StateName = dgvAddressBook.SelectedRows[0].Cells[2].Value.ToString();
            dialog.UserName = dgvAddressBook.SelectedRows[0].Cells[4].Value.ToString();
            dialog.FirstName = (dgvAddressBook.SelectedRows[0].Cells[5].Value).ToString();
            dialog.LastName = (dgvAddressBook.SelectedRows[0].Cells[6].Value).ToString();
            dialog.EmailId = (dgvAddressBook.SelectedRows[0].Cells[7].Value).ToString();
            dialog.PhoneNo = (dgvAddressBook.SelectedRows[0].Cells[8].Value).ToString();
            dialog.Address1 = (dgvAddressBook.SelectedRows[0].Cells[9].Value).ToString();
            dialog.Address2 = (dgvAddressBook.SelectedRows[0].Cells[10].Value).ToString();
            dialog.Street = (dgvAddressBook.SelectedRows[0].Cells[11].Value).ToString();
            dialog.City = (dgvAddressBook.SelectedRows[0].Cells[12].Value).ToString();
            dialog.ZipCode = (long)(dgvAddressBook.SelectedRows[0].Cells[13].Value);
            dialog.IsActive = (bool)(dgvAddressBook.SelectedRows[0].Cells[14].Value);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    addressbook.FKStateId = (int)(dgvAddressBook.SelectedRows[0].Cells[1].Value);
                    addressbook.FKUserId = (int)(dgvAddressBook.SelectedRows[0].Cells[3].Value);
                    addressbook.FirstName = dialog.FirstName;
                    addressbook.LastName = dialog.LastName;
                    addressbook.EmailId = dialog.EmailId;
                    addressbook.PhoneNo = dialog.PhoneNo;
                    addressbook.Address1 = dialog.Address1;
                    addressbook.Address2 = dialog.Address2;
                    addressbook.Street = dialog.Street;
                    addressbook.City = dialog.City;
                    addressbook.ZipCode = dialog.ZipCode;
                    addressbook.IsActive = dialog.IsActive;
                    objAddressBO.UpdateAddress(addressbook);
                    //interaction.update<Addressbook>(addressbook, 4) ;
                }
                catch (Exception)
                {
                    MessageBox.Show("problem in the update in the address table");
                }
            }
            dgvAddressBook.DataSource = interaction.Getdetails(4);
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            addressbook = new Addressbook();
            addressbook.PKAddressId = (int)dgvAddressBook.SelectedRows[0].Cells[0].Value;
            DialogResult dr = MessageBox.Show("Are you sure you want to Delete", "Delete", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    interaction.Delete(addressbook, 4);
                }
                catch (Exception)
                {
                    MessageBox.Show("Problem in the delete of Address form");
                }
            }
            dgvAddressBook.DataSource = interaction.Getdetails(4);
        }

        private void dgvAddressBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //for combo box
        public void Fillcombo()
        {
            cmbCountry.DisplayMember = "CountryName";
           // cmbStateId.DisplayMember = "StateName";
            cmbCountry.ValueMember = "PKCountryId";
            //cmbStateId.ValueMember = "PKStateId";
            cmbCountry.DataSource = interaction.Getdetails(1);
            //cmbStateId.DataSource = interaction.Getdetails(2);
        }
        //for state combo box
        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id= (int)cmbCountry.SelectedValue;
            cmbStateId.DisplayMember = "StateName";
            cmbStateId.ValueMember = "PKStateId";
            cmbStateId.DataSource = stateDB.FilteredState(id);
        }
        //change the datagrid on the combo box
        private void btnFilter_Click(object sender, EventArgs e)
        {
            int idState = (int)cmbStateId.SelectedValue;
            dgvAddressBook.Columns["StateName"].Visible = false;
            dgvAddressBook.Columns["IsActive"].Visible = false;
            if (cmbIsActive.SelectedIndex==0)
            {
                dgvAddressBook.DataSource = objAddressBO.FilteredAddress(idState, true);
                
            }
            else if (cmbIsActive.SelectedIndex==1)
            {
                dgvAddressBook.DataSource = objAddressBO.FilteredAddress(idState, false);
            }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvAddressBook.DataSource = interaction.GetfilterAddress(helper.Id);
            dgvAddressBook.Columns["StateName"].Visible = true;
            dgvAddressBook.Columns["IsActive"].Visible = true;
        }
    }
}
