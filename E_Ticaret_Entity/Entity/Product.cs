using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret_Entity.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public bool IsApproved { get; set; } //Onaylı mı? onaylıysa satışta olacak
        public bool IsHome { get; set; } //Anasayfada görünsün mü?

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
