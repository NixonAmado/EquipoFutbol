using Dominio.Entities;
namespace API.Dtos
{
    public class TipoNominaDto
    {
        public int IdTipoNomina {get;set;}
        public string NombreTipoNomina { get; set; }
        public ICollection<Persona> Personas { get; set; }

    }
}