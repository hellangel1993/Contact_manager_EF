using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact_Manager_model;
using System.Transactions;

namespace Contect_Manager_Repose.DB
{
    class UserDB
    {
        AddressBookEntities context = new AddressBookEntities();
        //for getting the data of the user
        public List<UserDetail> GetUserDetails()
        {
            List<UserDetail> qry = context.UserDetails.ToList();
            return qry;
        }
        //for adding in the userdetail
        public void AddUser(UserDetail userDetail)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                context.UserDetails.Add(userDetail);
                context.SaveChanges();
                trans.Complete();
                trans.Dispose();
            }
        }
        //for uodate in the userdetail
        public void Update(UserDetail user)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                UserDetail detail = context.UserDetails.First(e1 => e1.PKUserId == user.PKUserId);
                detail.UserName = user.UserName;
                detail.Password = user.Password;
                detail.FirstName = user.FirstName;
                detail.LastName = user.LastName;
                detail.EmailId = user.EmailId;
                detail.PhoneNo = user.PhoneNo;
                detail.IsActive = user.IsActive;
                context.SaveChanges();
                trans.Complete();
                trans.Dispose();
            }
        }
        //for deleting the data from the table
        public void DeleteUser(UserDetail user)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                UserDetail detail = context.UserDetails.Find(user.PKUserId);
                context.UserDetails.Remove(detail);
                context.SaveChanges();
                trans.Complete();
                trans.Dispose();
            }
        }
        //checking the username
        public bool UniqueUser(string userName)
        {
            bool flag = false;

            try
            {
                UserDetail user = context.UserDetails.Where(e1 => e1.UserName == userName).SingleOrDefault();
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
                
                
                
            
            return flag;
        }
        //for checking the existence of user
        public UserDetail AuthenticateUser(string UserName)
        {
            UserDetail user = context.UserDetails.Where(e1=>e1.UserName==UserName).SingleOrDefault();
            
            return user;

        }
    }
}
