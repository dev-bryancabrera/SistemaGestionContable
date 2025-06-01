using System.Net.Mail;
using SistemaGestionContable.Models;

class Program
{
    static void Main(string[] args)
    {
        LibroDiario libroDiario = new LibroDiario();
        bool continuarEjecutando = true;

        while (continuarEjecutando)
        {
            MostrarMenu();
            string opcionUsuario = Console.ReadLine()!.Trim();

            switch (opcionUsuario)
            {
                case "1":
                    AgregarTransacciones(libroDiario);
                    break;
                case "2":
                    MostrarTransacciones(libroDiario);
                    break;
                case "3":
                    GenerarReporte(libroDiario);
                    break;
                case "4":
                    continuarEjecutando = false;
                    break;

                default:
                    Console.WriteLine("Opción no valida!");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("1. Agregar Transacción");
        Console.WriteLine("2. Mostrar Transacciones");
        Console.WriteLine("3. Generar Reporte");
        Console.WriteLine("4. Salir");
        Console.WriteLine("Seleccione una opción: ");
    }

    static void AgregarTransacciones(LibroDiario libroDiario)
    {
        Console.WriteLine("-- Nueva Transacción --");
        Console.WriteLine("Número de Transacción: ");
        int numeroTransaccion = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Descripción: ");
        string descripcion = Console.ReadLine()!;
        Console.WriteLine("Monto: ");
        decimal monto = decimal.Parse(Console.ReadLine()!);
        Console.WriteLine("Tipo (Ingreso/Egreso):");
        string tipo = Console.ReadLine()!;
        Console.WriteLine("Fecha: (dd/MM/yyyy):");
        DateTime fecha = DateTime.Parse(Console.ReadLine()!);
        Transaccion nuevaTransaccion = new Transaccion(numeroTransaccion, descripcion, monto, tipo, fecha);
        string mensajeError;
        if (libroDiario.AgregarTransaccion(nuevaTransaccion, out mensajeError))
        {
            Console.WriteLine("Transacción Agregada correctamente!");
        }
        else
        {
            Console.WriteLine($"Error: {mensajeError}");
        }
    }

    static void MostrarTransacciones(LibroDiario libroDiario)
    {
        libroDiario.MostrarTransacciones();
    }

    static void GenerarReporte(LibroDiario libroDiario)
    {
        Console.Clear();
        Console.WriteLine("-- Gneración de Reporte --");
        Console.WriteLine("1. Reporte de Texto");
        Console.WriteLine("2. Reporte en formato JSON");
        string opcionReporte = Console.ReadLine()!.Trim();

        IReporte reporteGenerador;

        switch (opcionReporte)
        {
            case "1":
                reporteGenerador = new ReporteTexto();
                break;
            case "2":
                reporteGenerador = new ReporteJSON();
                break;
            default:
                Console.WriteLine("Opción no válida!");
                return;
        }
        string reporte = libroDiario.GenerarReporte(reporteGenerador);
        Console.Clear();
        Console.WriteLine(reporte);
    }
}