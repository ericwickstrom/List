using List.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace List.Repositories
{
    public interface IListRepository
    {
        void Add(Item item);
        void Delete(int id);
        void Edit(Item item);
        Item GetOne(int id);
        IList<Item> GetItems();
        Item GetItem(int id);
    }
}
