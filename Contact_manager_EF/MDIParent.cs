using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contact_manager_EF.Forn;

namespace Contact_manager_EF
{
    public partial class MDIParent : Form
    {
        public MDIParent()
        {
            InitializeComponent();
        }

        private void mnuMenuHorx_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuVertex_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuMenuCascading_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        //object of the form
        UserForm UserForm;
        AddressForm AddressForm;
        CountryForm CountryForm;
        StateForm StateForm;

        private void mnuManageCountry_Click(object sender, EventArgs e)
        {
            if (CountryForm==null)
            {
                CountryForm = new CountryForm();
                CountryForm.Show();
                CountryForm.MdiParent = this;
                CountryForm.FormClosing += CountryForm_FormClosing;
            }
            else
            {
                CountryForm.Activate();
            }
        }

        private void CountryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CountryForm = null;
        }

        private void mnuManageUser_Click(object sender, EventArgs e)
        {
            if (UserForm==null)
            {
                UserForm = new UserForm();
                UserForm.Show();
                UserForm.MdiParent = this;
                UserForm.FormClosing += UserForm_FormClosing;
            }
            else
            {
                UserForm.Activate();
            }
        }
        
        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserForm = null;
        }

        private void mnuManageState_Click(object sender, EventArgs e)
        {
            if (StateForm==null)
            {
                StateForm = new StateForm();
                StateForm.Show();
                StateForm.MdiParent = this;
                StateForm.FormClosing += StateForm_FormClosing;
            }
            else
            {
                StateForm.Activate();
            }
        }

        private void StateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StateForm = null;
        }

        private void mnuAddressbook_Click(object sender, EventArgs e)
        {
            if (AddressForm==null)
            {
                AddressForm = new AddressForm();
                AddressForm.Show();
                AddressForm.MdiParent = this;
                AddressForm.FormClosing += AddressForm_FormClosing;
            }
            else
            {
                AddressForm.Activate();
            }
        }

        private void AddressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AddressForm = null;
        }

        private void mnuManageExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserForm = null;
            AddressForm = null;
            CountryForm = null;
            StateForm = null;
            reLogin.Call();
            this.Close();
        }
    }
}
