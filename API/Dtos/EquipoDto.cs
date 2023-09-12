using Dominio.Entities;

namespace API.Dtos
{
    public class EquipoDto
    {
        public int IdEquipo {get;set;}        
        public string NombreEquipo { get; set; }
        public ICollection<Persona> Personas { get; set; }

    }
}