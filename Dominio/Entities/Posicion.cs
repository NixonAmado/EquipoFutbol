using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Posicion:BaseEntity
    {
        public String Nombre { get; set;}
        public ICollection<Jugador> Jugadores { get; set;}
        public ICollection<JugadorPosicion> JugadorPosiciones { get; set;}  = new HashSet<JugadorPosicion>();

    }
}