using System;
using System.Collections.Generic;

namespace Chamba.Models
{
    public partial class Login
    {
        public int IdLogin { get; set; }
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Rol { get; set; } = null!;
    }
}
