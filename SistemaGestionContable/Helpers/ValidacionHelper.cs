using SistemaGestionContable.Models;

namespace SistemaGestionContable.Helpers
{
    internal class ValidacionHelper
    {
        public static bool ValidarTransaccion(Transaccion transaccion)
        {
            if (transaccion == null)
            {
                throw new ArgumentNullException("La transacción no puede ser nula.");
            }
            if (string.IsNullOrWhiteSpace(transaccion.Descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");

            }
            if (transaccion.Monto == 0)
            {
                throw new ArgumentException("El monto no puede ser cero.");
            }
            if (string.IsNullOrEmpty(transaccion.Tipo) || (transaccion.Tipo != "Ingreso" && transaccion.Tipo != "Egreso"))
            {
                throw new ArgumentException("El tipo debe ser 'Ingreso' o 'Egreso'.");
            }
            if (transaccion.FechaTransaccion > DateTime.Now)
            {
                throw new ArgumentException("La fecha no puede ser futura.");
            }
            return true;
        }
    }
}
