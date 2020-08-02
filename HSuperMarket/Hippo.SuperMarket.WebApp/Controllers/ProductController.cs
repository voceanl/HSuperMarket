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
        public ViewResult List(int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = ProductsRepository
                .Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = ProductsRepository.Products.Count()
                }
            };
            return View(model);
        }
    }
}