using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Application.Utilities;

public static class UniqueCodeGenerator
{
    public static string Generate()
    {
        return Guid.NewGuid()
            .ToString("N")
            .ToUpper();
    }
}
