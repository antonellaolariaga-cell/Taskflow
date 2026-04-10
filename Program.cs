using System;
using Taskflow.Services;
using Taskflow.Models;

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
        }
    }
}