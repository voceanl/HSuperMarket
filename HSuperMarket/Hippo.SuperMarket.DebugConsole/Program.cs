using Hippo.SuperMarket.Domain.Concrete;
using Hippo.SuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hippo.SuperMarket.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start...");

            using (var ctx = new EFDbContext())
            {
                for (int i = 1; i < 10; i++)
                {
                    var product = new Product()
                    {
                        Name = $"Lamb-{10+i}",
                        Price = 4.99m,
                        Category = "Meat",
                        Description = "Come from Quebec."
                    };

                    ctx.Products.Add(product);
                }

                for (int i = 1; i < 10; i++)
                {
                    var product = new Product()
                    {
                        Name = $"Lobster-{10+i}",
                        Price = 5.99m,
                        Category = "Sea foods",
                        Description = "Come from Nova Scotia."
                    };

                    ctx.Products.Add(product);
                }
 
                for (int i = 1; i < 10; i++)
                {
                    var product = new Product()
                    {
                        Name = $"Beef-{10+i}",
                        Price = 6.99m,
                        Category = "Meat",
                        Description = "Come from Quebec."
                    };

                    ctx.Products.Add(product);
                }
                
                ctx.SaveChanges();
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
