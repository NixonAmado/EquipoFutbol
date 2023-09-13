using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace API.Dtos
{
    public class EquipoFullDto
        {
        public int Id{ get; set; }
        public string Nombre { get; set; }
        public int IdPaisFk { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
}