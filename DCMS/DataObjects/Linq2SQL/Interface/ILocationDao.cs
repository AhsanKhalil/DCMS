using System.Collections.Generic;
using DataObjects.Linq2SQL.Data;

namespace DataObjects.Linq2SQL.Interface
{
    public interface ILocationDao
    {
        void Delete(int id);
        LOCATION Get(int id);
        List<LOCATION> GetAll();
        void Insert(LOCATION location);
        void Update(LOCATION location);
    }
}