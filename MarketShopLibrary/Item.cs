using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketShopLibrary
{
    public class Item
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public decimal Price { get; set; }
        public bool Sold { get; set; }
        public bool AddedToCart { get; set; }
        public Vendor Owner { get; set; }

        public string Display
        {
            get
            {
                return string.Format("{0} - {1} kr", Title, Price);
            }
        }

    }
}
