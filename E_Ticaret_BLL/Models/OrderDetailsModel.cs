using E_Ticaret_Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret_BLL.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; } //Sipariş durumunu gösterecek 

        public string Username { get; set; }
        public string AdresBilgi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        public virtual List<OrderLineModel> OrderLines { get; set; }
    }
    public class OrderLineModel
    {    

        public int Quantity { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }

    }
}

