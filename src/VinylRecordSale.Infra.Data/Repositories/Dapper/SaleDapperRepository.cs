using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Contexts;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Infra.Data.Repositories.Commons;
using VinylRecordSale.Infra.Data.Repositories.Dapper.Commons;

namespace VinylRecordSale.Infra.Data.Repositories.Dapper
{
    public class SaleDapperRepository : DapperRepositoryBase<Sale>, ISaleDapperRepository
    {
        private readonly IContextDapper _context;

        public SaleDapperRepository(IContextDapper context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> Get(int page, DateTime initialDate, DateTime finalDate)
        {
            return await _context.Connection.QueryAsync<Sale>(
                @"SELECT *
                  FROM VinylRecordSale.Sales
                  WHERE Date BETWEEN @initDate AND @finDate
                  ORDER BY Date DESC
                  OFFSET @skip ROWS
                  FETCH NEXT @take ROWS ONLY;",
                param: new
                {
                    initDate = initialDate,
                    finDate = finalDate,
                    skip = Util.GetSkip(page),
                    take = Util.Take
                });
        }

        public override async Task<Sale> GetById(int id)
        {
            var saleDictionary = new Dictionary<int, Sale>();

            return (await _context.Connection.QueryAsync<Sale, ItemSale, VinylDisc, Sale>(
                @"SELECT *
                  FROM VinylRecordSale.Sales s
                  INNER JOIN VinylRecordSale.ItemSales i ON s.SaleId = i.SaleId
                  INNER JOIN VinylRecordSale.VinylDiscs v ON i.VinylDiscId = v.VinylDiscId
                  WHERE s.SaleId = @saleId;",
                map: (sale, itemSale, vinylDisc) => MapSaleDapperQuery(saleDictionary, sale, itemSale, vinylDisc),
                splitOn: "SaleId, ItemSaleId, VinylDiscId",
                param: new { saleId = id })).FirstOrDefault();
        }


        private static Sale MapSaleDapperQuery(IDictionary<int, Sale> saleDictionary, Sale sale,
            ItemSale itemSale, VinylDisc vinylDisc)
        {
            if (!saleDictionary.TryGetValue(sale.SaleId, out var saleEntry))
            {
                saleEntry = sale;
                saleDictionary.Add(saleEntry.SaleId, saleEntry);
            }

            itemSale.SetVinylDisc(vinylDisc);
            saleEntry.AddItemSale(itemSale);

            return saleEntry;
        }
    }
}