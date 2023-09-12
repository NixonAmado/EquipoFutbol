
using Api.Controllers;
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    public class PersonaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _mapper {get;set;}

    public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> Get(int id)
    {
        var persona = await _unitOfWork.Personas.GetByIdAsync(id);
        if (persona == null)
        {
            return NotFound();
        }
        return _mapper.Map<PersonaDto>(persona);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
    {
        var persona = await _unitOfWork.Personas.GetAllAsync();
        return _mapper.Map<List<PersonaDto>>(persona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> Post(PersonaDto _personaDto)
    {
        var persona = _mapper.Map<Persona>(_personaDto);
        this._unitOfWork.Personas.Add(persona);
        await _unitOfWork.SaveAsync();
        if (_unitOfWork == null)
        {
            return BadRequest();            
        }
        persona.Id = _personaDto.IdPersona;
        return CreatedAtAction(nameof(Post), new {id = _personaDto.IdPersona}, _personaDto );
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto _personaDto)
    {
        if (_personaDto == null)
        {
            return NotFound();            
        }

        var persona = this._mapper.Map<Persona>(_personaDto);
        this._unitOfWork.Personas.Update(persona);
        await _unitOfWork.SaveAsync();
        return _personaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var persona = await _unitOfWork.Personas.GetByIdAsync(id);
        if (persona == null)
        {
            return NotFound();
        }
        _unitOfWork.Personas.Remove(persona);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    }