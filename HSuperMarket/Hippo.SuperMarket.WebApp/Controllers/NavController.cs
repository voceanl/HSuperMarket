using Hippo.SuperMarket.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hippo.SuperMarket.WebApp.Controllers
{
    public class NavController : Controller
    {
        public IProductsRepository ProductsRepository { get; set; }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = ProductsRepository
            .Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}