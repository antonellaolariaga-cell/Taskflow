using System;
using System.Collections.Generic;
using System.Linq;
using Taskflow.Models;

namespace Taskflow.Services
{
    public class TareaService
    {
        private List<Tarea> tareas = new List<Tarea>();

        // Crear tarea
        public void CrearTarea(string titulo, string descripcion, string responsable)
        {
            if (string.IsNullOrEmpty(titulo))
            {
                Console.WriteLine("El título es obligatorio");
                return;
            }

            var tarea = new Tarea(titulo, descripcion, responsable);
            tareas.Add(tarea);

            Console.WriteLine("Tarea creada correctamente");
        }

        // Listar tareas
        public void ListarTareas(EstadoTarea? estadoFiltro = null)
        {
            var lista = estadoFiltro == null
                ? tareas
                : tareas.Where(t => t.Estado == estadoFiltro).ToList();

            foreach (var t in lista)
            {
                Console.WriteLine($"ID: {t.Id}");
                Console.WriteLine($"Título: {t.Titulo}");
                Console.WriteLine($"Responsable: {t.Responsable}");
                Console.WriteLine($"Estado: {t.Estado}");
                Console.WriteLine($"Fecha creación: {t.FechaCreacion}");
                Console.WriteLine($"Última modificación: {t.FechaModificacion}");
                Console.WriteLine("---------------------------");
            }
        }

        
    }
}