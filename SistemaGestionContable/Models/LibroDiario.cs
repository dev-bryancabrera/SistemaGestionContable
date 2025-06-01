using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionContable.Models
{
    internal class LibroDiario
    {
        private List<Transaccion> transacciones;
        // private int IdSiguienteTransaccion;

        public LibroDiario()
        {
            transacciones = new List<Transaccion>();
            // IdSiguienteTransaccion = 1;
        }

        public void AgregarTransaccion(Transaccion transaccion)
        {
            transacciones.Add(transaccion);
        }

        public void EliminarTransaccion(int id)
        {
            var transaccion = transacciones.FirstOrDefault(t => t.Id == id);

            if (transaccion != null)
            {
                transacciones.Remove(transaccion);
                Console.WriteLine($"Transacción con ID {id} eliminada.");
            }
            else
            {
                Console.WriteLine($"No se encontró una transacción con ID {id}.");
            }
        }

        public List<Transaccion> ObtenerTransacciones()
        {
            return transacciones;
        }

        public void MostrarTransacciones()
        {
            foreach (var transaccion in transacciones)
            {
                Console.WriteLine($"ID: {transaccion.Id}, Numero: {transaccion.NumeroTransaccion}");
            }
        }

        public Transaccion BuscarTransaccionPorId(int id)
        {
            if (id > 0)
            {
                return transacciones.FirstOrDefault(t => t.Id == id);
            }

            return null;
        }
    }
}
