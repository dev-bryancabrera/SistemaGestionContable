using System.Text.Json;

namespace SistemaGestionContable.Models
{
    internal class ReporteJSON : IReporte
    {
        public string GenerarReporte(List<Transaccion> transaccions)
        {
            var reporte = new
            {
                Fecha = DateTime.Now,
                Transacciones = transaccions.Select(transaccion => new
                {
                    transaccion.NumeroTransaccion,
                    transaccion.Descripcion,
                    transaccion.Monto,
                    transaccion.Tipo,
                    transaccion.FechaTransaccion
                }).ToList()
            };

            return JsonSerializer.Serialize(reporte, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
        }
    }
}
