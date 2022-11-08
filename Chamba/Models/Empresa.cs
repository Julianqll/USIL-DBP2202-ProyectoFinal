using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chamba.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Puestos = new HashSet<Puesto>();
        }

        public int IdEmpresa { get; set; }
        [Required(ErrorMessage = "Es obligatorio")]

        public string ApodoEmpresa { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public string NombreEmpresa { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public string RubroEmpresa { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public DateOnly FFundacion { get; set; }
        [Required(ErrorMessage = "Es obligatorio")]

        public string DireccionEmpresa { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public string CorreoEmpresa { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public string BiografiaEmpresa { get; set; } = null!;
        [Required(ErrorMessage = "Es obligatorio")]

        public string FotoPerfilEmpresa { get; set; } = null!;


        public virtual ICollection<Puesto> Puestos { get; set; }
    }
}
