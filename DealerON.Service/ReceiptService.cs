using DealerON.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerON.Service
{
    public class ReceiptService
    { 

        private ProductService _productService { get; set; }
        private Product printedtBefore { get; set; }
        private const String SALES_TAXES = "Sales Taxes:";
        private const String TOTAL = "Total:";

        public ReceiptService()
        {
            _productService = new ProductService();
        }
        public void PrintReceipt(Receipt receipt)
        {
            foreach (var product in receipt.Products)
            {
                if(HasMoreThanOneInReceipt(product, receipt))
                {
                    if(!AlreadyPrintedBefore(product))
                    {
                        Console.WriteLine(String.Format("{0}: {1} ({2} @ {3})", product.Name,
                        GetTotalValueForSameProductInReceipt(product, receipt).ToString("F"),
                        GetSameProductQuantity(product, receipt),
                        _productService.GetValeuWithTax(product).ToString("F")));

                        printedtBefore = product;
                    }
                }
                else
                {
                    Console.WriteLine(String.Format("{0}: {1}", product.Name, _productService.GetValeuWithTax(product).ToString("F")));
                }
            }

            Console.WriteLine(String.Format("{0} {1}", SALES_TAXES, GetTotalTaxes(receipt).ToString("F")));
            Console.WriteLine(String.Format("{0} {1}", TOTAL, GetTotalWithTax(receipt).ToString("F")));
        }

        public bool AlreadyPrintedBefore(Product product)
        {
            return printedtBefore != null && product.Name == printedtBefore.Name;
        }
        private bool HasMoreThanOneInReceipt(Product product, Receipt receipt)
        {
            return GetSameProductQuantity(product, receipt) > 1;
        }

        private int GetSameProductQuantity(Product product, Receipt receipt)
        {
            return receipt.Products.Where(p => p.Name == product.Name).Count();
        }

        private decimal GetTotalValueForSameProductInReceipt(Product sameProduct, Receipt receipt)
        {
            decimal totalValue = 0;

            foreach (var product in receipt.Products)
            {
                if(product.Name == sameProduct.Name)
                    totalValue += _productService.GetValeuWithTax(product);
            }

            return totalValue;
        }

        private decimal GetTotalTaxes(Receipt receipt)
        {
            decimal totalTaxes = 0;

            foreach (var product in receipt.Products)
            {
                totalTaxes += _productService.GetTaxValue(product);
            }

            return totalTaxes;
        }

        private decimal GetTotalWithTax(Receipt receipt)
        {
            decimal totalValue = 0;

            foreach (var product in receipt.Products)
            {
                totalValue += _productService.GetValeuWithTax(product);
            }

            return totalValue;
        }

    }
}
