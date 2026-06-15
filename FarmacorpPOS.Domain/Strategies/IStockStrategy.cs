using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Strategies;

public interface IStockStrategy
{
    bool CanSell(int currentStock, int quantity);
}
