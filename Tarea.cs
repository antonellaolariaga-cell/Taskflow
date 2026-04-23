using System;

namespace TaskFlow
{
    public enum EstadoTarea { Pendiente, EnProgreso, Finalizada, Completada} // [cite: 6, 42, 43, 44]

    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; } // [cite: 26]
        public string Descripcion { get; set; } // [cite: 27]
        public string Responsable { get; set; } // [cite: 28]
        public EstadoTarea Estado { get; set; } // [cite: 29]
        public DateTime FechaCreacion { get; set; } // [cite: 40]
        public DateTime? FechaModificacion { get; set; } // 
        public DateTime FechaUltimaModificacion { get; internal set; }

        public Tarea(int id, string titulo, string responsable, string descripcion)
        {
            Id = id;
            Titulo = titulo;
            Responsable = responsable;
            Descripcion = descripcion;
            Estado = EstadoTarea.Pendiente; // Estado inicial siempre Pendiente [cite: 29]
            FechaCreacion = DateTime.Now;
        }
    }
}