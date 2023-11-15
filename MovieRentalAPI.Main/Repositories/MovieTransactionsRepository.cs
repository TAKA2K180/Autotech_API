using MovieRental.Core.Models;
using MovieRental.Core.Services;
using MovieRentalAPI.Main.Data.Services;
using MovieRentalAPI.Main.Data;
using MovieRentalAPI.Main.Data.DTO;
using MovieRental.Common.Classes.Generics;
using System.Diagnostics;

namespace MovieRentalAPI.Main.Repositories
{
    public class MovieTransactionsRepository
    {
        private readonly MoviesRepository _moviesRepository = new MoviesRepository();
        private readonly CostumersRepository _costumerRepository = new CostumersRepository();
        private readonly IDataService<MovieTransaction> _dataService = new GenericDataService<MovieTransaction>(new ApplicationDbContextFactory(null));
        private GenericFunctions _genericFunctions = new GenericFunctions();

        public async Task<List<MovieTransaction>> GetAllTransactions()
        {
            var transactionLists = await Task.WhenAll(_dataService.GetAll());

            var result = transactionLists
                .SelectMany(list => list)
                .Select(async trans =>
                {
                    await _genericFunctions.UpdateIfNullAsync(trans, nameof(trans.Movie), async () => await _moviesRepository.GetMovieById(trans.MovieId), movie => movie == null);
                    await _genericFunctions.UpdateIfNullAsync(trans, nameof(trans.Costumer), async () => await _costumerRepository.GetCostumerById(trans.CostumerId), costumer => costumer == null);

                    return trans;
                });

            return (await Task.WhenAll(result)).ToList();
        }

        public async Task<MovieTransaction> GetTransactionById(Guid Id)
        {
            var transactionLists = await Task.WhenAll(_dataService.GetById(Id));

            foreach (var item in transactionLists)
            {
                await _genericFunctions.UpdateIfNullAsync(item, nameof(item.Movie), async () => await _moviesRepository.GetMovieById(item.MovieId), movie => movie == null);
                await _genericFunctions.UpdateIfNullAsync(item, nameof(item.Costumer), async () => await _costumerRepository.GetCostumerById(item.CostumerId), costumer => costumer == null);
            }
            return transactionLists[0];
        }

        public async Task AddTransaction(Guid movieId, Guid customerId, decimal totalAmount, bool isReturned)
        {
            var movieTransaction = new MovieTransaction
            {
                TotalAmount = totalAmount,
                MovieId = movieId,
                CostumerId = customerId,
                TransactionDate = DateTime.Now,
                IsReturned = isReturned
            };

            await _dataService.Create(movieTransaction);
        }

        public async Task DeleteTransaction(Guid id)
        {
            await _dataService.Delete(id);
        }

        public async Task UpdateTransaction(MovieTransaction transaction)
        {
            await _dataService.Update(transaction);
        }
    }
}
