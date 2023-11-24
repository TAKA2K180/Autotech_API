using Microsoft.EntityFrameworkCore;
using MovieRental.Core.Models;
using MovieRental.Core.Services;
using MovieRentalAPI.Main.Data;
using MovieRentalAPI.Main.Data.Services;
using System.Linq;

namespace MovieRentalAPI.Main.Repositories
{
    public class CustomersRepository
    {
        #region Private Variables
        private readonly IDataService<Customer> dataService = new GenericDataService<Customer>(new ApplicationDbContextFactory(null));

        #endregion

        #region Functions

        public async Task<List<Customer>> GetAllCustomer()
        {
            var movieList = await Task.WhenAll(dataService.GetAll());
            List<Customer> result = new List<Customer>();
            result = movieList.Select(movie => movie.ToList()).LastOrDefault() ?? new List<Customer>();
            return result;
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await dataService.GetById(id);
        }
        public async Task AddCustomer(Guid Id, string Name, string Email, string Phone, bool isActive)
        {
            await dataService.Create(new Customer
            {
                Id = Id,
                Name = Name,
                Email = Email,
                Phone = Phone,
                isActive = isActive
            });
        }

        public async Task DeleteCustomer(Guid id)
        {
            await dataService.Delete(id);
        }

        public async Task UpdateCustomer(Customer costumer)
        {
            await dataService.Update(costumer);
        } 
        #endregion
    }
}
