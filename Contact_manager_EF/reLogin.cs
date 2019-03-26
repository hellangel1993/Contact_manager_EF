using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact_manager_EF.Forn;
using System.Windows.Forms;

namespace Contact_manager_EF
{
    class reLogin
    {
        public static Form Call()
        {
            LoginForm login = new LoginForm();
            Form form;
            DialogResult dr;
            dr = login.ShowDialog();
            if (dr==DialogResult.Yes)
            {
                form = new MDIParent();
            }
            else if (dr==DialogResult.OK)
            {
                form = new AddressForm();
            }
            else
            {
                form = new LoginForm();
            }
            return form;
        }
    }
}
