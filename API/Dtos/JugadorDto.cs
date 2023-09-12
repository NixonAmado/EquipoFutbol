using Dominio.Entities;
namespace API.Dtos
{
    public class JugadorDto
    {
        public int IdJugador {get;set;}
        public string DorsalJugador { get; set; }
        public ICollection<Posicion> Posiciones { get; set;}

    }
}