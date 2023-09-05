using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Persona : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int  Edad { get; set; }
        public int IdEquipoFk { get; set; }
        public Equipo Equipo { get; set; }
        public int IdTipoFk { get; set; }
        public TipoNomina Tipo { get; set; }        
        public int IdJugadorFk  { get; set; }
        public Jugador Jugador { get; set; }
    }
}