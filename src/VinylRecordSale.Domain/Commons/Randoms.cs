using System;

namespace VinylRecordSale.Domain.Commons
{
    public class Randoms
    {
        private static readonly Random _random = new Random();

        public static decimal Decimal(double minValue, double maxValue)
        {
            var next = _random.NextDouble();
            var valueRandom = minValue + (next * (maxValue - minValue));

            return Math.Round(Convert.ToDecimal(valueRandom), 2);
        }
    }
}