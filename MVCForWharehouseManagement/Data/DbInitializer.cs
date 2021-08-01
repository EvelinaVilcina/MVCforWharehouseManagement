using MVCForWharehouseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCForWharehouseManagement.Data
{
    public class DbInitializer
    {
        public static void Initialize(WharehouseManagementContext context)
        {
            context.Database.EnsureCreated();

            if (context.OrderedProducts.Any())
            {
                return;
            }

            var products = new Product[]
                {
                    new Product{ProductID=1, Name="firstproduct", Price=3.55, ColourCode=123, EanCode="EAN000123456789", Stock=15, IsOutOfStock=false},
                    new Product{ProductID=2, Name="secondproduct", Price=4.55, ColourCode=123, EanCode="EAN000123456788", Stock=15, IsOutOfStock=false},
                    new Product{ProductID=3, Name="thirdproduct", Price=5.55, ColourCode=123, EanCode="EAN000123456787", Stock=15, IsOutOfStock=false},
                    new Product{ProductID=4, Name="fourthproduct", Price=6.55, ColourCode=123, EanCode="EAN000123456786", Stock=15, IsOutOfStock=false},
                };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            var addreses = new Address[]
                {
                    new Address{StreetName="Lorem ipsum", HouseName="13 sun", City="where", Country="Land", Zip=1234}
                };

            var clients = new Client[]
                {
                    new Client{FullName="Full Name", Address=addreses[0], PhoneNumber="+371 12345678"}
                };

            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }

            context.SaveChanges();

            var orders = new Order[]
                {
                    new Order
                    {
                        OrderNumber = "Order001",
                        DateTime = DateTime.Now,
                        ClientID = clients[0].ClientID,
                        Client = clients[0],
                        OrderedProducts = new List<OrderedProducts> ()
                        { 
                          new OrderedProducts
                          {
                              ProductID=1, 
                              Name="firstproduct", 
                              OrderNumber="Order001"
                          },

                          new OrderedProducts
                          {
                              ProductID=2, 
                              Name="secondproduct", 
                              OrderNumber="Order001"
                          },

                          new OrderedProducts
                          {
                              ProductID=3, 
                              Name="thirdproduct", 
                              OrderNumber="Order001"
                          },

                        }
                    }
                };

            foreach (Order o in orders)
            {
                context.Orders.Add(o);
            }

            context.SaveChanges();
        }
    }
}
