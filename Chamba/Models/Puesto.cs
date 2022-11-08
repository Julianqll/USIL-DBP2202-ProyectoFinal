using System;
using System.Collections.Generic;

namespace Chamba.Models
{
    public partial class Puesto
    {
        public Puesto()
        {
            Postulacions = new HashSet<Postulacion>();
        }

        public int IdPuesto { get; set; }
        public string NombrePuesto { get; set; } = null!;
        public string DescripcionPuesto { get; set; } = null!;
        public double Salario { get; set; }
        public string LugarPuesto { get; set; } = null!;
        public string TipoPuesto { get; set; } = null!;
        public int VacantesPuesto { get; set; }
        public int Empresa { get; set; }
        public string FotoPuesto { get; set; } = null!;

        public virtual Empresa? EmpresaNavigation { get; set; } = null;
        public virtual ICollection<Postulacion> Postulacions { get; set; }
    }
}
