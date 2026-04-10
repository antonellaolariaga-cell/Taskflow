using System;

namespace Taskflow.Models
{
    public enum EstadoTarea
    {
        Pendiente,
        EnProgreso,
        Completada
    }

    public class Tarea
    {
        private static int contadorId = 1;

        public int Id { get; private set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Responsable { get; set; }
        public EstadoTarea Estado { get; set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaModificacion { get; set; }

        public Tarea(string titulo, string descripcion, string responsable)
        {
            Id = contadorId++;
            Titulo = titulo;
            Descripcion = descripcion;
            Responsable = responsable;
            Estado = EstadoTarea.Pendiente;
            FechaCreacion = DateTime.Now;
        }
    }
}