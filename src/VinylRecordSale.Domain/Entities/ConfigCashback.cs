namespace VinylRecordSale.Domain.Entities
{
    public class ConfigCashback : Entity
    {
        public ConfigCashback() { }

        public ConfigCashback(int musicGenreId, decimal percentageSunday, decimal percentageMonday,
            decimal percentageTuesday, decimal percentageWednesday, decimal percentageThursday,
            decimal percentageFriday, decimal percentageSaturday)
        {
            MusicGenreId = musicGenreId;
            PercentageSunday = percentageSunday;
            PercentageMonday = percentageMonday;
            PercentageTuesday = percentageTuesday;
            PercentageWednesday = percentageWednesday;
            PercentageThursday = percentageThursday;
            PercentageFriday = percentageFriday;
            PercentageSaturday = percentageSaturday;
        }

        public int MusicGenreId { get; set; }
        public decimal PercentageSunday { get; set; }
        public decimal PercentageMonday { get; set; }
        public decimal PercentageTuesday { get; set; }
        public decimal PercentageWednesday { get; set; }
        public decimal PercentageThursday { get; set; }
        public decimal PercentageFriday { get; set; }
        public decimal PercentageSaturday { get; set; }

        public static bool Exists(ConfigCashback configCashback)
        {
            return (configCashback?.MusicGenreId ?? 0) > 0;
        }
    }
}