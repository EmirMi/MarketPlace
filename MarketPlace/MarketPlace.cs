using MarketShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketPlace
{
    public partial class MarketPlace : Form
    {
        private Store store = new Store();
        private List<Item> shoppingCartData = new List<Item>();
        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorsBinding = new BindingSource();
        private decimal storeProfit = 0;

        public MarketPlace()
        {
            InitializeComponent();
            SetupData();
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false && x.AddedToCart == false).ToList();
            itemsListbox.DataSource = itemsBinding;

            itemsListbox.DisplayMember = "Display";
            itemsListbox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartData;
            shoppingCartListbox.DataSource = cartBinding;

            shoppingCartListbox.DisplayMember = "Display";
            shoppingCartListbox.ValueMember = "Display";

            vendorsBinding.DataSource = store.Vendors;
            vendorListbox.DataSource = vendorsBinding;

            vendorListbox.DisplayMember = "Display";
            vendorListbox.ValueMember = "Display";
        }

        private void SetupData()
        {
            store.Vendors.Add(new Vendor { FirstName = "Anders", LastName = "Andersson" });
            store.Vendors.Add(new Vendor { FirstName = "Peter", LastName = "Petersson" });
            store.Items.Add(new Item
            {
                Title = "The Beatles - Revolver",
                Year = "1966",
                Price = 269M,
                Owner = store.Vendors[0]
            });
            store.Items.Add(new Item
            {
                Title = "Pink Floyd - The Dark Side of the Moon",
                Year = "1973",
                Price = 239M,
                Owner = store.Vendors[0]
            });
            store.Items.Add(new Item
            {
                Title = "Led Zeppelin - Houses of the Holy",
                Year = "1973",
                Price = 219M,
                Owner = store.Vendors[1]
            });
            store.Items.Add(new Item
            {
                Title = "Prince - Purple Rain",
                Year = "1984",
                Price = 99M,
                Owner = store.Vendors[1]
            });

        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            Item selectedItem = (Item)itemsListbox.SelectedItem;
            shoppingCartData.Add(selectedItem);
            cartBinding.ResetBindings(false);
            selectedItem.AddedToCart = true;
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false && x.AddedToCart == false).ToList();
            itemsBinding.ResetBindings(false);
        }

        private void makePurchase_Click(object sender, EventArgs e)
        {
            foreach (Item item in shoppingCartData)
            {
                item.Sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.Commision * item.Price;
                storeProfit += (1 - (decimal)item.Owner.Commision) * item.Price;
            }

            shoppingCartData.Clear();
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false && x.AddedToCart == false).ToList();
            storeProfitValue.Text = string.Format("{0} kr", storeProfit);
            cartBinding.ResetBindings(false);
            itemsBinding.ResetBindings(false);
            vendorsBinding.ResetBindings(false);

        }
    }
}

