using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using List.Models;
using Microsoft.AspNetCore.Mvc;

namespace List.Repositories
{
    public class MockListRepository : IListRepository
    {
        private List<Item> list = new List<Item>();

        public MockListRepository()
        {
            Add(new Item { text = "item1", complete = false });
            Add(new Item { text = "item2", complete = false });
            Add(new Item { text = "item3", complete = false });
            Add(new Item { text = "item4", complete = false });
            Add(new Item { text = "item5", complete = false });
        }


        // Add item
        public void Add(Item item)
        {
            item.id = list.Count + 1;
            list.Add(item);
        }

        // get item by id
        public Item GetItem(int id)
        {
            
            throw new NotImplementedException();
        }

        // get all items
        public IList<Item> GetItems()
        {
            return list;
        }

        // get one item that matches id
        public Item GetOne(int id)
        {
            return list.FirstOrDefault(x => x.id == id);
        }

        // Edit an item
        public void Edit(Item item)
        {
            int index = list.FindIndex(x => x.id == item.id);
            if(index >= 0)
            {
                list.RemoveAt(index);
                list.Insert(index, item);
            }
        }

        // delete item by id
        public void Delete(int id)
        {
            int index = list.FindIndex(x => x.id == id);
            if(index >= 0)
            {
                list.RemoveAt(index);
            }
            
        }
    }
}
