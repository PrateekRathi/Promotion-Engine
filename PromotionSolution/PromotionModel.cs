using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionSolution
{
    public class PromotionModel : IProductDetails
    {
        public void GetUserInput()
        {
            List<ProductDetails> products = new List<ProductDetails>();
            var userInputValue = string.Empty;
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.WriteLine("Total number of orders");
                userInputValue = Console.ReadLine();
                isValidInput = ValidateNumberofOrder(userInputValue);
                if (!isValidInput)
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
            int numberOfOrders = Convert.ToInt32(userInputValue);
            for (int i = 0; i < numberOfOrders; i++)
            {
                Console.WriteLine("Enter the Product Category : A,B,C,D");
                string productCategory = Console.ReadLine().ToUpper();
                bool isValidProductCategory = ValidateProductCategory(productCategory);
                if (!isValidProductCategory)
                {
                    Console.WriteLine("Please enter a valid Product Category.");
                    i--;
                    continue;
                }
                ProductDetails p = new ProductDetails(productCategory);
                products.Add(p);
            }
            var totalPrice = GetTotalPrice(products);
            Console.WriteLine("Total Order Value : {0}", totalPrice);
            Console.ReadLine();
        }

        private bool ValidateNumberofOrder(string inputValue)
        {
            return inputValue.All(char.IsNumber);
        }

        private bool ValidateProductCategory(string productCategory)
        {
            string[] ListOfProductCategory = new string[] { "A", "B", "C", "D" };
            return ListOfProductCategory.Contains(productCategory);
        }

        public int GetTotalPrice(List<ProductDetails> products)
        {
            var listofDistinctProduct = products.GroupBy(i => i.Id).Select(i => new { Id = i.Key, CountOfProductCategory = i.Count(), i.FirstOrDefault().Price }).OrderBy(a => a.Id).ToList();
            int counterofC, counterofD, priceofC, priceofD, totalPriceOfC, totalPriceOfD, totalPrice;
            counterofC = counterofD = priceofC = priceofD = totalPriceOfC = totalPriceOfD = totalPrice = 0;

            for (int i = 0; i < listofDistinctProduct.Count(); i++)
            {
                switch (listofDistinctProduct[i].Id)
                {
                    case "A":
                        totalPrice += (listofDistinctProduct[i].CountOfProductCategory / 3) * 130 + (listofDistinctProduct[i].CountOfProductCategory % 3 * listofDistinctProduct[i].Price);
                        break;
                    case "B":
                        totalPrice += (listofDistinctProduct[i].CountOfProductCategory / 2) * 45 + (listofDistinctProduct[i].CountOfProductCategory % 2 * listofDistinctProduct[i].Price);
                        break;
                    case "C":
                        counterofC = listofDistinctProduct[i].CountOfProductCategory;
                        priceofC = listofDistinctProduct[i].Price;
                        totalPriceOfC = counterofC * priceofC;
                        break;
                    case "D":
                        counterofD = listofDistinctProduct[i].CountOfProductCategory;
                        priceofD = listofDistinctProduct[i].Price;
                        totalPriceOfD = counterofD * priceofD;
                        break;
                }
            }
            if (counterofC <= counterofD)
            {
                counterofD = counterofC + counterofD;
                totalPriceOfC = 0;
                totalPriceOfD = (counterofD / 2) * 30 + (counterofD % 2 * priceofD);
            }
            else if (counterofD > 0)
            {
                counterofC = counterofC + counterofD;
                totalPriceOfC = (counterofC / 2) * 30 + (counterofC % 2 * priceofC);
                totalPriceOfD = 0;
            }
            return totalPrice + totalPriceOfC + totalPriceOfD;
        }
    }
}
