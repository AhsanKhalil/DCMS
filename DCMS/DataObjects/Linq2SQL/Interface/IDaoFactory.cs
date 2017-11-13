using DataObjects.Linq2SQL.Interface;

namespace DataObjects.Linq2SQL.Interface
{
    public interface IDaoFactory
    {
        ILocationDao LocationDao { get; }
    }
}