using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EquipoDto
    {
        
        public string NombreEquipo { get; set; }
        public int IdPaisFk { get; set; }
        public Pais Pais { get; set; }
        public ICollection<Persona> Personas { get; set; }

    }
}