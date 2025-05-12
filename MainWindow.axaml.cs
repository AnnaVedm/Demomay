using Avalonia.Controls;
using Demomay.Context;
using Demomay.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Demomay
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products_spisok { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<PartnersProduct> Partners_spisok { get;set; } = new ObservableCollection<PartnersProduct>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadPartners();
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (var context = new DemoMayContext())
            {
                var prod = context.Products.Include(a => a.Productiontype).ToList();

                Products_spisok.Clear();
                foreach (var s in prod)
                {
                    Products_spisok.Add(s);
                    LoadPartnerForProduct(s);
                    s.ProductColor = Determinate_Color(s);
                }
            }
        }

        private void LoadPartners()
        {
            using(var context = new DemoMayContext())
            {
                var partn = context.PartnersProducts.Include(a => a.Partner).Include(a => a.PoductArticlenumberNavigation).ToList();

                Partners_spisok = new ObservableCollection<PartnersProduct>(partn);
            }    
        }
        
        private void LoadPartnerForProduct(Product product)
        {
            using(var context = new DemoMayContext())
            {
                var PartnforPr = context.PartnersProducts.Include(a => a.Partner).Where(a => a.PoductArticlenumber == product.Article).ToList();

                foreach(var d in  PartnforPr)
                {
                    product.PartnersProducts.Add(d);
                }
                product.ProductSale = PartnforPr.Sum(a => a.Kolvoproduction);
            }
        }

        private string Determinate_Color(Product product)
        {
            if (product.ProductSale < 10000)
                return "Red";
            else if (product.ProductSale >= 10000 && product.ProductSale <= 60000)
                return "Orange";
            else
                return "LightGreen";
        }
      
        //Ќаписать размер скидки, далее перейти к остальному

            //private void Load_products()
            //{
            //    using (var context = new DemoMayContext())
            //    {
            //        var prod = context.Products.Include(a => a.Productiontype).ToList();

            //        Products_spisok.Clear();

            //        foreach (var p in prod)
            //        {
            //            LoadPartnersForProducts(p);
            //            Products_spisok.Add(p);
            //        }
            //    }
            //}

            //private void LoadPartners() // —оздаетс€ нова€ коллекци€ дл€ списка партенров, но нужно выбрать тех кто точно св€зан с продуктом
            //{
            //    using(var context = new DemoMayContext())
            //    {
            //        var partn = context.PartnersProducts.Include(a => a.Partner).Include(a => a.PoductArticlenumberNavigation).ToList();

            //       Partners_spisok = new ObservableCollection<PartnersProduct>(partn);
            //    }
            //}

            //private void LoadPartnersForProducts(Product product) //»дет выбор партнеров по продукту в карточку товара
            //{
            //    using(var context = new DemoMayContext())
            //    {
            //        var partnerd = context.PartnersProducts.Include(a => a.Partner).Where(a => a.PoductArticlenumber == product.Article).ToList();

            //        foreach(var s in partnerd)
            //        {
            //            product.PartnersProducts.Add(s);
            //        }
            //    }
            //}
        }
    }