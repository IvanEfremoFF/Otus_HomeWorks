using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RegularCustomer
{
    class Shop
    {
        public ObservableCollection<Item> Items { get; }

        public Shop() 
        {
            Items = new ObservableCollection<Item>();            
        }

        public void Add(int id, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            Items.Add(new Item(id, name));
        }

        public void Remove(int itemID)
        {
            Item? foundItem = Items.FirstOrDefault(x => x.Id == itemID);

            if (foundItem != null) 
            {
                Items.Remove(foundItem);
            }
        }
    }
}
