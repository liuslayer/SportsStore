using SportsStore.Domain.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        public IProductRepository repository;

        public NavController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        //
        // GET: /Nav/
        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(c => c);
            return PartialView(categories);
        }
	}
}