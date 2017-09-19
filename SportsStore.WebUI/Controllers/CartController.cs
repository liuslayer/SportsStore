using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
         public IProductRepository repository;
         public IOrderProcessor orderProcessor;

         public CartController(IProductRepository productRepository,IOrderProcessor proc)
        {
            this.repository = productRepository;
            this.orderProcessor = proc;
        }

        [HttpPost]
         public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
         {
             if (cart.Lines.Count() == 0)
             {
                 ModelState.AddModelError("", "购物车为空");
             }

             if (ModelState.IsValid)
             {
                 //orderProcessor.ProcessOrder(cart, shippingDetails);
                 cart.Clear();
                 return View("Completed");
             }
             else
             {
                 return View(shippingDetails);
             }
         }

         public ViewResult Checkout()
         {
             return View(new ShippingDetails());
         }

         public PartialViewResult Summary(Cart cart)
         {
             return PartialView(cart);
         }

        //
        // GET: /Cart/
         public ViewResult Index(Cart cart, string returnUrl)
         {
             return View(new CartIndexViewModel
             {
                 Cart = cart,
                 ReturnUrl = returnUrl
             });
         }

         public RedirectToRouteResult AddToCart(Cart cart, int productID, string returnUrl)
         {
             Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);
             if (productID != null)
             {
                 cart.AddItem(product, 1);
             }
             return RedirectToAction("Index", new { returnUrl });
         }

         public RedirectToRouteResult RemoveFromCart(Cart cart, int productID, string returnUrl)
         {
             Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);
             if (productID != null)
             {
                 cart.RemoveLine(product);
             }
             return RedirectToAction("Index", new { returnUrl });
         }

         private Cart GetCart()
         {
             Cart cart = (Cart)Session["Cart"];
             if (cart == null)
             {
                 cart = new Cart();
                 Session["Cart"] = cart;
             }
             return cart;
         }
	}
}