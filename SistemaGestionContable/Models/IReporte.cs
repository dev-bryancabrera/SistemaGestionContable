using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionContable.Models
{
    internal interface IReporte
    {
        string GenerarReporte(List<Transaccion> transaccions);
    }
}
