using System;
using VinylRecordSale.Application.Interfaces;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.Interfaces.Services;
using VinylRecordSale.Domain.ValueObjects;

namespace VinylRecordSale.Application.Services
{
    public class SaleAppService : ISaleAppService
    {
        private readonly ISaleDapperRepository _saleDapperRepository;
        private readonly ISaleService _saleService;

        public SaleAppService(ISaleDapperRepository saleDapperRepository, ISaleService saleService)
        {
            _saleDapperRepository = saleDapperRepository;
            _saleService = saleService;
        }


        public Result Insert(Sale sale)
        {
            sale.SetDateNow();

            if (!sale.IsValid())
                return new Result(sale.ValidationResult, false);

            _saleService.Insert(sale);
            var ok = sale.ValidationResult?.IsValid ?? true;

            return new Result(ok ? sale : sale.ValidationResult as object, ok);
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