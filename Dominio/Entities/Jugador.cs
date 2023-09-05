using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Jugador:BaseEntity
    {

        public string Dorsal { get; set; }
        public int IdPersonaFk  { get; set; }
        public Persona Persona { get; set; }
        public ICollection<Posicion> Posiciones { get; set;}
        public ICollection<JugadorPosicion> JugadorPosiciones { get; set;}  = new HashSet<JugadorPosicion>();

    }
}