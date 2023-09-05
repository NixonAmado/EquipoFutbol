using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class TipoNomina : BaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
}