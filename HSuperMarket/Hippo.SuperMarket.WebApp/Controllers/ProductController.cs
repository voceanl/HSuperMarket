using Hippo.SuperMarket.Domain.Abstract;
using Hippo.SuperMarket.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hippo.SuperMarket.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public IProductsRepository ProductsReposotory { get; set; } = new InMemoryProductsRepository();

        public ViewResult List()
        {
            var model = ProductsReposotory.Products;
            return View(model);
        }
    }
}