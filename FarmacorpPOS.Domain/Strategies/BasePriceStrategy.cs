using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Strategies;

public class BasePriceStrategy : IPriceStrategy
{
    public decimal CalculatePrice(decimal cost)
    {
        return cost * 1.50m;
    }
}
