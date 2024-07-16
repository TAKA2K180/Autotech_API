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

        #endregion

        #region Functions

        public async Task<List<Accounts>> GetAllAccount()
        {
            var accountList = await Task.WhenAll(dataService.GetAll());
            List<Accounts> result = new List<Accounts>();
            result = accountList.Select(a => a.ToList()).LastOrDefault() ?? new List<Accounts>();
            return result;
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
                ContactNumber = model.Phone,
                isActive = model.IsActive,
                ContactPerson = model.ContactPerson,
                Terms = model.Terms,
                DiscountPercent = model.Discount,
                Cluster = model.Cluster,
                Address = model.Address,
                RegisterDate = model.RegisterDate,
                AccountDetails = new AccountDetails
                {
                    Id = newDetailId,
                    LitersOrdered = model.LitersOrdered,
                    OpenReceipts = model.OpenReceipts
                }
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
