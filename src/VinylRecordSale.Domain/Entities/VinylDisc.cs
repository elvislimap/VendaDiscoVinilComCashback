using System.Collections.Generic;

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

        public void SetMusicGenre(MusicGenre musicGenre)
        {
            MusicGenre = musicGenre;
        }

        public static bool Exists(VinylDisc vinylDisc)
        {
            return (vinylDisc?.VinylDiscId ?? 0) > 0;
        }
    }
}