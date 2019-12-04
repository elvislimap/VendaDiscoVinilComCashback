using VinylRecordSale.Domain.Validations;

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

        public int ItemSaleId { get; private set; }
        public int SaleId { get; private set; }
        public int VinylDiscId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public decimal Cashback { get; private set; }

        public virtual Sale Sale { get; private set; }
        public virtual VinylDisc VinylDisc { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new ItemSaleValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public void AddVinylDisc(VinylDisc vinylDisc)
        {
            VinylDisc = vinylDisc;
        }
    }
}