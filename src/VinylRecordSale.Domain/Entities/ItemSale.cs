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

        public Sale Sale { get; set; }
        public VinylDisc VinylDisc { get; set; }
    }
}