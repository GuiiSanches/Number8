using DealerON.Model.Models;
using DealerON.Repository.Repositories;
using DealerON.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DealerON.SalesTaxes
{
    class Program
    {
        private static ProductMockRepository _productMockRepository { get; set; }
        static void Main(string[] args)
        {
            try
            {
                string asnwerContinueBuying;
                List<Product> products = new List<Product>();
                _productMockRepository = new ProductMockRepository();

                do
                {
                    try
                    {
                        Console.WriteLine("\nChoose the product code of that product you want to buy: \n");
                        ShowProductsToBuy();
                        var productCode = Console.ReadLine();
                        var product = GetProductByCode(productCode);

                        Console.WriteLine("\nType the number of the quantity that you want buy: \n");
                        var quantity = Console.ReadLine();

                        if (isValidQuantity(quantity))
                        {
                            var qtdNumber = int.Parse(quantity);
                            for (int i = 0; i < qtdNumber; i++)
                            {
                                products.Add(product);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Quantity");
                        }
                    }
                    catch (Exception)
                    {
                        //Future implementation Log exception

                    }

                    Console.WriteLine("\nDo you want continue buying?\nType 1 for Yes or 2 for No");
                    asnwerContinueBuying = Console.ReadLine();

                } while (isContinueBuying(asnwerContinueBuying));

                if(products.Any())
                {
                    var receipt = new Receipt();
                    receipt.Products = products;

                    var receiptService = new ReceiptService();

                    Console.WriteLine("\n\nYour Receipt:\n\n");
                    receiptService.PrintReceipt(receipt);

                    Thread.Sleep(10000);
                }
            }
            catch (Exception)
            {

                //Future implementation Log exception
            }

            

            Thread.Sleep(2000);
        }

        private static bool isContinueBuying(string answer)
        {
            try
            {
                var codeChoosed = int.Parse(answer);
                if (codeChoosed == 1)
                    return true;
                else if (codeChoosed == 2)
                    return false;
                else
                    throw new Exception("Invalid number choosed");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid choose");
                throw;
            }
        }

        private static void ShowProductsToBuy()
        {
            foreach (var product in _productMockRepository.GetAll())
            {
                Console.WriteLine($"Code: {product.Code} - {product.Name} - Price {product.Price}");
            }
        }
        private static Product GetProductByCode(string codeProduct)
        {
            try
            {
                var codeChoosed = int.Parse(codeProduct);
                var product = _productMockRepository.GetProduct(codeChoosed);

                if (product != null)
                    return product;
                else
                    throw new Exception("Product don't exist");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid code");
                throw;
            }
        }

        private static bool isValidQuantity(string quantity)
        {
            try
            {
                var qtdNumber = int.Parse(quantity);
                if (qtdNumber > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid quantity");
                throw;
            }
        }
    }

}
