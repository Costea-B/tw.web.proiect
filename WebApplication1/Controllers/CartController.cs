using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAplication.BusinessLogics.Interface;
using WebAplication.BusinessLogics;
using WebApplication1.Extension;
using WebAplication.Domains.Entities.User;
using WebApplication1.Models.User;

namespace WebApplication1.Controllers
{
    public class CartController : BaseController
    {
        private readonly ILogin _sesion;
        private readonly ICart _cart;

          public CartController()
        {
            var bl = new BussinesLogic();
            _sesion = bl.GetLoginBL();
            _cart = bl.GetCartBL();

        }
        public static class GlobalData
        {
            public static List<Product> Products { get; set; } = new List<Product>();
            public static float TotalPrice { get; set; }
        }


        public ActionResult Shopping()
        {
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            var produs = _cart.GetCartProducts(user.Username);
            GlobalData.Products = produs;
            float totalPrice = produs.Sum(p => p.price);
            GlobalData.TotalPrice = totalPrice;
            GlobalModel data = new GlobalModel
            {
                Username = user.Username,
                Level = user.Level,
                Products = produs,
                TotalPrice = totalPrice,
            };

            return View(data);
        }

    }
}