using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebAplication.BusinessLogics.Interface;
using WebAplication.BusinessLogics;
using WebAplication.Domain.Entities.User;
using WebAplication.Domains.Entities.User;
using WebApplication1.Extension;
using WebApplication1.Models.User;
using WebAplication.Domains.Entities.Response;
using System.Web.Razor.Generator;
using WebApplication1.Filtres;
using System.Web.UI.WebControls;
using AutoMapper;

namespace WebApplication1.Controllers
{
     public class HomeController : BaseController
     {
          private readonly ILogin _sesion;
          private readonly IProduct _product;
          private readonly IUser _user;
          private readonly ICart _cart;

          public HomeController()
          {
               var bl = new BussinesLogic();
               _sesion = bl.GetLoginBL();
               _product = bl.GetProductBL();
               _user = bl.GetUserBL();
               _cart = bl.GetCartBL();

          }

          public static class GlobalData
          {
               public static List<Product> Products { get; set; } = new List<Product>();
          }



          // GET: Home
          public ActionResult Index()
          {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return Redirect("/Login/Pages_Login");
               }

               var user = System.Web.HttpContext.Current.GetMySessionObject();
               var produs = _product.GetProduct();
               GlobalData.Products = produs;
               GlobalModel data = new GlobalModel
               {
                    Username = user.Username,
                    Level = user.Level,
                    Products = produs,               
                  
               };

               return View(data);       

          }
          public ActionResult Product()
          {
               
               var product = Request.QueryString["p"];
               var user = System.Web.HttpContext.Current.GetMySessionObject();
               var products = _product.SerchProductbyid(product);
               GlobalModel data = new GlobalModel
               {
                    Username = user.Username,
                    Level = user.Level,
                    Product = products,

               };                          
               return View(data);
          }

          [HttpPost]
          public ActionResult Product(string btn)
          {
               return RedirectToAction("Product", "Home", new { @p = btn  });
          }
            [AdminModeAtributte]
          public ActionResult Dashboard2()
          {
              
               var user = System.Web.HttpContext.Current.GetMySessionObject();
               var produs = _product.GetProduct();
               GlobalModel data = new GlobalModel
               {
                    Username = user.Username,
                    Level = user.Level,
                    Products = produs,

               };                                      
               return View(data);
          }

          [HttpPost]
          [AdminModeAtributte]
        public ActionResult UploadImage(RegistProduct model)
          {

               if (model.ImageFile != null && model.ImageFile.ContentLength > 0)
               {
                    // Creăm un nume unic pentru folderul nou
                    string uploadFolderPath = Path.Combine(Server.MapPath("~/Uploads"), Guid.NewGuid().ToString());

                    // Creăm folderul nou
                    DirectoryInfo directoryInfo = Directory.CreateDirectory(uploadFolderPath);

                    string director = directoryInfo.ToString();
                    // Salvăm imaginea încărcată în folderul nou
                    string imagePath = Path.Combine(uploadFolderPath, Path.GetFileName(model.ImageFile.FileName));
                    model.ImageFile.SaveAs(imagePath);

                    var img2 = "~/Uploads/" + director + "/" + model.ImageFile.FileName;
                   
                    var RProducr = new Product
                    {
                         name = model.name,
                         idsneakers = model.id,
                         size = model.size,
                         price = model.price,
                         img = img2,
                         quantity = model.quantity,
                         categori = model.categori,
                         subCategori = model.subCategori,
                         description = model.description,
                    };

                    Respt resp = _product.RegistNewPRoduct(RProducr);

               }

               return RedirectToAction("Index");
          }
            [AdminModeAtributte]
          public ActionResult AddProduct()
          {

               return View();
          }
          [HttpPost]
          public ActionResult LogoutAction()
          {
               ExitSesion();
               return RedirectToAction("Pages_Login", "Login");
          }

          public ActionResult UserProfile()
          {

               var user = System.Web.HttpContext.Current.GetMySessionObject();
               GlobalModel data = new GlobalModel
               {
                    Username = user.Username,
                    Level = user.Level,
                    Email = user.Email,

               };

               return View(data);
          }

          [AdminModeAtributte]
          public ActionResult DeletProduct(string productId)
          {
               _product.DeletProductById(productId);

               return RedirectToAction("Index", "Home");
          }
          public ActionResult DeletUser(int UserId)
          {
               _user.DeletUserById(UserId);

               return RedirectToAction("ListClient", "Home");
          }

          [AdminModeAtributte]
          public ActionResult ListClient()
          {
              var user = System.Web.HttpContext.Current.GetMySessionObject();
               var anyuser = _user.GetUser();
               GlobalModel data = new GlobalModel
               {
                    Username = user.Username,
                    Level = user.Level,
                    Users = anyuser,

               };
               return View(data);
          }


          public ActionResult Sort(string subcategori, string categori)
          {
               var product = Request.QueryString["p"];
               var user = System.Web.HttpContext.Current.GetMySessionObject();
               var produse = GlobalData.Products.AsQueryable();


               if (!string.IsNullOrEmpty(categori))
               {
                    produse = produse.Where(p => p.categori.ToString() == categori);
               }

               if (!string.IsNullOrEmpty(subcategori))
               {
                    produse = produse.Where(p => p.subCategori.ToString() == subcategori);
               }               
               produse = produse.OrderBy(p => p.name);

               GlobalModel data = new GlobalModel
               {
                    Username = user.Username,
                    Level = user.Level,
                    Products = produse.ToList(),
               };
               return View(data);
          }


          [HttpGet]
          public ActionResult AddProductInCart(string productId)
          {
               var user = System.Web.HttpContext.Current.GetMySessionObject();
               _cart.AddProductInCartAction(user.Username, productId);
               return RedirectToAction("Index", "Home");
          }



     }
}