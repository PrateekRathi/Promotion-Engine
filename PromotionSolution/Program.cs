using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            PromotionModel model = new PromotionModel();
            model.GetUserInput();
            Environment.Exit(0);
        }
    }
}

