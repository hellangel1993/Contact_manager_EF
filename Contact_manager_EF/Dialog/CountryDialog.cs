using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_manager_EF.Dialog
{
    public partial class CountryDialog : Form
    {
        public CountryDialog()
        {
            InitializeComponent();
        }

        private void CountryDialog_Load(object sender, EventArgs e)
        {

        }
        //variables
        public string CountryName
        {
            get
            {
                return txtCountryName.Text;
            }
            set
            {
                txtCountryName.Text = value ;
            }
        }
        public int ZipStart
        {
            get
            {
                return Convert.ToInt32(txtZipCodeStart.Text);
            }
            set
            {
                txtZipCodeStart.Text = value.ToString();
            }
        }
        public int ZipEnd
        {
            get
            {
                return Convert.ToInt32(txtZipCodeEnd.Text);
            }
            set
            {
                txtZipCodeEnd.Text = value.ToString();
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
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
