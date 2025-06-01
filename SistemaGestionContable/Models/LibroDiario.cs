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

        public string GenerarReporte(IReporte reporte)
        {
            return reporte.GenerarReporte(_transacciones);
        }

        public void MostrarCalculos()
        {
            CalculadoraBasica calculadora = new CalculadoraBasica(_transacciones);
            Console.WriteLine($"Total Ingresos: {calculadora.CalcularIngresos():C}");
            Console.WriteLine($"Total Egresos: {calculadora.CalcularEgresos():C}");
            Console.WriteLine($"Balance: {calculadora.CalcularBalance():C}");
            Console.WriteLine($"IVA (16%): {calculadora.CalcularIVA(16):C}");
        }
    }
}
