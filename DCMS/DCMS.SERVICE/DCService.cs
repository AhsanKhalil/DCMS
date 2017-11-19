using DataObjects.Linq2SQL.Dao;
using DataObjects.Linq2SQL.Data;
using DataObjects.Linq2SQL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCMS.SERVICE
{
    public class DCService : IDCService
    {
        private static IDaoFactory factory;
        private static ILocationDao locationDao;

        public DCService()
            : this(new DaoFactory())
        {

        }

        public DCService(IDaoFactory factory)
        {
            if (DCService.factory == null)
            {
                DCService.factory = factory;
                locationDao = factory.LocationDao;
            }
        }

        #region Location
        public List<LOCATION> GetAllLocation()
        {
            return locationDao.GetAll();
        }
        public LOCATION GetLocation(int id)
        {
            return locationDao.Get(id);
        }
        public void SaveLocation(LOCATION location)
        {
            locationDao.Insert(location);
        }
        public void UpdateLocation(LOCATION location)
        {
            locationDao.Update(location);
        }
        public void DeleteLocation(int id)
        {
            locationDao.Delete(id);
        }
        #endregion 


        public List<ORGANIZATION> GetAllOrganization()
        {
            throw new NotImplementedException();
        }

        public ORGANIZATION GetOrganization(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveOrganization(ORGANIZATION organization)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrganization(ORGANIZATION organization)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrganization(int id)
        {
            throw new NotImplementedException();
        }
    }
}
