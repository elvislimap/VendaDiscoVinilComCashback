using System.Linq;
using System.Threading.Tasks;
using VinylRecordSale.Application.Interfaces;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.Interfaces.Repositories.EntityFramework;
using VinylRecordSale.Domain.Interfaces.Services;
using VinylRecordSale.Domain.Validations;

namespace VinylRecordSale.Application.Services
{
    public class SaleAppService : BaseAppService, ISaleAppService
    {
        private readonly ISaleEFRepository _saleEfRepository;
        private readonly IClientDapperRepository _clientDapperRepository;
        private readonly IItemSaleService _itemSaleService;

        public SaleAppService(INotificationService notificationService,
            ISaleEFRepository saleEfRepository,
            IClientDapperRepository clientDapperRepository,
            IItemSaleService itemSaleService) : base(notificationService)
        {
            _saleEfRepository = saleEfRepository;
            _clientDapperRepository = clientDapperRepository;
            _itemSaleService = itemSaleService;
        }


        public async Task<Sale> Insert(Sale sale)
        {
            sale.SetDateNow();

            if (!ExecuteValidation(new SaleValidation(), sale)) return null;

            if (!Client.Exists(await _clientDapperRepository.GetById(sale.ClientId)))
            {
                Notify("Client not exists");
                return null;
            }

            await _itemSaleService.CalculateProperties(sale.ItemSales);

            if (HaveNotification()) return null;

            sale.TotalValue = sale.ItemSales.Sum(i => i.Value);
            sale.CashbackTotal = sale.ItemSales.Sum(i => i.Cashback);

            _saleEfRepository.Insert(sale);

            return sale;
        }
    }
}