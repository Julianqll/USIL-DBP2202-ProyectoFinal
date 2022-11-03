using System;
using System.Collections.Generic;

namespace Chamba.Models
{
    public partial class Puesto
    {
        public int IdPuesto { get; set; }
        public string NombrePuesto { get; set; } = null!;
        public string DescripcionPuesto { get; set; } = null!;
        public double Salario { get; set; }
        public string LugarPuesto { get; set; } = null!;
        public int TipoPuesto { get; set; }
        public int VacantesPuesto { get; set; }
        public int EmpresaPuesto { get; set; }
        public int FotoPuesto { get; set; }
    }
}
