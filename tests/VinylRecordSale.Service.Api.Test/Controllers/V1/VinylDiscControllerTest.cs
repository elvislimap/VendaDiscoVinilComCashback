using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Service.Api.Controllers.V1;
using Xunit;

namespace VinylRecordSale.Service.Api.Test.Controllers.V1
{
    public class VinylDiscControllerTest
    {
        [Fact(DisplayName = "VinylDiscController get by id")]
        [Trait("Category", "Controller")]
        public async void VinylDiscController_GetById()
        {
            // Arrange
            var vinylDisc = new Faker<VinylDisc>().CustomInstantiator(f =>
                    new VinylDisc(f.Random.Int(1, 50), f.Random.Int(1, 50), f.Name.FullName(),
                        f.Random.Decimal(1, 100)))
                .Generate();
            var mocker = new AutoMocker();

            mocker.GetMock<IVinylDiscDapperRepository>().Setup(v => v.GetById(vinylDisc.VinylDiscId))
                .Returns(Task.FromResult(vinylDisc));

            var controller = mocker.CreateInstance<VinylDiscController>();

            // Act
            var result = await controller.GetById(vinylDisc.VinylDiscId);
            var okResult = result.Result as OkObjectResult;

            // Asserts
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact(DisplayName = "VinylDiscController get paged")]
        [Trait("Category", "Controller")]
        public async void VinylDiscController_GetPaged()
        {
            // Arrange
            var page = new Faker().Random.Int(1, 5);
            var musicGenreId = new Faker().Random.Int(1, 4);
            var vinylDiscs = new Faker<VinylDisc>().CustomInstantiator(f =>
                    new VinylDisc(f.Random.Int(1, 50), f.Random.Int(1, 50), f.Name.FullName(),
                        f.Random.Decimal(1, 100)))
                .Generate(3)
                .Where(v => v.VinylDiscId > 0);
            var mocker = new AutoMocker();

            mocker.GetMock<IVinylDiscDapperRepository>().Setup(v => v.Get(page, musicGenreId))
                .Returns(Task.FromResult(vinylDiscs));

            var controller = mocker.CreateInstance<VinylDiscController>();

            // Act
            var result = await controller.GetPaged(page, musicGenreId);
            var okResult = result.Result as OkObjectResult;

            // Asserts
            Assert.NotNull(okResult);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }
    }
}