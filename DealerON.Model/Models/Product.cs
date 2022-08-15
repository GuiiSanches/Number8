using DealerON.Model.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerON.Model.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IList<ProductTaxt_Type> ProductType { get; set; }
    }
}
