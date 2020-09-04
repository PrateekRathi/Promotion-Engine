using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionSolution
{
    public class ProductDetails
    {
        public ProductDetails(string id)
        {
            Id = id;
            switch (id)
            {
                case "A":
                    Price = 50;
                    break;

                case "B":
                    Price = 30;
                    break;

                case "C":
                    Price = 20;
                    break;

                case "D":
                    Price = 15;
                    break;

                default:break;
            }
        }
        public string Id { get; set; }
        public int Price { get; set; }
    } 
}
