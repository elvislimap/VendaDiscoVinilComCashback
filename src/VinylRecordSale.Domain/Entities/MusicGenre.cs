using System.Collections.Generic;

namespace VinylRecordSale.Domain.Entities
{
    public class MusicGenre
    {
        public int MusicGenreId { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<VinylDisc> VinylDiscs { get; set; }
    }
}