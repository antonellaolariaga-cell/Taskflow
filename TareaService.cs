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

    }
}