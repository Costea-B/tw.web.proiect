using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.BusinessLogics.DBModel.Seed;
using WebAplication.Domain.Entities.User;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.Core
{
     public class AdminApi : UserApi
     {
          public Respt NewProduct(Product product)
          {
               var newproduct = Mapper.Map<ProductDb>(product);

               using (var db = new ProductContext())
               {
                    db.Product.Add(newproduct);
                    db.SaveChanges();
               }

               return new Respt { Status = true };
          }

          public void DeleteProduct(string productId)
          {
               ProductDb product;
               using (var db = new ProductContext())
               {
                    product = db.Product.FirstOrDefault(u => u.idsneakers == productId);
                    if (product != null)
                    {
                         db.Product.Remove(product);
                         db.SaveChanges();
                    }
               }

          }
          public void DeleteUser(int UserId)
          {
               UDbTable User;
               using (var db = new UserContext())
               {
                    User = db.Users.FirstOrDefault(u => u.Id == UserId);
                    if (User != null)
                    {
                         db.Users.Remove(User);
                         db.SaveChanges();
                    }
               }

          }

          public List<Users> SelectAllUser()
          {
               List<Users> users;

               using (var db = new UserContext())
               {
                    // Preia toate produsele din baza de date sub forma unui IQueryable<ProductDb>
                    IQueryable<UDbTable> userDbQuery = db.Users;

                    // Convertește fiecare ProductDb într-un Product și colectează rezultatele într-o listă de Product
                    users = userDbQuery.Select(userDb => new Users
                    {
                         Id = userDb.Id,
                         Username = userDb.UserName,
                         Email = userDb.Email,
                         Level = userDb.Level,

                    }).ToList();
               }
               return users;
          }
     }
}
