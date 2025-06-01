using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionContable.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public int NumeroTransaccion { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaTransaccion { get; set; }

        public Transaccion(int numeroTransaccion, string descripcion, decimal monto, string tipo, DateTime fechaTransaccion)
        {
            Id++;
            NumeroTransaccion = numeroTransaccion;
            Descripcion = descripcion;
            Monto = monto;
            Tipo = tipo;
            FechaTransaccion = fechaTransaccion;
        }

        public override string ToString()
        {
            return $"Transacción #{NumeroTransaccion}:\n- Descripción: {Descripcion}\n- Monto: ${Monto}\n- Tipo: {Tipo}\n- Fecha: {FechaTransaccion.ToShortDateString()}";
        }
    }
}
