using DataObjects.Linq2SQL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Linq2SQL.Dao
{
    public class DaoFactory : IDaoFactory
    {
        public ILocationDao LocationDao { get { return new LocationDao(); } }

    }
}
