using Autotech.BusinessLayer.Data.DTO;
using Autotech.BusinessLayer.Data.Services;
using Autotech.BusinessLayer.Data;
using Autotech.Core.Models;
using Autotech.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotech.BusinessLayer.Repositories
{
    public class ItemsRepository
    {
        #region Private Variables
        private readonly IDataService<Items> dataService = new GenericDataService<Items>(new ApplicationDbContextFactory(null));

        #endregion

        #region Functions

        public async Task<List<Items>> GetAllItems()
        {
            var itemList = await Task.WhenAll(dataService.GetAll());
            List<Items> result = new List<Items>();
            result = itemList.Select(a => a.ToList()).LastOrDefault() ?? new List<Items>();
            return result;
        }

        public async Task<Items> GetItemById(Guid id)
        {
            return await dataService.GetById(id);
        }
        public async Task AddItem(ItemRequestDto model)
        {
            var newHeaderId = Guid.NewGuid();
            var newDetailId = Guid.NewGuid();
            await dataService.Create(new Items
            {
                Id = newHeaderId,
                ItemCode = model.ItemCode,
                ItemDescription = model.ItemDescription,
                itemDetails = new ItemDetails
                {
                    Id = newDetailId,
                    ItemsSold = model.ItemsSold,
                    Sales = model.Sales,
                    OnHand = model.OnHand,
                    BataanRetail = model.BataanRetail,
                    BataanWholeSale = model.BataanWholeSale,
                    PampangaRetail = model.PampangaRetail,
                    PampangaWholeSale = model.PampangaWholeSale,
                    ZambalesRetail = model.ZambalesRetail,
                    ZambalesWholeSale = model.ZambalesWholeSale,
                }
            });
        }

        public async Task DeleteItem(Guid id)
        {
            await dataService.Delete(id);
        }

        public async Task UpdateItem(Items item)
        {
            await dataService.Update(item);
        }
        #endregion
    }
}
