using Bogus;
using Moq;
using Moq.AutoMock;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.Interfaces.Services;
using VinylRecordSale.Domain.Services;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Services
{
    public class ItemSaleServiceTest
    {
        [Fact(DisplayName = "Calculate properties item sale success")]
        [Trait("Category", "Services")]
        public async Task ItemSale_CalculateProperties_Success()
        {
            // Arrange
            var mocker = new AutoMocker();
            var itemSales = new List<ItemSale> { new ItemSale(0, 0, 1, 2, 0, 0) };
            var percentage = new Faker().Random.Decimal(1, 50);
            var vinylDisc = new Faker<VinylDisc>()
                .CustomInstantiator(f => new VinylDisc(f.Random.Int(1, 20), f.Random.Int(1, 20), f.Lorem.Letter(20),
                    f.Random.Decimal(1M, 100M)))
                .Generate();

            mocker.GetMock<IVinylDiscDapperRepository>().Setup(v => v.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(vinylDisc));

            mocker.GetMock<IConfigCashbackService>().Setup(c => c.GetPercentage(It.IsAny<int>()))
                .Returns(Task.FromResult(percentage));

            var itemSaleService = mocker.CreateInstance<ItemSaleService>();

            // Act
            await itemSaleService.CalculateProperties(itemSales);

            // Assert
            Assert.True(itemSales.All(i => i.Value > 0));
            Assert.True(itemSales.All(i => i.Cashback > 0));
            mocker.GetMock<IVinylDiscDapperRepository>()
                .Verify(v => v.GetById(It.IsAny<int>()), Times.AtMost(itemSales.Count));
            mocker.GetMock<IConfigCashbackService>()
                .Verify(c => c.GetPercentage(It.IsAny<int>()), Times.AtMost(itemSales.Count));
        }

        [Fact(DisplayName = "Calculate properties item sale error")]
        [Trait("Category", "Services")]
        public async Task ItemSale_CalculateProperties_Error()
        {
            // Arrange
            var mocker = new AutoMocker();
            var itemSales = new List<ItemSale> { new ItemSale(0, 0, 1, 0, 0, 0) };
            var itemSaleService = mocker.CreateInstance<ItemSaleService>();

            // Act
            await itemSaleService.CalculateProperties(itemSales);

            // Assert
            Assert.True(itemSales.All(i => i.Value == 0));
            Assert.True(itemSales.All(i => i.Cashback == 0));
        }
    }
}