using System;
using VinylRecordSale.Domain.Commons;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Commons
{
    public class RandomTest
    {
        [Fact(DisplayName = "Random decimal")]
        [Trait("Category", "DomainCommons")]
        public void Commons_RandomDecimal()
        {
            // Arrange
            const double min = 200.78;
            const double max = 1799.99;

            // Act
            var result = Randoms.Decimal(min, max);

            // Assert
            Assert.InRange(result, Convert.ToDecimal(min), Convert.ToDecimal(max));
        }
    }
}