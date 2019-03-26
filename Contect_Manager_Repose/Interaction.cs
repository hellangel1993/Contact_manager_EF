using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact_Manager_model;
using Contect_Manager_Repose.BO;
using Contect_Manager_Repose.DB;//for user and this will be made for all the forms


namespace Contect_Manager_Repose
{
    public class Interaction
    {
        // creating objects and varables
        object qry;
        CountryBO CountryBO = new CountryBO();
        StateBO StateBO = new StateBO();
        UserDB UserDB = new UserDB();
        AddressBookDB AddressBookDB = new AddressBookDB();
        //AddressBookEntities context = new AddressBookEntities();


        public object Getdetails(int a)
        {

            if (a == 1)
            {
                qry = null;
                qry = CountryBO.GetCountries();
            }
            else if (a == 2)
            {
                qry = null;
                qry = StateBO.GetStates();
            }
            else if (a == 3)
            {
                qry = null;
                qry = UserDB.GetUserDetails();
            }
            //if (a == 4)
            //{
            //    qry = null;
            //    qry = AddressBookDB.GetAddressbook();
            //}
            return qry;
        }
        public object GetfilterAddress(int id)
        {
             return AddressBookDB.GetAddressbook(id);
        }
        //for adding the data in the tables
        public void AddData(object T, int b)
        {
            if (b == 1)
            {
                CountryBO.AddCountry((Country)T);
            }
            else if (b == 2)
            {
                StateBO.AddState((State)T);
            }
            else if (b == 3)
            {
                UserDB.AddUser((UserDetail)T);
            }
            if (b == 4)
            {
                AddressBookDB.AddAddress((Addressbook)T);
            }
        }
        //for Updating the data in the table
        public void Update(object T, int c)
        {
            if (c == 1)
            {
                CountryBO.UpdateCountry((Country)T);
            }
            else if (c == 2)
            {
                StateBO.UpdateState((State)T);
            }
            else if (c == 3)
            {
                UserDB.Update((UserDetail)T);
            }
            if (c == 4)
            {
                // AddressBookDB.UpdateAddress((Addressbook)T);
            }
        }
        //this has to be completed
        public void update<t>(Addressbook objaddresss, int id) //where t:Addressbook
        {
            if (id == 4)
            {
                // AddressBookDB.UpdateAddress<t>(objaddresss);
            }
        }
        //for Deleting the data from the table
        public void Delete(object T, int d)
        {
            if (d == 1)
            {
                CountryBO.DeleteCountry((Country)T);
            }
            else if (d == 2)
            {
                StateBO.DeleteState((State)T);
            }
            else if (d == 3)
            {
                UserDB.DeleteUser((UserDetail)T);
            }
            if (d == 4)
            {
                AddressBookDB.DeleteAddress((Addressbook)T);
            }
        }
        //for combo box  of country
        public object Filteredlist(int id, int access)
        {
            if (access == 1)
            {
                qry = null;
                qry = CountryBO.FilteredCountry(id);
            }
            else if (access == 2)
            {
                qry = null;
                qry = StateBO.FilterState(id);
            }
            return qry;
        }
        //for checking the username
        public bool UniqueUser(string userName)
        {
            bool flag = UserDB.UniqueUser(userName);
            return flag;
        }
        //for the combobox of the user
        public List<UserDetail> FilterUser(int status)
        {
            List<UserDetail> qry = UserDB.GetUserDetails();
            if (status == 1)
            {
                qry = qry.Where(e1 => e1.IsActive == true).ToList();
            }
            else
            {
                qry = qry.Where(e1 => e1.IsActive == false).ToList();
            }
            return qry;
        }
        //for authenticating user
        public UserDetail AuthenticUser(string UserName)
        {
            return UserDB.AuthenticateUser(UserName);

        }
    }
}
