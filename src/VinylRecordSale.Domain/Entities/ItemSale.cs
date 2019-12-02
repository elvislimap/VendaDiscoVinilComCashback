namespace VinylRecordSale.Domain.Entities
{
    public class ItemSale
    {
        public int ItemSaleId { get; set; }
        public int SaleId { get; set; }
        public int VinylDiscId { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal Cashback { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual VinylDisc VinylDisc { get; set; }
    }
}