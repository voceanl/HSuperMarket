using Hippo.SuperMarket.Domain.Abstract;
using Hippo.SuperMarket.Domain.Concrete;
using Hippo.SuperMarket.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hippo.SuperMarket.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public IProductsRepository ProductsRepository { get; set; }
        public const int PageSize = 3;
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = ProductsRepository
                .Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
                    ?ProductsRepository.Products.Count()
                    :ProductsRepository.Products
                    .Where(e =>e.Category == category).Count()
                    /*
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = ProductsRepository
                    .Products
                    .Where(p => category == null || p.Category == category)
                    .count()*/
                },

                CurrentCategory = category
            };

            return View(model);
        }
    }
}