using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Strategies;

public class GanaMaxDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal price)
    {
        return price * 0.10m;
    }
}
