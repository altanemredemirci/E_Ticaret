using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticaret_WEBUI.Models
{
    public class ProductModel //Description bilgilerini kısaltma
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }       

        public int CategoryId { get; set; }
      
    }
}