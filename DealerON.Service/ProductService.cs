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
        private decimal NEAREST_VALUE = (decimal)0.05;
        public Decimal GetValeuWithTax(Product product)
        {
            if (GetTotalTaxPercent(product) > 0)
                return GetTaxValue(product) + product.Price;
            else
                return product.Price;
        }

        public decimal GetTaxValue(Product product)
        {
            return RoundTax((product.Price * GetTotalTaxPercent(product)) / ONE_HUNDREAD_PERCENT);
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

        private decimal RoundTax(decimal taxValue)
        {
            taxValue = Math.Round(taxValue, 2);

            var integerPortion = Math.Floor(taxValue);
            var decimalPortion = taxValue - integerPortion;

            while (isNecessaryRound(decimalPortion))
            {
                decimalPortion += (decimal)0.01;
                taxValue = integerPortion + decimalPortion;
            }

            return taxValue;
        }

        private bool isNecessaryRound(decimal decimalPortion)
        {
            return (decimalPortion % NEAREST_VALUE) != 0;
        }

    }
}

