using Dominio.Entities;

namespace API.Dtos
{
    public class PaisDto
    {
        public int IdPais {get;set;}
        public string NombrePais { get; set; }
        public ICollection<Equipo> Equipos { get; set; }

    }
}