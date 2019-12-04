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

        public int VinylDiscId { get; set; }
        public int MusicGenreId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public virtual MusicGenre MusicGenre { get; set; }
        public virtual IList<ItemSale> ItemSales { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new VinylDiscValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public void SetMusicGenre(MusicGenre musicGenre)
        {
            MusicGenre = musicGenre;
        }
    }
}