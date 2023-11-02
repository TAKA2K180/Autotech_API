using MovieRental.Core.Models;
using MovieRental.Core.Services;
using MovieRentalAPI.Main.Data.Services;
using MovieRentalAPI.Main.Data;

namespace MovieRentalAPI.Main.Repositories
{
    public class MovieTransactionsRepository
    {
        private readonly IDataService<MovieTransaction> dataService = new GenericDataService<MovieTransaction>(new ApplicationDbContextFactory(null));

        public async Task<List<MovieTransaction>> GetAllTransactions()
        {
            var transactionList = await Task.WhenAll(dataService.Getall());
            List<MovieTransaction> result = new List<MovieTransaction>();
            foreach (var trans in transactionList)
            {
                var translisting = trans.ToList();
                result = translisting;
            }
            return result;
        }

        public async Task<MovieTransaction> GetTransactionById(Guid Id)
        {
            return await dataService.Get(Id);
        }

        public async Task<int> AddTransaction(decimal totalAmount, Movie movie, Guid movieId, Costumer costumer, Guid costumerId, DateTime transactionDate, bool isReturned)
        {
            try
            {
                await dataService.Create(new MovieTransaction
                {
                    Id = new Guid(),
                    TotalAmount = totalAmount,
                    MovieId = movieId,
                    Costumer = costumer,
                    CostumerId = costumerId,
                    TransactionDate = transactionDate,
                    IsReturned = isReturned
                });
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> DeleteTransaction(Guid id)
        {
            try
            {
                await dataService.Delete(id);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> UpdateTransaction(MovieTransaction transaction)
        {
            try
            {
                await dataService.Update(transaction);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
