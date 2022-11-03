using System;
using System.Collections.Generic;

namespace Chamba.Models
{
    public partial class Empresa
    {
        public int IdEmpresa { get; set; }
        public string ApodoEmpresa { get; set; } = null!;
        public string NombreEmpresa { get; set; } = null!;
        public int RubroEmpresa { get; set; }
        public DateOnly FFundacion { get; set; }
        public string DireccionEmpresa { get; set; } = null!;
        public string CorreoEmpresa { get; set; } = null!;
        public string BiografiaEmpresa { get; set; } = null!;
        public string FotoPerfilEmpresa { get; set; } = null!;
    }
}
