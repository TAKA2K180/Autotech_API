using Microsoft.EntityFrameworkCore;
using Autotech.Core.Models;
using Autotech.Core.Services;
using System.Linq;
using Autotech.BusinessLayer.Data.DTO;
using Autotech.BusinessLayer.Data.Services;
using Autotech.BusinessLayer.Data;

namespace Autotech.BusinessLayer.Repositories
{
    public class AccountsRepository
    {
        #region Private Variables
        private readonly IDataService<Accounts> dataService = new GenericDataService<Accounts>(new ApplicationDbContextFactory(null));
        private readonly IDataService<Locations> locationDataService = new GenericDataService<Locations>(new ApplicationDbContextFactory(null));

        #endregion

        #region Functions

        public async Task<List<Accounts>> GetAllAccount()
        {
            var accounts = (await dataService.GetAll()).ToList();
            var locations = (await locationDataService.GetAll()).ToDictionary(loc => loc.Id);

            foreach (var account in accounts)
            {
                if (locations.TryGetValue(account.LocationId, out var location))
                {
                    account.Location = location;
                }
            }

            return accounts;
        }

        public async Task<Accounts> GetAccountById(Guid id)
        {
            return await dataService.GetById(id);
        }
        public async Task AddAccount(AccountRequestDto model)
        {
            var newHeaderId = Guid.NewGuid();
            var newDetailId = Guid.NewGuid();
            await dataService.Create(new Accounts
            {
                Id = newHeaderId,
                Name = model.Name,
                Email = model.Email,
                ContactNumber = model.ContactNumber,
                isActive = model.isActive,
                ContactPerson = model.ContactPerson,
                Terms = model.Terms,
                DiscountPercent = model.DiscountPercent,
                Cluster = model.Cluster,
                Address = model.Address,
                RegisterDate = model.RegisterDate,
                AccountDetails = new AccountDetails
                {
                    Id = newDetailId,
                    LitersOrdered = model.LitersOrdered,
                    OpenReceipts = model.OpenReceipts
                },
                LocationId = model.LocationId
            });
        }

        public async Task DeleteAccount(Guid id)
        {
            await dataService.Delete(id);
        }

        public async Task UpdateAccount(Accounts account)
        {
            await dataService.Update(account);
        } 
        #endregion
    }
}
