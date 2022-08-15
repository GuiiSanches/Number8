using DealerON.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerON.Service
{
    public class ProductService
    {
        private int ONE_HUNDREAD_PERCENT = 100;
       public Decimal GetValeuWithTax(Product product)
        {
            if (GetTotalTaxPercent(product) > 0)
                return GetTaxValue(product) + product.Price;
            else
                return product.Price;
        }

        public decimal GetTaxValue(Product product)
        {
            return (product.Price * GetTotalTaxPercent(product)) / ONE_HUNDREAD_PERCENT;
        }

        private decimal GetTotalTaxPercent(Product product)
        {
            decimal totalTax = 0;

            foreach (var item in product.ProductType)
            {
                totalTax += item.TaxValue.GetTaxPercent();
            }

            return totalTax;
        }
    }
}
