using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact_Manager_model;
using System.Transactions;

namespace Contect_Manager_Repose.DB
{
    public class StateDB
    {
        AddressBookEntities context=new AddressBookEntities();
        //for getting the data from the table
        public  object GetState()
        {
            AddressBookEntities context1 = new AddressBookEntities();
            var qry = context1.States.ToList();
            var qry1 = context1.Countries.ToList();
            var qry2 = qry.Join(qry1, e1 => e1.FKCountryId, c1 => c1.PKCountryId, (e1, c1) => new
            {
                e1.PKStateId,
                FKCountryId = c1.PKCountryId,
                c1.CountryName,
                e1.StateName,
                e1.IsActive
            }).ToList();
            return qry2;
        }
        //for filtering the data for the grid
        public List<State> FilteredState(int id)
        {
            return context.States.Where(e1=>e1.FKCountryId==id).ToList();
        }
        //for adding the data in the table
        public void AddState(State state)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                context.States.Add(state);
                context.SaveChanges();
                trans.Complete();
                trans.Dispose();
            }
        }
        //for updating the data in the table
        public void UpdateState(State state)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                State update = context.States.First(e1 => e1.PKStateId == state.PKStateId);
                update.StateName = state.StateName;
                update.FKCountryId = state.FKCountryId;
                update.IsActive = state.IsActive;
                context.SaveChanges();
                trans.Complete();
                trans.Dispose();
            }
        }
        //for Deleteing the data from the state table
        public void DeleteState(State state)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                State delete = context.States.Find(state.PKStateId);
                context.States.Remove(delete);
                context.SaveChanges();
                trans.Complete();
                trans.Dispose();
            }
        }
        
    }
}
