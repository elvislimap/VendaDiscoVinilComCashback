using System.Collections.Generic;
using VinylRecordSale.Domain.Validations;

namespace VinylRecordSale.Domain.Entities
{
    public class MusicGenre : Entity
    {
        public MusicGenre() { }

        public MusicGenre(int musicGenreId, string description)
        {
            MusicGenreId = musicGenreId;
            Description = description;
        }

        public int MusicGenreId { get; set; }
        public string Description { get; set; }
        public virtual IList<VinylDisc> VinylDiscs { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new MusicGenreValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}