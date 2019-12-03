using System.Data;

namespace VinylRecordSale.Domain.Interfaces.Contexts
{
    public interface IContextDapper
    {
        IDbConnection Connection { get; set; }
    }
}