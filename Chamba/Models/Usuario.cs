using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chamba.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Es obligatorio")]

        public string ApodoUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]
        public string NombresUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public string ApellidosUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public DateOnly FNacUsuario { get; set; }
        [Required(ErrorMessage = "Es obligatorio")]

        public string SexoUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public string EstudiosUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public string CorreoUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public string BiografiaUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public string FotoPerfilUsuario { get; set; } = null!;
    }
}
