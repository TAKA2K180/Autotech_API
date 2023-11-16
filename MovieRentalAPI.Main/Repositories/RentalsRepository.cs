using MovieRental.Core.Models;
using MovieRental.Core.Services;
using MovieRentalAPI.Main.Data.Services;
using MovieRentalAPI.Main.Data;
using MovieRental.Common.Classes.Generics;
using System.Diagnostics;

namespace MovieRentalAPI.Main.Repositories
{
    public class RentalsRepository
    {
        #region Private Variables
        private readonly MoviesRepository _moviesRepository = new MoviesRepository();
        private readonly CustomersRepository _costumerRepository = new CustomersRepository();
        private readonly MovieTransactionsRepository _transactionRepository = new MovieTransactionsRepository();
        private readonly IDataService<Rentals> _dataService = new GenericDataService<Rentals>(new ApplicationDbContextFactory(null));
        private GenericFunctions _genericFunctions = new GenericFunctions();

        #endregion

        #region Functions

        public async Task<List<Rentals>> GetAllRentals()
        {
            var rentList = await Task.WhenAll(_dataService.GetAll());

            var result = rentList
                .SelectMany(list => list)
                .Select(async trans =>
                {
                    await _genericFunctions.UpdateIfNullAsync(trans, nameof(trans.Movie), async () => await _moviesRepository.GetMovieById(trans.Id), movie => movie == null);
                    await _genericFunctions.UpdateIfNullAsync(trans, nameof(trans.Customer), async () => await _costumerRepository.GetCustomerById(trans.CustomerId), customer => customer == null);
                    await _genericFunctions.UpdateIfNullAsync(trans, nameof(trans.Transaction), async () => await _transactionRepository.GetTransactionById(trans.TransactionId), transaction => transaction == null);

                    return trans;
                });
            return (await Task.WhenAll(result)).ToList();
        }

        public async Task<Rentals> GetRentalById(Guid id)
        {
            var rentList = await Task.WhenAll(_dataService.GetById(id));

            await Task.WhenAll(rentList.Select(async item =>
            {
                await _genericFunctions.UpdateIfNullAsync(item, nameof(item.Movie), async () => await _moviesRepository.GetMovieById(item.Id), movie => movie == null);
                await _genericFunctions.UpdateIfNullAsync(item, nameof(item.Customer), async () => await _costumerRepository.GetCustomerById(item.CustomerId), customer => customer == null);
                await _genericFunctions.UpdateIfNullAsync(item, nameof(item.Transaction), async () => await _transactionRepository.GetTransactionById(item.TransactionId), transaction => transaction == null);
            }));
            return rentList[0];
        }
        public async Task AddRental(Guid id, Guid customerId, Guid movieId, Guid transactionId)
        {
            await _dataService.Create(new Rentals
            {
                Id = id,
                CustomerId = customerId,
                MovieId = movieId,
                TransactionId = transactionId
            });
        }

        public async Task DeleteRental(Guid id)
        {
            await _dataService.Delete(id);
        }

        public async Task UpdateRental(Rentals Rental)
        {
            await _dataService.Update(Rental);
        }
        #endregion
    }
}
