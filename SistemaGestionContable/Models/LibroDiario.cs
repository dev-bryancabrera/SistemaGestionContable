using SistemaGestionContable.Helpers;

namespace SistemaGestionContable.Models
{
    internal class LibroDiario
    {
        private readonly List<Transaccion> _transacciones;

        public LibroDiario()
        {
            _transacciones = new List<Transaccion>();
        }

        public bool AgregarTransaccion(Transaccion transaccion, out string mensajeError)
        {
            mensajeError = string.Empty;
            try
            {
                ValidacionHelper.ValidarTransaccion(transaccion);
                _transacciones.Add(transaccion);
                return true;
            }
            catch (Exception e)
            {
                mensajeError = e.Message;
                return false;
            }
        }
        public void MostrarTransacciones()
        {
            if (_transacciones.Count == 0)
            {
                Console.WriteLine($"No existen transacciones\n" +
                    $"* Utilize la opción 1 para agregar transacciones *");
            }
            foreach (var transaccion in _transacciones)
            {
                Console.WriteLine(transaccion.ToString());
            }
        }
    }
}
