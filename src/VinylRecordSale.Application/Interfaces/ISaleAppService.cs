using System;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.ValueObjects;

namespace VinylRecordSale.Application.Interfaces
{
    public interface ISaleAppService
    {
        Result Insert(Sale sale);
        Result Get(int saleId);
        Result GetPaged(int page, DateTime initialDate, DateTime finalDate);
    }
}