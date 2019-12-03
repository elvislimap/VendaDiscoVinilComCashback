using System;
using System.Collections.Generic;
using VinylRecordSale.Domain.Validations;

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

        public int SaleId { get; private set; }
        public int ClientId { get; private set; }
        public decimal TotalValue { get; private set; }
        public decimal CashbackTotal { get; private set; }
        public DateTime Date { get; private set; }

        public virtual Client Client { get; private set; }
        public virtual IEnumerable<ItemSale> ItemSales { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new SaleValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}