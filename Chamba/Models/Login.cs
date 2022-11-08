using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chamba.Models
{
    public partial class Login
    {
        public int IdLogin { get; set; }
        [Required(ErrorMessage = "Es obligatorio")]

        public string Correo { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public string Contraseña { get; set; } = null!;
        public string? Rol { get; set; } = null;

    }
}
