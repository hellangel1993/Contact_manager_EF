using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact_Manager_model;
using Contect_Manager_Repose.BO;
using System.Transactions;

namespace Contect_Manager_Repose.DB
{
    public class CountryDB
    {
        AddressBookEntities context = new AddressBookEntities();
        //for getting the data form the table
        public List<Country> Getcountry()
        {
            AddressBookEntities context1 = new AddressBookEntities();
            var qry = context1.Countries.ToList();
            return qry;
        }
        //for adding the data in the table
        public  void AddCountry(Country country)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                context.Countries.Add(country);
                context.SaveChanges();
                trans.Complete();
                trans.Dispose();
            }
        }
        //for updateing the data in ther country
        public void UpdateCountry(Country country)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                Country update = context.Countries.Where(e1 => e1.PKCountryId == country.PKCountryId).Select(e1 => e1).FirstOrDefault();
                update.CountryName = country.CountryName;
                update.ZipCodeStart = country.ZipCodeStart;
                update.ZipCodeEnd = country.ZipCodeEnd;
                update.IsActive = country.IsActive;
                context.SaveChanges();
                trans.Complete();
                trans.Dispose();
            }
        }
        //for deleteing the data from the country
        public void DeleteCountry(Country country)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                Country delete = context.Countries.Find(country.PKCountryId);
                context.Countries.Remove(delete);
                context.SaveChanges();
                trans.Complete();
                trans.Dispose();
            }
        }
    }
}
