using E_Ticaret_BLL.Models;
using E_Ticaret_DAL.Context;
using E_Ticaret_Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret_WEBUI.Controllers
{
    [Authorize(Roles ="admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();
            
            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                   .Select(i => new OrderDetailsModel()
                   {
                       Username=i.Username,
                       OrderId = i.Id,
                       OrderNumber = i.OrderNumber,
                       Total = i.Total,
                       OrderDate = i.OrderDate,
                       OrderState = i.OrderState,
                       AdresBilgi = i.AdresBilgi,
                       Adres = i.Adres,
                       Sehir = i.Sehir,
                       Semt = i.Semt,
                       Mahalle = i.Mahalle,
                       PostaKodu = i.PostaKodu,
                       OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                       {
                           ProductId = a.ProductId,
                           ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0, 40) + "..." : a.Product.Name,
                           Image = a.Product.Image,
                           Quantity = a.Quantity,
                           Price = a.Price
                       }).ToList()
                   }).FirstOrDefault();
            return View(entity);

        }

        public ActionResult UpdateOrderState(int OrderId, EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order != null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["message"] = "Bilgileriniz Kayıt Edildi";

                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
    }
}