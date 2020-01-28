using E_Ticaret_DAL.Context;
using E_Ticaret_Entity.Entity;
using E_Ticaret_WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret_WEBUI.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var urunler =_context.Products
                .Where(i=> i.IsHome && i.IsApproved)
                .Select(i=> new ProductModel()
                { 
                 Id=i.Id,
                 Name= i.Name.Length > 50 ? i.Name.Substring(0, 43) + "..." : i.Name,
                    Description =i.Description.Length>50 ?i.Description.Substring(0,47)+"...":i.Description,
                 Price=i.Price,
                 Stock=i.Stock,
                 Image=i.Image,
                 CategoryId=i.CategoryId
                }).ToList();

            return View(urunler);
        }
        public ActionResult List(int? id)
        {
            var urunler = _context.Products
                .Where(i=> i.IsApproved)
               .Select(i => new ProductModel()
               {
                   Id = i.Id,
                   Name = i.Name.Length>50 ? i.Name.Substring(0,43)+"...":i.Name,
                   Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                   Price = i.Price,
                   Stock = i.Stock,
                   Image = i.Image ?? "1.jpg",
                   CategoryId = i.CategoryId
               }).AsQueryable(); // yazılan sql command i tolist denilene kadar çalıştırmayacak. Böylece kodumuza ilerleyen satırlarda dorgu kodu ekleyebiliriz.

            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id==id).FirstOrDefault());
        }
    
        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    
    }
}