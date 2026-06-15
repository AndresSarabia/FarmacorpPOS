using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Strategies;

public class BaseStockStrategy : IStockStrategy
{
    public bool CanSell(
        int currentStock,
        int quantity)
    {
        return currentStock >= quantity;
    }
}
