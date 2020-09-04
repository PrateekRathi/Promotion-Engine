using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionSolution
{
    public interface IProductDetails
    {
        int GetTotalPrice(List<ProductDetails> products);
    }
}
