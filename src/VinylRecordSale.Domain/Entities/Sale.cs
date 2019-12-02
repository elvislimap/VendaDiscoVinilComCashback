﻿using System;
using System.Collections.Generic;

namespace VinylRecordSale.Domain.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int ClientId { get; set; }
        public decimal TotalValue { get; set; }
        public decimal CashbackTotal { get; set; }
        public DateTime Date { get; set; }

        public virtual Client Client { get; set; }
        public virtual IEnumerable<ItemSale> ItemSales { get; set; }
    }
}