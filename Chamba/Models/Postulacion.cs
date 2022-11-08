using System;
using System.Collections.Generic;

namespace Chamba.Models
{
    public partial class Postulacion
    {
        public int IdPostulacion { get; set; }
        public int Postulante { get; set; }
        public int Puesto { get; set; }
        public string? Observacion { get; set; } = null;
        public string? EstadoPostulacion { get; set; } = null;
        public string? ComentarioPostulante { get; set; } = null;
        public string? CvPostulante { get; set; } = null;

        public virtual Usuario? PostulanteNavigation { get; set; } = null;
        public virtual Puesto? PuestoNavigation { get; set; } = null;
    }
}
