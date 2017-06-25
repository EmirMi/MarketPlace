using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketShopLibrary
{
    public class Vendor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Commision { get; set; }
        public decimal PaymentDue { get; set; }

        public string Display
        {
            get
            {
                return string.Format("{0} {1} - {2} kr", FirstName, LastName, PaymentDue);
            }
        }

        public Vendor()
        {
            Commision = .3;
        }
    }
}
