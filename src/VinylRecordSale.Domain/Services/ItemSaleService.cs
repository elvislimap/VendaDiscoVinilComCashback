using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.Interfaces.Services;
using VinylRecordSale.Domain.Validations;

namespace VinylRecordSale.Domain.Services
{
    public class ItemSaleService : BaseService, IItemSaleService
    {
        private readonly IVinylDiscDapperRepository _vinylDiscDapperRepository;
        private readonly IConfigCashbackService _configCashbackService;

        public ItemSaleService(INotificationService notificationService,
            IVinylDiscDapperRepository vinylDiscDapperRepository,
            IConfigCashbackService configCashbackService) : base(notificationService)
        {
            _vinylDiscDapperRepository = vinylDiscDapperRepository;
            _configCashbackService = configCashbackService;
        }


        public async Task CalculateProperties(IEnumerable<ItemSale> itemSales)
        {
            if (!itemSales.Any())
            {
                ExecuteValidation(new ItemSaleValidation(), new ItemSale());
                return;
            }

            foreach (var itemSale in itemSales)
            {
                var vinylDisc = await _vinylDiscDapperRepository.GetById(itemSale.VinylDiscId);

                if (!VinylDisc.Exists(vinylDisc))
                {
                    Notify($"VinylDiscId: {itemSale.VinylDiscId} not exists");
                    return;
                }

                itemSale.SetValue(itemSale.Quantity, vinylDisc.Value);
                itemSale.SetCashback(itemSale.Value, await _configCashbackService.GetPercentage(vinylDisc.MusicGenreId));

                if (!ExecuteValidation(new ItemSaleValidation(), itemSale))
                    return;
            }
        }
    }
}