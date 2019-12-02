namespace VinylRecordSale.Domain.Entities
{
    public class ConfigCashback
    {
        public int ConfigCashbackId { get; set; }
        public int GenreId { get; set; }
        public decimal PercentageSunday  { get; set; }
        public decimal PercentageMonday { get; set; }
        public decimal PercentageTuesday { get; set; }
        public decimal PercentageWednesday { get; set; }
        public decimal PercentageThursday { get; set; }
        public decimal PercentageFriday { get; set; }
        public decimal PercentageSaturday { get; set; }

        public virtual MusicGenre MusicGenre { get; set; }
    }
}