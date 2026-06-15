using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Strategies;

public interface IPriceStrategy
{
    decimal CalculatePrice(decimal cost);
}
