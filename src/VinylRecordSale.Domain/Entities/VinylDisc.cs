using System.Collections.Generic;

namespace VinylRecordSale.Domain.Entities
{
    public class VinylDisc
    {
        public int VinylDiscId { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }

        public virtual MusicGenre MusicGenre { get; set; }
        public virtual IEnumerable<ItemSale> ItemSales { get; set; }
    }
}