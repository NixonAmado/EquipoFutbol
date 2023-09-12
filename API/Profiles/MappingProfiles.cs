

using API.Dtos;
using AutoMapper;
using Dominio.Entities;

public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Equipo, EquipoDto>()
            .ForMember(dest => dest.IdEquipo, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NombreEquipo, opt => opt.MapFrom(src => src.Nombre))
            .ReverseMap();

            CreateMap<Jugador, JugadorDto>()
            .ForMember(dest => dest.IdJugador, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DorsalJugador, opt => opt.MapFrom(src => src.Dorsal))
            .ReverseMap();
        
            CreateMap<Pais,PaisDto>()
            .ForMember(dest => dest.IdPais, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NombrePais, opt => opt.MapFrom(src => src.Nombre))
            .ReverseMap();

            CreateMap<Persona,PersonaDto>()
            .ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NombrePersona, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.EdadPersona, opt => opt.MapFrom(src => src.Edad))
            .ReverseMap();

            CreateMap<Posicion,PosicionDto>()
            .ForMember(dest => dest.IdPosicion, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NombrePosicion, opt => opt.MapFrom(src => src.Nombre))
            .ReverseMap();

            CreateMap<TipoNomina,TipoNominaDto>()
            .ForMember(dest => dest.IdTipoNomina, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NombreTipoNomina, opt => opt.MapFrom(src => src.Nombre))
            .ReverseMap();
        }
    }