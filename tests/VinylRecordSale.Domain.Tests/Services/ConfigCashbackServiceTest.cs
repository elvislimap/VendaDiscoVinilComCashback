using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Moq;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Enums;
using VinylRecordSale.Domain.Interfaces.Repositories.Dapper;
using VinylRecordSale.Domain.Services;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Services
{
    public class ConfigCashbackServiceTest
    {
        [Fact(DisplayName = "Get Config cashback success")]
        [Trait("Category", "Services")]
        public async Task ConfigCashback_Get_Success()
        {
            // Arrange
            const int musicGenreId = (int)MusicGenreEnum.Rock;
            var configCashBack = new ConfigCashback(1, 10M, 20M, 15M, 8M, 3M, 5M, 4M);
            var mocker = new AutoMocker();
            var configCashbackService = mocker.CreateInstance<ConfigCashbackService>();

            mocker.GetMock<IConfigCashbackDapperRepository>().Setup(c => c.GetById(musicGenreId))
                .Returns(Task.FromResult(configCashBack));

            // Act
            var percentageResult = await configCashbackService.GetPercentage(musicGenreId);

            // Assert
            Assert.Equal(GetPercentageByDayOfWeek(configCashBack), percentageResult);
            mocker.GetMock<IConfigCashbackDapperRepository>().Verify(c => c.GetById(musicGenreId), Times.Once);
        }

        [Fact(DisplayName = "Get Config cashback error")]
        [Trait("Category", "Services")]
        public async Task ConfigCashback_Get_Error()
        {
            // Arrange
            const int musicGenreId = (int)MusicGenreEnum.Rock;
            var mocker = new AutoMocker();
            var configCashbackService = mocker.CreateInstance<ConfigCashbackService>();

            mocker.GetMock<IConfigCashbackDapperRepository>().Setup(c => c.GetById(musicGenreId))
                .Returns(Task.FromResult(new ConfigCashback()));

            // Act
            var percentageResult = await configCashbackService.GetPercentage(musicGenreId);

            // Assert
            Assert.Equal(0, percentageResult);
        }


        private static decimal GetPercentageByDayOfWeek(ConfigCashback configCashback)
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return configCashback.PercentageSunday;
                case DayOfWeek.Monday:
                    return configCashback.PercentageMonday;
                case DayOfWeek.Tuesday:
                    return configCashback.PercentageTuesday;
                case DayOfWeek.Wednesday:
                    return configCashback.PercentageWednesday;
                case DayOfWeek.Thursday:
                    return configCashback.PercentageThursday;
                case DayOfWeek.Friday:
                    return configCashback.PercentageFriday;
                case DayOfWeek.Saturday:
                    return configCashback.PercentageSaturday;
                default:
                    return 0;
            }
        }
    }
}