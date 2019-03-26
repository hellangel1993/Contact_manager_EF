using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Contact_Manager_model;
using System.Transactions;

namespace Contect_Manager_Repose.DB
{
    public class AddressBookDB
    {
        AddressBookEntities context = new AddressBookEntities();
        //for geting the data for combo box
        public List<Addressbook> FilteredAddress(int id,bool flag)
        {
            return context.Addressbooks.Where(e1 => e1.FKStateId == id).Where(e2=>e2.IsActive==flag).ToList();
        }
        public object GetAddressbook(int id)
        {
            List<State> states = context.States.ToList();
            List<UserDetail> users = context.UserDetails.ToList();
            List<Addressbook> addressbooks;
            if (id==-1)
            {
                 addressbooks = context.Addressbooks.ToList();
            }
            else
            {
                 addressbooks = context.Addressbooks.Where(e1=>e1.FKUserId==id).ToList();
            }
            
            var qry = addressbooks.Join(states, a1 => a1.FKStateId, s1 => s1.PKStateId, (a1, s1) => new
            {
                a2 = a1,
                s2 = s1
            }).Join(users, a3 => a3.a2.FKUserId, u1 => u1.PKUserId, (a3, u1) => new
            {
                a3.a2.PKAddressId,
                a3.s2.PKStateId,
                a3.s2.StateName,
                u1.PKUserId,
                u1.UserName,
                a3.a2.FirstName,
                a3.a2.LastName,
                a3.a2.EmailId,
                a3.a2.PhoneNo,
                a3.a2.Address1,
                a3.a2.Address2,
                a3.a2.Street,
                a3.a2.City,
                a3.a2.ZipCode,
                a3.a2.IsActive
            }
            ).ToList();
            return qry;
        }
        //for adding the data in the table
        public void AddAddress(Addressbook addressbook)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                context.Addressbooks.Add(addressbook);
                context.SaveChanges();
                trans.Complete();
                trans.Dispose();
            }
        }
       
        //public Addressbook GetAddress(int addressId)
        //{
        //    return context.Addressbooks.Where(address => address.PKAddressId == addressId).SingleOrDefault();
        //}
        public void UpdateAddress(Addressbook objAddress)
        {
            try
            {
                context.Entry(objAddress).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //this has to be done.
        //public void UpdateAddress<t>(Addressbook objAddress) //where t:Addressbook
        //{
        //    try
        //    {
        //        context.Entry(objAddress).State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //for deleting the data in the table
        public void DeleteAddress(Addressbook addressbook)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                addressbook = context.Addressbooks.Find(addressbook.PKAddressId);
                context.Addressbooks.Remove(addressbook);
                context.SaveChanges();
                trans.Complete();
                trans.Dispose();
            }
        }
    }
}
