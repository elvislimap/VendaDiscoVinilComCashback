using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VinylRecordSale.Application.Interfaces;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Service.Api.Controllers.V1;
using Xunit;

namespace VinylRecordSale.Service.Api.Test.Controllers.V1
{
    public class SaleControllerTest
    {
        [Fact(DisplayName = "SaleController get by id")]
        [Trait("Category", "Controller")]
        public async void SaleController_GetById()
        {
            // Arrange
            var sale = new Faker<Sale>().CustomInstantiator(f =>
                    new Sale(f.Random.Int(1, 50), f.Random.Int(1, 50), f.Random.Decimal(20, 50),
                        f.Random.Decimal(1, 20), f.Date.Past()))
                .Generate();
            var mocker = new AutoMocker();

            mocker.GetMock<ISaleDapperRepository>().Setup(s => s.GetById(sale.SaleId))
                .Returns(Task.FromResult(sale));

            var controller = mocker.CreateInstance<SaleController>();

            // Act
            var result = await controller.GetById(sale.SaleId);
            var okResult = result.Result as OkObjectResult;

            // Asserts
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact(DisplayName = "SaleController get paged")]
        [Trait("Category", "Controller")]
        public async void SaleController_GetPaged()
        {
            // Arrange
            var page = new Faker().Random.Int(1, 5);
            var initialDate = DateTime.Now.AddDays(-5);
            var finalDate = DateTime.Now;
            var sales = new Faker<Sale>().CustomInstantiator(f =>
                    new Sale(f.Random.Int(1, 50), f.Random.Int(1, 50), f.Random.Decimal(20, 50),
                        f.Random.Decimal(1, 20), f.Date.Past()))
                .Generate(10)
                .Where(s => s.SaleId > 0);
            var mocker = new AutoMocker();

            mocker.GetMock<ISaleDapperRepository>().Setup(s => s.Get(page, initialDate, finalDate))
                .Returns(Task.FromResult(sales));

            var controller = mocker.CreateInstance<SaleController>();

            // Act
            var result = await controller.GetPaged(page, initialDate, finalDate);
            var okResult = result.Result as OkObjectResult;

            // Asserts
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact(DisplayName = "SaleController insert")]
        [Trait("Category", "Controller")]
        public async void SaleController_Insert()
        {
            // Arrange
            var sale = new Faker<Sale>().CustomInstantiator(f =>
                    new Sale(f.Random.Int(1, 50), f.Random.Int(1, 50), f.Random.Decimal(20, 50),
                        f.Random.Decimal(1, 20), f.Date.Past()))
                .Generate();
            var mocker = new AutoMocker();

            mocker.GetMock<ISaleAppService>().Setup(s => s.Insert(sale))
                .Returns(Task.FromResult(sale));

            var controller = mocker.CreateInstance<SaleController>();

            // Act
            var result = await controller.Insert(sale);
            var okResult = result as OkObjectResult;

            // Asserts
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }
    }
}