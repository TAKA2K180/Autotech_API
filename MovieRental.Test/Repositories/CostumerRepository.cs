using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRental.Core.Models;
using MovieRental.Core.Services;
using MovieRentalAPI;

namespace MovieRental.Test.Repositories
{
    public class CostumerRepository
    {
        private MovieRentalAPI.Main.Repositories.CostumersRepository _costumerRepository = new MovieRentalAPI.Main.Repositories.CostumersRepository();

        [Fact]
        public async Task GetAllCostumer_ShouldReturnListOfCostumers()
        {
            // Arrange - Assuming there are existing costumers in the test database
            // ...

            // Act
            var result = await _costumerRepository.GetAllCostumer();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Costumer>>(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task GetCostumerById_ShouldReturnCorrectCostumer()
        {
            // Arrange - Assuming a costumer with a known ID exists in the test database
            var existingCostumerId = Guid.Parse("C5FC283C-5F73-4525-B82C-9677C767C33B");

            // Act
            var result = await _costumerRepository.GetCostumerById(existingCostumerId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Costumer>(result);
            Assert.Equal(existingCostumerId, result.Id);
        }

        [Fact]
        public async Task AddCostumer_ShouldCreateNewCostumer()
        {
            // Arrange - Input parameters for the new costumer
            var name = "Test Costumer";
            var email = "test@example.com";
            var phone = "1234567890";
            var isActive = true;
            var Id = Guid.NewGuid();

            // Act
            await _costumerRepository.AddCostumer(Id, name, email, phone, isActive);

            // Assert - Check if the costumer was added by querying the database or checking a count
            var addedCostumer = await _costumerRepository.GetCostumerById(Id);
            Assert.NotNull(addedCostumer);
            Assert.Equal(name, addedCostumer.Name);
            Assert.Equal(email, addedCostumer.Email);
            Assert.Equal(phone, addedCostumer.Phone);
            Assert.Equal(isActive, addedCostumer.isActive);
        }

        [Fact]
        public async Task DeleteCostumer_ShouldRemoveCostumer()
        {
            // Arrange - Assuming a costumer with a known ID exists in the test database
            var existingCostumerId = Guid.Parse("D942893E-6EF6-4F64-A5DD-F0916A0AB165");

            // Act
            await _costumerRepository.DeleteCostumer(existingCostumerId);

            // Assert - Check if the costumer was deleted by querying the database or checking a count
            var deletedCostumer = await _costumerRepository.GetCostumerById(existingCostumerId);
            Assert.Null(deletedCostumer);
        }

        [Fact]
        public async Task UpdateCostumer_ShouldModifyCostumerDetails()
        {
            // Arrange - Assuming a costumer with a known ID exists in the test database
            var existingCostumerId = Guid.Parse("C5FC283C-5F73-4525-B82C-9677C767C33B");
            var updatedCostumer = new Costumer
            {
                Id = existingCostumerId,
                Name = "Updated Costumer",
                Email = "updated@example.com",
                Phone = "9876543210",
                isActive = false
            };

            // Act
            await _costumerRepository.UpdateCostumer(updatedCostumer);

            // Assert - Check if the costumer was updated by querying the database or checking details
            var modifiedCostumer = await _costumerRepository.GetCostumerById(existingCostumerId);
            Assert.NotNull(modifiedCostumer);
            Assert.Equal(updatedCostumer.Name, modifiedCostumer.Name);
            Assert.Equal(updatedCostumer.Email, modifiedCostumer.Email);
            Assert.Equal(updatedCostumer.Phone, modifiedCostumer.Phone);
            Assert.Equal(updatedCostumer.isActive, modifiedCostumer.isActive);
        }
    }
}
