using System;
using Taskflow.Services;
using Taskflow.Models;
//recuperando
class Program
{
    static void Main(string[] args)
    {
        TareaService servicio = new TareaService();

        while (true)
        {
            Console.WriteLine("\n--- TASKFLOW ---");
            Console.WriteLine("1. Crear tarea");
            Console.WriteLine("2. Listar todas");
            Console.WriteLine("3. Listar pendientes");
            Console.WriteLine("4. Listar en progreso");
            Console.WriteLine("5. Listar completadas");
            Console.WriteLine("6. Cambiar estado");
            Console.WriteLine("0. Salir");
              var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Título: ");
                    var titulo = Console.ReadLine();

                    Console.Write("Descripción: ");
                    var desc = Console.ReadLine();

                    Console.Write("Responsable: ");
                    var resp = Console.ReadLine();

                    servicio.CrearTarea(titulo, desc, resp);
                    break;

                case "2":
                    servicio.ListarTareas();
                    break;

                case "3":
                    servicio.ListarTareas(EstadoTarea.Pendiente);
                    break;

                case "4":
                    servicio.ListarTareas(EstadoTarea.EnProgreso);
                    break;

                case "5":
                    servicio.ListarTareas(EstadoTarea.Completada);
                    break;

                case "6":
                    Console.Write("ID de tarea: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("1. Pendiente");
                    Console.WriteLine("2. En progreso");
                    Console.WriteLine("3. Completada");

                    var estado = Console.ReadLine();

                    EstadoTarea nuevoEstado = estado switch
                    {
                        "1" => EstadoTarea.Pendiente,
                        "2" => EstadoTarea.EnProgreso,
                        "3" => EstadoTarea.Completada,
                        _ => EstadoTarea.Pendiente
                    };

                    servicio.CambiarEstado(id, nuevoEstado);
                    break;

                case "0":
                    return;
            }
        }
    }
}