using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contect_Manager_Repose.DB;
using Contact_Manager_model;

namespace Contect_Manager_Repose.BO
{
    class StateBO
    {
        StateDB StateDB;
        //for getting the data from the table
        public object GetStates()
        {
            StateDB = new StateDB();
            return StateDB.GetState();
        }
        //for adding the data in the table
        public void AddState(State state)
        {
            StateDB = new StateDB();
            StateDB.AddState(state);
        }
        //for Updating the data in the table
        public void UpdateState(State state)
        {
            StateDB = new StateDB();
            StateDB.UpdateState(state);
        }
        //for deleting the data from the table
        public void DeleteState(State state)
        {
            StateDB = new StateDB();
            StateDB.DeleteState(state);
        }
        //for filtering the data 
        public List<State> FilterState(int Id)
        {
            StateDB = new StateDB();
            return StateDB.FilteredState(Id);
        }
    }
}
