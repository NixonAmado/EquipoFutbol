using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class JugadorPosicion
    {
        public int IdJugadorFk  { get; set; }
        public Jugador Jugador { get; set; }
        public int IdPosicionFk  { get; set; }
        public Posicion Posicion { get; set; }
    }
}