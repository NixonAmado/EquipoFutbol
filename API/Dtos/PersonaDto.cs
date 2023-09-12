using Dominio.Entities;

namespace API.Dtos
{
    public class PersonaDto
    {
        public int IdPersona {get;set;}
        public string NombrePersona { get; set; }
        public string EdadPersona { get; set; }
    }
}