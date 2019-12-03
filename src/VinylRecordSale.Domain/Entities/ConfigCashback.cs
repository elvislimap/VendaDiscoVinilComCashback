using VinylRecordSale.Domain.Validations;

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

        public int MusicGenreId { get; private set; }
        public decimal PercentageSunday { get; private set; }
        public decimal PercentageMonday { get; private set; }
        public decimal PercentageTuesday { get; private set; }
        public decimal PercentageWednesday { get; private set; }
        public decimal PercentageThursday { get; private set; }
        public decimal PercentageFriday { get; private set; }
        public decimal PercentageSaturday { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new ConfigCashbackValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}