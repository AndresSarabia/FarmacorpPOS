using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Strategies;

public class GanaMaxStockStrategy : IStockStrategy
{
    public bool CanSell(
        int currentStock,
        int quantity)
    {
        return (currentStock - quantity) > 10;
    }
}
