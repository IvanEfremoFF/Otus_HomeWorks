using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularCustomer
{
    class Customer
    {
        public string Name { get; set; }

        public Customer(string name) 
        { 
            Name = name;            
        }
        public void OnItemChanged(object? sender,  NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(Item item in e.NewItems)
                    {
                        Console.WriteLine($"Customer {Name} notified the product \"{item.Id} - {item.Name}\" added to the shop");
                    }                        
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (Item item in e.OldItems)
                    {
                        Console.WriteLine($"Customer {Name} notified the product \"{item.Id} - {item.Name}\" removed from the shop");
                    }                    
                    break;
            }
        }

    }
}
