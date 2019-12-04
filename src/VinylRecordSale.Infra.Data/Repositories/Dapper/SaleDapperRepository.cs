using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Contexts;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
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

        public IEnumerable<Sale> Get(int page, DateTime initialDate, DateTime finalDate)
        {
            var saleDictionary = new Dictionary<int, Sale>();

            return _context.Connection.Query<Sale, ItemSale, VinylDisc, Sale>(
                @"SELECT *
                  FROM VinylRecordSale.Sales s
                  INNER JOIN VinylRecordSale.ItemSales i ON s.SaleId = i.SaleId
                  INNER JOIN VinylRecordSale.VinylDiscs v ON i.VinylDiscId = v.VinylDiscId
                  WHERE s.Date BETWEEN @initDate AND @finDate
                  ORDER BY s.Date DESC
                  OFFSET @skip ROWS
                  FETCH NEXT @take ROWS ONLY;",
                map: (sale, itemSale, vinylDisc) =>
                {
                    return MapSaleDapperQuery(saleDictionary, sale, itemSale, vinylDisc);
                },
                splitOn: "SaleId, VinylDiscId",
                param: new
                {
                    initDate = initialDate,
                    finDate = finalDate,
                    skip = Util.GetSkip(page),
                    take = Util.Take
                });
        }

        public override Sale GetById(int id)
        {
            var saleDictionary = new Dictionary<int, Sale>();

            return _context.Connection.Query<Sale, ItemSale, VinylDisc, Sale>(
                @"SELECT TOP(1) *
                  FROM VinylRecordSale.Sales s
                  INNER JOIN VinylRecordSale.ItemSales i ON s.SaleId = i.SaleId
                  INNER JOIN VinylRecordSale.VinylDiscs v ON i.VinylDiscId = v.VinylDiscId
                  WHERE s.SaleId = @saleId;",
                map: (sale, itemSale, vinylDisc) =>
                {
                    return MapSaleDapperQuery(saleDictionary, sale, itemSale, vinylDisc);
                },
                splitOn: "SaleId, VinylDiscId",
                param: new { saleId = id }).FirstOrDefault();
        }


        private static Sale MapSaleDapperQuery(Dictionary<int, Sale> saleDictionary, Sale sale,
            ItemSale itemSale, VinylDisc vinylDisc)
        {
            if (!saleDictionary.TryGetValue(sale.SaleId, out var saleEntry))
            {
                saleEntry = sale;
                saleEntry.AddItemSales(new List<ItemSale>());
                saleDictionary.Add(saleEntry.SaleId, saleEntry);
            }

            itemSale.AddVinylDisc(vinylDisc);
            saleEntry.AddItemSale(itemSale);

            return saleEntry;
        }
    }
}