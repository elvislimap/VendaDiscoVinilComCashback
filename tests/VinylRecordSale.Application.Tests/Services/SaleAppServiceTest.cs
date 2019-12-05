using Bogus;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinylRecordSale.Application.Services;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.Interfaces.Repositories.EntityFramework;
using VinylRecordSale.Domain.Interfaces.Services;
using Xunit;

namespace VinylRecordSale.Application.Tests.Services
{
    public class SaleAppServiceTest
    {
        [Fact(DisplayName = "Sale insert is valid")]
        [Trait("Category", "AppServices")]
        public async void SaleAppService_Insert_IsValid()
        {
            // Arrange
            var sale = new Sale(0, new Faker().Random.Int(1, 100), 0, 0, DateTime.MinValue)
            {
                ItemSales = new List<ItemSale>
                {
                    new ItemSale(0, 0, new Faker().Random.Int(1, 200),
                        new Faker().Random.Int(0, 10), 0, 0)
                }
            };

            var mocker = new AutoMocker();

            mocker.GetMock<IClientDapperRepository>().Setup(c => c.GetById(sale.ClientId))
                .Returns(Task.FromResult(new Client(1, "", "")));

            var saleAppService = mocker.CreateInstance<SaleAppService>();

            // Act
            var result = await saleAppService.Insert(sale);

            // Assert
            Assert.Equal(sale, result);
            mocker.GetMock<IClientDapperRepository>().Verify(c => c.GetById(sale.ClientId), Times.Once);
            mocker.GetMock<IItemSaleService>().Verify(i => i.CalculateProperties(sale.ItemSales), Times.Once);
            mocker.GetMock<ISaleEFRepository>().Verify(s => s.Insert(sale), Times.Once);
        }

        [Fact(DisplayName = "Sale insert is invalid")]
        [Trait("Category", "AppServices")]
        public async void SaleAppService_Insert_IsInvalid()
        {
            // Arrange
            var sale = new Sale();
            var mocker = new AutoMocker();
            var saleAppService = mocker.CreateInstance<SaleAppService>();

            // Act
            var result = await saleAppService.Insert(sale);

            // Assert
            Assert.Null(result);
            mocker.GetMock<IClientDapperRepository>().Verify(c => c.GetById(It.IsAny<int>()), Times.Never);
            mocker.GetMock<IItemSaleService>()
                .Verify(i => i.CalculateProperties(It.IsAny<IList<ItemSale>>()), Times.Never);
            mocker.GetMock<ISaleEFRepository>().Verify(s => s.Insert(It.IsAny<Sale>()), Times.Never);
        }
    }
}