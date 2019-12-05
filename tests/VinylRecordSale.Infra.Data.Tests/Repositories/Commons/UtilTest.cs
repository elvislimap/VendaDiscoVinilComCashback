using VinylRecordSale.Infra.Data.Repositories.Commons;
using Xunit;

namespace VinylRecordSale.Infra.Data.Tests.Repositories.Commons
{
    public class UtilTest
    {
        [Fact(DisplayName = "Util get skip")]
        [Trait("Category", "InfraCommons")]
        public void Util_GetSkip()
        {
            // Arrange
            const int page = 5;

            // Act
            var skip = Util.GetSkip(page);

            // Assert
            Assert.Equal(GetSkip(page), skip);
        }

        [Fact(DisplayName = "Util get take")]
        [Trait("Category", "InfraCommons")]
        public void Util_GetTake()
        {
            // Arrange & Act & Assert
            Assert.Equal(10, Util.Take);
        }


        private static int GetSkip(int page)
        {
            page = page == 0 ? 1 : page;
            return page * Util.Take - Util.Take;
        }
    }
}