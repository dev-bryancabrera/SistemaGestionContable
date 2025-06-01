using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionContable.Models
{
    internal class ReporteTexto : IReporte
    {
        public string GenerarReporte(List<Transaccion> transaccions)
        {
            var reporte = $"REPORTE DEL {DateTime.Now.ToLongDateString()}\n";
            reporte += "---------------------------------\n";
            foreach (var transaccion in transaccions)
            {
                reporte += $"{transaccion.NumeroTransaccion}. {transaccion.Descripcion} - {transaccion.Monto:C} ({transaccion.Tipo})\n";
            }
            return reporte;
        }
    }
}
