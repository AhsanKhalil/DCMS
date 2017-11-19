using System.Collections.Generic;
using DataObjects.Linq2SQL.Data;

namespace DCMS.SERVICE
{
    public interface IDCService
    {
        void DeleteLocation(int id);
        List<LOCATION> GetAllLocation();
        LOCATION GetLocation(int id);
        void SaveLocation(LOCATION location);
        void UpdateLocation(LOCATION location);
        List<ORGANIZATION> GetAllOrganization();
        ORGANIZATION GetOrganization(int id);
        void SaveOrganization(ORGANIZATION organization);
        void UpdateOrganization(ORGANIZATION organization);
        void DeleteOrganization(int id);
    }
}
