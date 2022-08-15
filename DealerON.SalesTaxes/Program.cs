using DealerON.Model.Models;
using DealerON.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerON.SalesTaxes
{
    class Program
    {
        static void Main(string[] args)
        {
            Output1();
            Output2();
            Output3();


            Console.ReadLine();
            
        }

        private static void Output1()
        {
            Console.WriteLine("\nOutput 1");
            var receipt = new Receipt();
            receipt.Products = GetProducts_Input1();

            var receiptService = new ReceiptService();
            receiptService.PrintReceipt(receipt);

        }

        private static void Output2()
        {
            Console.WriteLine("\nOutput 2");
            var receipt = new Receipt();
            receipt.Products = GetProducts_Input2();

            var receiptService = new ReceiptService();
            receiptService.PrintReceipt(receipt);
        }

        private static void Output3()
        {
            Console.WriteLine("\nOutput 3");
            var receipt = new Receipt();
            receipt.Products = GetProducts_Input3();

            var receiptService = new ReceiptService();
            receiptService.PrintReceipt(receipt);
        }

        private static List<ProductTaxt_Type> ProductsTaxes()
        {
            var productTaxes = new List<ProductTaxt_Type>();

            var tax_TypeBook = new ProductTaxt_Type(Model.Models.Enum.EnumType.Book);
            var tax_TypeFood = new ProductTaxt_Type(Model.Models.Enum.EnumType.Food);
            var tax_TypeImported = new ProductTaxt_Type(Model.Models.Enum.EnumType.Imported);
            var tax_TypeMedical = new ProductTaxt_Type(Model.Models.Enum.EnumType.Medical);
            var tax_TypeBasic = new ProductTaxt_Type(Model.Models.Enum.EnumType.Other);

            productTaxes.Add(tax_TypeBook);
            productTaxes.Add(tax_TypeFood);
            productTaxes.Add(tax_TypeImported);
            productTaxes.Add(tax_TypeMedical);
            productTaxes.Add(tax_TypeBasic);

            return productTaxes;
        }
        private static List<Product> GetProducts_Input1()
        {
            var products = new List<Product>();
            var taxes = ProductsTaxes();


            var product_book_Dune = new Product();
            product_book_Dune.Name = "Book";
            product_book_Dune.Price = (decimal)12.49;
            product_book_Dune.ProductType = new List<ProductTaxt_Type>();
            product_book_Dune.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Book));

            var product_book_LR = new Product();
            product_book_LR.Name = "Book";
            product_book_LR.Price = (decimal)12.49;
            product_book_LR.ProductType = new List<ProductTaxt_Type>();
            product_book_LR.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Book));

            var product_music_CD = new Product();
            product_music_CD.Name = "CD Music";
            product_music_CD.Price = (decimal)14.99;
            product_music_CD.ProductType = new List<ProductTaxt_Type>();
            product_music_CD.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Other));

            var product_Chocolate = new Product();
            product_Chocolate.Name = "Chocolate";
            product_Chocolate.Price = (decimal)0.85;
            product_Chocolate.ProductType = new List<ProductTaxt_Type>();
            product_Chocolate.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Food));

            products.Add(product_book_Dune);
            products.Add(product_book_LR);
            products.Add(product_music_CD);
            products.Add(product_Chocolate);

            return products;
        }

        private static List<Product> GetProducts_Input2()
        {
            var products = new List<Product>();
            var taxes = ProductsTaxes();


            var productImportedChocolate = new Product();
            productImportedChocolate.Name = "Imported box of chocolates";
            productImportedChocolate.Price = (decimal)10;
            productImportedChocolate.ProductType = new List<ProductTaxt_Type>();
            productImportedChocolate.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Imported));
            productImportedChocolate.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Food));

            var productImportedPerfume = new Product();
            productImportedPerfume.Name = "Imported bottle of perfume";
            productImportedPerfume.Price = (decimal)47.50;
            productImportedPerfume.ProductType = new List<ProductTaxt_Type>();
            productImportedPerfume.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Imported));
            productImportedPerfume.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Other));

            products.Add(productImportedChocolate);
            products.Add(productImportedPerfume);

            return products;
        }

        private static List<Product> GetProducts_Input3()
        {
            var products = new List<Product>();
            var taxes = ProductsTaxes();


            var productImportedPerfume = new Product();
            productImportedPerfume.Name = "Imported bottle of perfume";
            productImportedPerfume.Price = (decimal)27.99;
            productImportedPerfume.ProductType = new List<ProductTaxt_Type>();
            productImportedPerfume.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Imported));
            productImportedPerfume.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Other));


            var productPerfume = new Product();
            productPerfume.Name = "Bottle of perfume";
            productPerfume.Price = (decimal)18.99;
            productPerfume.ProductType = new List<ProductTaxt_Type>();
            productPerfume.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Other));

            var productHedachePills = new Product();
            productHedachePills.Name = "Packet of headache pills";
            productHedachePills.Price = (decimal)9.75;
            productHedachePills.ProductType = new List<ProductTaxt_Type>();
            productHedachePills.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Medical));

            var productImportedChocolate = new Product();
            productImportedChocolate.Name = "Imported box of chocolates";
            productImportedChocolate.Price = (decimal)11.25;
            productImportedChocolate.ProductType = new List<ProductTaxt_Type>();
            productImportedChocolate.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Imported));
            productImportedChocolate.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Food));

            var productImportedChocolate_2 = new Product();
            productImportedChocolate_2.Name = "Imported box of chocolates";
            productImportedChocolate_2.Price = (decimal)11.25;
            productImportedChocolate_2.ProductType = new List<ProductTaxt_Type>();
            productImportedChocolate_2.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Imported));
            productImportedChocolate_2.ProductType.Add(taxes.FirstOrDefault(t => t.Type == Model.Models.Enum.EnumType.Food));

            products.Add(productImportedPerfume);
            products.Add(productPerfume);
            products.Add(productHedachePills);
            products.Add(productImportedChocolate);
            products.Add(productImportedChocolate_2);

            return products;
        }
    }
}
