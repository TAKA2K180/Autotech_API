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
        private readonly IDataService<Items> headerDataService = new GenericDataService<Items>(new ApplicationDbContextFactory(null));
        private readonly IDataService<ItemDetails> detailDataService = new GenericDataService<ItemDetails>(new ApplicationDbContextFactory(null));

        #endregion

        #region Functions

        public async Task<List<Items>> GetAllItems()
        {
            var itemHeaderList = await Task.WhenAll(headerDataService.GetAll());
            var itemHeader = new List<Items>();
            itemHeader = itemHeaderList.Select(a => a.ToList()).LastOrDefault() ?? new List<Items>();
            var itemDetaillist = await Task.WhenAll(detailDataService.GetAll());
            var itemDetail = new List<ItemDetails>();
            itemDetail = itemDetaillist.Select(a => a.ToList()).LastOrDefault() ?? new List<ItemDetails>();
            var result = itemHeader.GroupJoin(
                itemDetail,
                item => item.Id,
                detail => detail.ItemId,
                (item, details) =>
                {
                    item.itemDetails = details.FirstOrDefault();
                    return item;
                }).ToList();
            return result;
        }

        public async Task<Items> GetItemById(Guid id)
        {
            return await headerDataService.GetById(id);
        }
        public async Task AddItem(ItemRequestDto model)
        {
            var newHeaderId = Guid.NewGuid();
            var newDetailId = Guid.NewGuid();
            await headerDataService.Create(new Items
            {
                Id = newHeaderId,
                ItemCode = model.ItemCode,
                ItemName = model.ItemName,
                ItemDescription = model.ItemDescription,
                DateAdded = DateTime.Now,
                itemDetails = new ItemDetails
                {
                    Id = newDetailId,
                    ItemId = newHeaderId,
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
            await headerDataService.Delete(id);
        }

        public async Task UpdateItem(Items item)
        {
            await headerDataService.Update(item);
        }
        #endregion
    }
}
