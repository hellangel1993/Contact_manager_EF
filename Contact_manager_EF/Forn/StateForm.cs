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
    public partial class StateForm : Form
    {
        public StateForm()
        {
            InitializeComponent();
        }
        Interaction Interaction = new Interaction();
        State state;
        //for the combobox  
        private void Bindcombo()
        {
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "PKCountryId";
            cmbCountry.DataSource = Interaction.Getdetails(1);
        }

        private void StateForm_Load(object sender, EventArgs e)
        {
            dgvState.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvState.ReadOnly = true;
            dgvState.AllowUserToAddRows = false;
            dgvState.AllowUserToDeleteRows = false;
            dgvState.AllowUserToOrderColumns = true;
            dgvState.MultiSelect = false;
            dgvState.AutoGenerateColumns = false;
            dgvState.DataSource = Interaction.Getdetails(2);
            Bindcombo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            state = new State();
            StateDialog dialog = new StateDialog();
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    state.FKCountryId = dialog.CountryId;
                    state.StateName = dialog.StateName;
                    state.IsActive = dialog.IsActive;
                    Interaction.AddData(state, 2);
                }
                catch (Exception)
                {
                    MessageBox.Show("you are in the stateform Add");
                }

            }
            dgvState.DataSource = Interaction.Getdetails(2);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            state = new State();
            StateDialog dialog = new StateDialog();
            state.PKStateId = Convert.ToInt32(dgvState.SelectedRows[0].Cells[0].Value);
            dialog.CountryId = Convert.ToInt32(dgvState.SelectedRows[0].Cells[1].Value);
            //dialog.CountryName = dgvState.SelectedRows[0].Cells[2].Value.ToString();//for seeing which works .
            dialog.StateName = dgvState.SelectedRows[0].Cells[3].Value.ToString();
            dialog.IsActive = (bool)(dgvState.SelectedRows[0].Cells[4].Value);
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    state.FKCountryId = dialog.CountryId;
                    state.StateName = dialog.StateName;
                    state.IsActive = dialog.IsActive;
                    Interaction.Update(state, 2);
                }
                catch (Exception)
                {
                    MessageBox.Show("you are in the table state in update");
                }
            }
            dgvState.DataSource = Interaction.Getdetails(2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            state = new State();
            state.PKStateId = Convert.ToInt32(dgvState.SelectedRows[0].Cells[0].Value);
            DialogResult dr;
            dr= MessageBox.Show("Are you sure you want to Delete", "Delete", MessageBoxButtons.YesNo);
            if (dr==DialogResult.Yes)
            {
                try
                {
                    Interaction.Delete(state, 2);
                }
                catch (Exception)
                {
                    MessageBox.Show("you are in the state in delete");
                }
            }
            else
            {
                return;
            }
            dgvState.DataSource = Interaction.Getdetails(2);
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            int id = (int)cmbCountry.SelectedValue;
            dgvState.DataSource = Interaction.Filteredlist(id, 2);
            dgvState.Columns["CountryName"].Visible = false;
            dgvState.Columns[1].Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvState.DataSource = Interaction.Getdetails(2);
            dgvState.Columns["CountryName"].Visible = true;
            dgvState.Columns[1].Visible = true;
        }
    }
}
