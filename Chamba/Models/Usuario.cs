using System;
using System.Collections.Generic;

namespace Chamba.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string ApodoUsuario { get; set; } = null!;
        public string NombresUsuario { get; set; } = null!;
        public string ApellidosUsuario { get; set; } = null!;
        public int EdadUsuario { get; set; }
        public string SexoUsuario { get; set; } = null!;
        public string EstudiosUsuario { get; set; } = null!;
        public string CorreoUsuario { get; set; } = null!;
        public string ContrasenaUsuario { get; set; } = null!;
        public string BiografiaUsuario { get; set; } = null!;
    }
}
