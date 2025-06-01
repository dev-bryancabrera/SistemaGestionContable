using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionContable.Models
{
    public abstract class Calculadora
    {
        protected List<Transaccion> transacciones;

        public Calculadora(List<Transaccion> transacciones)
        {
            this.transacciones = transacciones;
        }

        public abstract decimal CalcularIngresos();
        public abstract decimal CalcularEgresos();
        public abstract decimal CalcularBalance();
    }
}
