using System;
using System.Collections.Generic;

namespace VinylRecordSale.Domain.Entities
{
    public class Sale : Entity
    {
        public Sale() { }

        public Sale(int saleId, int clientId, decimal totalValue, decimal cashbackTotal,
            DateTime date)
        {
            SaleId = saleId;
            ClientId = clientId;
            TotalValue = totalValue;
            CashbackTotal = cashbackTotal;
            Date = date;
        }

        public int SaleId { get; set; }
        public int ClientId { get; set; }
        public decimal TotalValue { get; set; }
        public decimal CashbackTotal { get; set; }
        public DateTime Date { get; set; }
        public virtual Client Client { get; set; }
        public virtual IList<ItemSale> ItemSales { get; set; }

        public void AddItemSale(ItemSale itemSale)
        {
            ItemSales = ItemSales ?? new List<ItemSale>();
            ItemSales.Add(itemSale);
        }

        public void SetDateNow()
        {
            Date = DateTime.Now;
        }
    }
}