using System;
using VinylRecordSale.Application.Interfaces;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.ValueObjects;

namespace VinylRecordSale.Application.Services
{
    public class SaleAppService : ISaleAppService
    {
        private readonly ISaleDapperRepository _saleDapperRepository;

        public SaleAppService(ISaleDapperRepository saleDapperRepository)
        {
            _saleDapperRepository = saleDapperRepository;
        }


        public Result Insert(Sale sale)
        {
            if (!sale.IsValid())
                return new Result(sale.ValidationResult, false);

            // Verify exists client

            // Verify exists ids vinylDiscs
            // Calculate value by quantity
            // Calculate cashback by quantity

            // Sum total value
            // Sum total cashback

            // Insert

            return new Result(null);
        }

        public Result Get(int saleId)
        {
            return new Result(_saleDapperRepository.GetById(saleId));
        }

        public Result GetPaged(int page, DateTime initialDate, DateTime finalDate)
        {
            return new Result(_saleDapperRepository.Get(page, initialDate, finalDate));
        }
    }
}