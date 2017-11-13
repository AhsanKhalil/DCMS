using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects.Linq2SQL.Data;
using DataObjects.Linq2SQL.Interface;

namespace DataObjects.Linq2SQL.Dao
{
    public class LocationDao : ILocationDao
    {
        public List<LOCATION> GetAll()
        {
            using (var dataContext = new DCMSDataContext())
            {
                return dataContext.LOCATIONs.ToList();
            }
        }

        public LOCATION Get(int id)
        {
            using (var dataContext = new DCMSDataContext())
            {
                return dataContext.LOCATIONs.FirstOrDefault(m => m.ID == id);
            }
        }

        public void Insert(LOCATION location)
        {
            using (var dataContext = new DCMSDataContext())
            {

                if (dataContext.LOCATIONs.Count() != 0)
                    location.ID = dataContext.LOCATIONs.Select(m => m.ID).Max() + 1;
                else
                    location.ID = 1;

                dataContext.LOCATIONs.InsertOnSubmit(location);
                dataContext.SubmitChanges();
                
            }
        }

        public void Update(LOCATION location)
        {
            using (var dataContext = new DCMSDataContext())
            {
                LOCATION orignalLoca = dataContext.LOCATIONs.FirstOrDefault(m => m.ID == location.ID);


                orignalLoca.ADDRESS = location.ADDRESS;
                orignalLoca.CITY = location.CITY;
                orignalLoca.CONTACT_1 = location.CONTACT_1;
                orignalLoca.CONTACT_2 = location.CONTACT_2;
                orignalLoca.CONTACT_3 = location.CONTACT_3;
                orignalLoca.EMAIL = location.EMAIL;
                orignalLoca.FAX_NO = location.FAX_NO;
                orignalLoca.MODIFIED_ON = location.MODIFIED_ON;
                orignalLoca.MODIFIED_USER = location.MODIFIED_USER;
                orignalLoca.NAME = location.NAME;

                dataContext.SubmitChanges();
                
            }
        }

        public void Delete(int id)
        {
            using (var dataContext = new DCMSDataContext())
            {
                LOCATION getlocation = dataContext.LOCATIONs.FirstOrDefault(m=>m.ID==id);
                
                dataContext.LOCATIONs.DeleteOnSubmit(getlocation);
                dataContext.SubmitChanges();
                
            }
        }
    }
}
