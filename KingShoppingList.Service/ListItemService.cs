using KingShoppingList.Contract;
using KingShoppingList.Model;
using KingShoppingList.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingShoppingList.Service
{
    public class ListItemService : IListItemService
    {

        private readonly IListItemRepository _listItemRepository;

        public ListItemService(IListItemRepository listItemRepository)
        {
            _listItemRepository = listItemRepository;
        }
        public async Task<List<ListItem>> getAll()
        {
            return await _listItemRepository.getAll();
        }

        public async Task<ListItem> GetById(int id)
        {
            return await _listItemRepository.GetById(id);
        }

        public async Task Create(ListItem listItem)
        {
             await _listItemRepository.Create(listItem);
        }

        public async Task Delete(ListItem listItem)
        {
            await _listItemRepository.Delete(listItem);
        }

        public async Task Edit(ListItem listItem)
        {
            await _listItemRepository.Edit(listItem);
        }

        public bool Exists(int id)
        {
            return _listItemRepository.Exists(id);
        }

    }
}
