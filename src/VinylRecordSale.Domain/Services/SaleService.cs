using FluentValidation.Results;
using VinylRecordSale.Domain.Commons;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.Interfaces.Services;

namespace VinylRecordSale.Domain.Services
{
    public class SaleService : ISaleService
    {
        private readonly IClientDapperRepository _clientDapperRepository;

        public SaleService(IClientDapperRepository clientDapperRepository)
        {
            _clientDapperRepository = clientDapperRepository;
        }

        public void Insert(Sale sale)
        {
            if ((_clientDapperRepository.GetById(sale.ClientId)?.ClientId ?? 0) == 0)
            {
                sale.SetValidationResult(new ValidationFailure("ClientId", "Client not exists").ToValidationResult());
                return;
            }

            // Verify exists ids vinylDiscs
            // Calculate value by quantity
            // Calculate cashback by quantity

            // Sum total value
            // Sum total cashback

            // Insert
        }
    }
}