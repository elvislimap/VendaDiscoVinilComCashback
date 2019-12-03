using System.Collections.Generic;
using VinylRecordSale.Domain.Validations;

namespace VinylRecordSale.Domain.Entities
{
    public class VinylDisc : Entity
    {
        public VinylDisc() { }

        public VinylDisc(int vinylDiscId, int musicGenreId, string name, decimal value)
        {
            VinylDiscId = vinylDiscId;
            MusicGenreId = musicGenreId;
            Name = name;
            Value = value;
        }

        public int VinylDiscId { get; private set; }
        public int MusicGenreId { get; private set; }
        public string Name { get; private set; }
        public decimal Value { get; private set; }

        public virtual MusicGenre MusicGenre { get; private set; }
        public virtual IEnumerable<ItemSale> ItemSales { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new VinylDiscValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}