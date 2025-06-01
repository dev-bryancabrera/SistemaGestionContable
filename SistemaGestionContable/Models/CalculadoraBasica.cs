namespace SistemaGestionContable.Models
{
    public class CalculadoraBasica : Calculadora
    {
        public CalculadoraBasica(List<Transaccion> transacciones) : base(transacciones)
        {
        }
        public override decimal CalcularIngresos()
        {
            return transacciones.Where(transaccion => transaccion.Tipo.Equals("Ingreso")).Sum(transaccion => transaccion.Monto);
        }
        public override decimal CalcularEgresos()
        {
            return transacciones.Where(transacciones => transacciones.Tipo.Equals("Egreso")).Sum(transaccion => transaccion.Monto);
        }

        public override decimal CalcularBalance()
        {
            return CalcularIngresos() - CalcularEgresos();
        }

        public decimal CalcularIVA(decimal tasaIVA)
        {
            return transacciones.Where(transaccion => transaccion.Tipo.Equals("Ingreso"))
                .Sum(transaccion => transaccion.Monto * (tasaIVA / 100));
        }
    }
}
