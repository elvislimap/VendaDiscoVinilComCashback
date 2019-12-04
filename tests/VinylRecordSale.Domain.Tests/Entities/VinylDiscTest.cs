﻿using Bogus;
using VinylRecordSale.Domain.Entities;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    public class VinylDiscTest
    {
        [Fact(DisplayName = "New vinyl disc valid")]
        [Trait("Category", "Entities")]
        public void VinylDisc_NewVinylDisc_Valid()
        {
            // Arrange
            var vinylDisc = GetVinylDiscValid();

            // Act
            var isValid = vinylDisc.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(vinylDisc.ValidationResult.Errors);
        }

        [Fact(DisplayName = "New vinyl disc invalid")]
        [Trait("Category", "Entities")]
        public void VinylDisc_NewVinylDisc_Invalid()
        {
            // Arrange
            var vinylDisc = GetVinylDiscInvalid();

            // Act
            var isValid = vinylDisc.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(vinylDisc.ValidationResult.Errors);
        }


        private static VinylDisc GetVinylDiscValid()
        {
            return new Faker<VinylDisc>()
                .CustomInstantiator(f =>
                    new VinylDisc(0, f.Random.Int(1, 4), f.Name.JobTitle(), f.Random.Decimal(10.9M, 99.9M)))
                .Generate();
        }

        private static VinylDisc GetVinylDiscInvalid()
        {
            return new Faker<VinylDisc>()
                .CustomInstantiator(f => new VinylDisc(0, 0, f.Name.JobTitle(), 0))
                .Generate();
        }
    }
}