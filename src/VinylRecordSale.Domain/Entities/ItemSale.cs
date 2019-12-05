namespace VinylRecordSale.Domain.Entities
{
    public class ItemSale : Entity
    {
        public ItemSale() { }

        public ItemSale(int itemSaleId, int saleId, int vinylDiscId, int quantity,
            decimal value, decimal cashback)
        {
            ItemSaleId = itemSaleId;
            SaleId = saleId;
            VinylDiscId = vinylDiscId;
            Quantity = quantity;
            Value = value;
            Cashback = cashback;
        }

        public int ItemSaleId { get; set; }
        public int SaleId { get; set; }
        public int VinylDiscId { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal Cashback { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual VinylDisc VinylDisc { get; set; }

        public void SetVinylDisc(VinylDisc vinylDisc)
        {
            VinylDisc = vinylDisc;
        }

        public void SetValue(int quantity, decimal unitValue)
        {
            Value = quantity * unitValue;
        }

        public void SetCashback(decimal value, decimal percentage)
        {
            Cashback = value * (percentage / 100);
        }
    }
}