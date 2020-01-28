using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret_Entity.Entity
{
    public class Cart
    {
        private List<CartLine> _cardLines = new List<CartLine>();

        public List<CartLine> CartLines
        {
            get { return _cardLines; }
        }

        public void AddProduct(Product product, int quantity)
        {
            var line = _cardLines.FirstOrDefault(i => i.Product.Id == product.Id);
            if (line == null)
            {
                _cardLines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduct(Product product)
        {
            
            //var a = _cardLines.Where(i => i.Product.Id == product.Id).FirstOrDefault();
            //if (a.Quantity > 1)
            //{
            //    a.Quantity--;
            //}
            //else
            //{
            //    _cardLines.Remove(a);
            //}
            
            _cardLines.RemoveAll(i=> i.Product.Id==product.Id);            
        }

        public double Total()
        {
            return _cardLines.Sum(i => i.Quantity * i.Product.Price);
        }

        public void Clear()
        {
            _cardLines.Clear();
        }


    }



    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
