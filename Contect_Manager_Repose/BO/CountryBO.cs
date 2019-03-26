using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact_Manager_model;
using Contect_Manager_Repose.DB;

namespace Contect_Manager_Repose.BO
{
    class CountryBO
    {
        CountryDB countryDB;
        //for getting the data table    
        public  List<Country> GetCountries()
        {
            countryDB = new CountryDB();
             return countryDB.Getcountry();
        }
        //for adding the data in the table
        public void AddCountry(Country country)
        {
            countryDB = new CountryDB();
            countryDB.AddCountry(country);
        }
        //for Updating the data in the table
        public void UpdateCountry(Country country)
        {
            countryDB = new CountryDB();
            countryDB.UpdateCountry(country);
        }
        //for Deleteing the data from the table
        public void DeleteCountry(Country country)
        {
            countryDB = new CountryDB();
            countryDB.DeleteCountry(country);
        }
        //for filtering 
        public List<Country> FilteredCountry(int a)
        {
            List<Country> qry;
            qry = countryDB.Getcountry();
            countryDB = new CountryDB();
            if (a==1)
            {
                qry = qry.Where(e1 => e1.IsActive == true).ToList();
            }
            else
            {
                qry = qry.Where(e1 => e1.IsActive == false).ToList();
            }
            return qry;
        }
    }
}
