using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Application.Interfaces;

public interface ICodigoBarraService
{
    Task RegistrarCodigoBarraAsync(
        int idProducto);
}
