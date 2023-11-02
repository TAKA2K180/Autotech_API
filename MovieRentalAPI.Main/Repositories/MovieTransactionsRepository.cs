using MovieRental.Core.Models;
using MovieRental.Core.Services;
using MovieRentalAPI.Main.Data.Services;
using MovieRentalAPI.Main.Data;
using MovieRentalAPI.Main.Data.DTO;

namespace MovieRentalAPI.Main.Repositories
{
    public class MovieTransactionsRepository
    {
        private readonly MoviesRepository _moviesRepository = new MoviesRepository();
        private readonly CostumersRepository _costumerRepository = new CostumersRepository();
        private readonly IDataService<MovieTransaction> dataService = new GenericDataService<MovieTransaction>(new ApplicationDbContextFactory(null));

        public async Task<List<MovieTransaction>> GetAllTransactions()
        {
            var transactionList = await Task.WhenAll(dataService.Getall());
            List<MovieTransaction> result = new List<MovieTransaction>();
            foreach (var trans in transactionList)
            {
                if (trans.FirstOrDefault().Movie == null)
                {
                    trans.FirstOrDefault().Movie = await _moviesRepository.GetMovieById(trans.FirstOrDefault().MovieId);
                }
                if (trans.FirstOrDefault().Costumer == null)
                {
                    trans.FirstOrDefault().Costumer = await _costumerRepository.GetCostumerById(trans.FirstOrDefault().CostumerId);
                }
                var translisting = trans.ToList();
                result = translisting;
            }
            return result;
        }

        public async Task<MovieTransaction> GetTransactionById(Guid Id)
        {
            return await dataService.Get(Id);
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

            await dataService.Create(movieTransaction);
        }

        public async Task DeleteTransaction(Guid id)
        {
            await dataService.Delete(id);
        }

        public async Task UpdateTransaction(MovieTransaction transaction)
        {
            await dataService.Update(transaction);
        }
    }
}
