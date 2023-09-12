using Dominio.Entities;

namespace API.Dtos
{
    public class PosicionDto
    {
        public int IdPosicion {get;set;}
        public string NombrePosicion { get; set; }
        public ICollection<Jugador> Jugadores { get; set;}

    }
}