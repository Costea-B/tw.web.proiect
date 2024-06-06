using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAplication.BusinessLogics.DBModel;
using WebAplication.BusinessLogics.DBModel.Seed;
using WebAplication.Domain.Entities.User;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;
using WebAplication.Helpe;

namespace WebAplication.BusinessLogics.Core
{
    public class UserApi
    {
        public ULoginResp RLoginUPService(ULoginData data)
        {
            UDbTable user;

            var pass = LoginHelper.HashGen(data.Password);
            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.UserName == data.UserName && u.Password == pass);
            }
            if (user != null) return new ULoginResp { IsSuccess = true };


            return new ULoginResp { IsSuccess = false };
        }

        public ULoginResp RRegistUPService(URegistdata data)
        {
            var pass = LoginHelper.HashGen(data.Password);
            var newUser = new UDbTable
            {
                UserName = data.UserName,
                Email = data.Email,
                Password = pass,
                LastIp = data.IP,
                RegistData = DateTime.Now,
                Level = URole.User

            };

            using (var db = new UserContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }



            return new ULoginResp { IsSuccess = false };
        }

        public HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        public Users GetCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                curentUser = db.Users.FirstOrDefault(u => u.UserName == session.Username);
            }
            if (curentUser == null) return null;


            var user = new Users
            {
                Username = curentUser.UserName,
                Email = curentUser.Email,
                Level = curentUser.Level
            };

            return user;



        }

        public List<Product> SelectAllProducts()
        {
            List<Product> products;

            using (var db = new ProductContext())
            {
                // Preia toate produsele din baza de date sub forma unui IQueryable<ProductDb>
                IQueryable<ProductDb> productDbQuery = db.Product;

                // Convertește fiecare ProductDb într-un Product și colectează rezultatele într-o listă de Product
                products = productDbQuery.Select(productDb => new Product
                {
                    idsneakers = productDb.idsneakers,
                    name = productDb.name,
                    size = productDb.size,
                    price = productDb.price,
                    img = productDb.img,
                    quantity = productDb.quantity

                }).ToList();
            }



            return products;
        }

        public Product SercheProduct(string id)
        {

            ProductDb product;
            using (var db = new ProductContext())
            {
                product = db.Product.FirstOrDefault(u => u.idsneakers == id);
            }

            if (product == null) return null;
            var product1 = Mapper.Map<Product>(product);

            return product1;
        }

        

        public List<Product> GetCartProductsAction(string name)
        {
            List<Product> products;
            CartDb cartDb;

            using (var db = new CartContext())
            {
                cartDb = db.Cart.FirstOrDefault(u => u.UserName == name);

            }

            HashSet<string> productIds = new HashSet<string>
    {
        cartDb.Produc1,
        cartDb.Produc2,
        cartDb.Produc3,
        cartDb.Produc4,
        cartDb.Produc5,
        cartDb.Produc6,
        cartDb.Produc7,
        cartDb.Produc8,
        cartDb.Produc9,
        cartDb.Produc10
    };

            // Filtrăm identificatorii nenuli
            productIds.RemoveWhere(id => string.IsNullOrEmpty(id));


            using (var db = new ProductContext())
            {
                var productsDb = db.Product.Where(p => productIds.Contains(p.idsneakers)).ToList();

                products = productsDb.Select(productDb => new Product
                {
                    idsneakers = productDb.idsneakers,
                    name = productDb.name,
                    size = productDb.size,
                    price = productDb.price,
                    img = productDb.img,


                }).ToList();
            }


            return products;
        }


          public void AddProductInCart(string userName, string productId)
          {
               using (var db = new CartContext())
               {
                    // Obține coșul utilizatorului
                    var cartDb = db.Cart.FirstOrDefault(u => u.UserName == userName);

                    // Dacă coșul nu există, creează unul nou
                    if (cartDb == null)
                    {
                         cartDb = new CartDb
                         {
                              UserName = userName,
                              Produc1 = productId // adaugă produsul în primul slot
                                                  // inițializează alte câmpuri dacă este necesar
                         };
                         db.Cart.Add(cartDb);
                    }
                    else
                    {
                         // Adaugă produsul într-un slot gol
                         if (string.IsNullOrEmpty(cartDb.Produc1)) cartDb.Produc1 = productId;
                         else if (string.IsNullOrEmpty(cartDb.Produc2)) cartDb.Produc2 = productId;
                         else if (string.IsNullOrEmpty(cartDb.Produc3)) cartDb.Produc3 = productId;
                         else if (string.IsNullOrEmpty(cartDb.Produc4)) cartDb.Produc4 = productId;
                         else if (string.IsNullOrEmpty(cartDb.Produc5)) cartDb.Produc5 = productId;
                         else if (string.IsNullOrEmpty(cartDb.Produc6)) cartDb.Produc6 = productId;
                         else if (string.IsNullOrEmpty(cartDb.Produc7)) cartDb.Produc7 = productId;
                         else if (string.IsNullOrEmpty(cartDb.Produc8)) cartDb.Produc8 = productId;
                         else if (string.IsNullOrEmpty(cartDb.Produc9)) cartDb.Produc9 = productId;
                         else if (string.IsNullOrEmpty(cartDb.Produc10)) cartDb.Produc10 = productId;
                    }

                    // Salvează modificările în baza de date
                    db.SaveChanges();
               }
          }
     }
}