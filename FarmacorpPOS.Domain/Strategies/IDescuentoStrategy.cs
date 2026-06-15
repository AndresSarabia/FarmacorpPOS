using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Strategies;

public interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal price);
}
