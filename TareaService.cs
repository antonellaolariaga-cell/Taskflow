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
            // PR-Fix 1: Se reemplaza IsNullOrEmpty por IsNullOrWhiteSpace para cubrir
            // el caso en que el título sea solo espacios en blanco (ej: "   ")
            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("El título es obligatorio");
                return;
            }

            // PR-Fix 2: Se agrega validación del responsable, antes se creaba
            // la tarea aunque responsable viniera vacío o con espacios
            if (string.IsNullOrWhiteSpace(responsable))
            {
                Console.WriteLine("El responsable es obligatorio");
                return;
            }

            var tarea = new Tarea(titulo, descripcion, responsable);

            // PR-Fix 4: Se fuerza explícitamente el estado inicial a Pendiente,
            // según el requerimiento funcional, en lugar de delegarlo al constructor
            tarea.Estado = EstadoTarea.Pendiente;

            tareas.Add(tarea);
            Console.WriteLine("Tarea creada correctamente");
        }

        // Listar tareas
        public void ListarTareas(EstadoTarea? estadoFiltro = null)
        {
            var lista = estadoFiltro == null
                ? tareas
                : tareas.Where(t => t.Estado == estadoFiltro).ToList();

            // PR-Fix 3: Se agrega validación de lista vacía para evitar que el sistema
            // no imprima nada, lo que generaba confusión al usuario
            if (!lista.Any())
            {
                Console.WriteLine("No hay tareas para mostrar.");
                return;
            }

            foreach (var t in lista)
            {
                Console.WriteLine($"ID: {t.Id}");
                Console.WriteLine($"Título: {t.Titulo}");
                Console.WriteLine($"Responsable: {t.Responsable}");
                Console.WriteLine($"Estado: {t.Estado}");
                Console.WriteLine($"Fecha creación: {t.FechaCreacion:dd/MM/yyyy HH:mm}");

                // PR-Fix 5: Se imprime la fecha de última modificación solo si la tarea
                // fue modificada al menos una vez, evitando mostrar un valor nulo o confuso
                if (t.FechaModificacion.HasValue)
                    Console.WriteLine($"Última modificación: {t.FechaModificacion.Value:dd/MM/yyyy HH:mm}");

                Console.WriteLine("---------------------------");
            }
        }

        // Cambiar estado
        public void CambiarEstado(int id, EstadoTarea nuevoEstado)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null)
            {
                Console.WriteLine("Tarea no encontrada");
                return;
            }

            tarea.Estado = nuevoEstado;
            tarea.FechaModificacion = DateTime.Now;
            Console.WriteLine("Estado actualizado correctamente");
        }

        // PR-Fix 6: Se agrega método CambiarResponsable por ID, requerido en la
        // especificación funcional y que no estaba implementado
        public void CambiarResponsable(int id, string nuevoResponsable)
        {
            if (string.IsNullOrWhiteSpace(nuevoResponsable))
            {
                Console.WriteLine("El responsable no puede estar vacío");
                return;
            }

            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null)
            {
                Console.WriteLine("Tarea no encontrada");
                return;
            }

            tarea.Responsable = nuevoResponsable;
            tarea.FechaModificacion = DateTime.Now;
            Console.WriteLine("Responsable actualizado correctamente");
        }

        // PR-Fix 7: Se agrega método EliminarTarea por ID, requerido en la
        // especificación funcional y que no estaba implementado
        public void EliminarTarea(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null)
            {
                Console.WriteLine("Tarea no encontrada");
                return;
            }

            tareas.Remove(tarea);
            Console.WriteLine("Tarea eliminada correctamente");
        }
    }
}
