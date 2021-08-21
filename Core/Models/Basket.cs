using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Basket
    {
        public Basket()
        {

        }
        public Basket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItem> ItemList { get; set; } = new List<BasketItem>();

    }
}
