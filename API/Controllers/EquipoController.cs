
using Api.Controllers;
using API.Dtos;
using API.Helpers.Pager;
using API.Helpers.Params;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]

    public class EquipoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _mapper {get;set;}

    public EquipoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EquipoDto>> Get(int id)
    {
        var equipo = await _unitOfWork.Equipos.GetByIdAsync(id);
        if (equipo == null)
        {
            return NotFound();
        }
        return _mapper.Map<EquipoDto>(equipo);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EquipoDto>>> Get([FromQuery] Params EquipoParams)
    {
        var equipo = await _unitOfWork.Equipos.GetAllAsync(EquipoParams.PageIndex,EquipoParams.PageSize,EquipoParams.Search);
        var lstEquiposDto = _mapper.Map<List<EquipoDto>>(equipo.registros);
        return new Pager<EquipoDto>(lstEquiposDto,equipo.totalRegistros,EquipoParams.PageIndex,EquipoParams.PageSize,EquipoParams.Search);
    }

    [HttpGet]
    [ApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EquipoDto>>> Get11()
    {
        var equipo = await _unitOfWork.Equipos.GetAllAsync();
        return Ok(equipo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EquipoFullDto>> Post(EquipoFullDto _equipoFullDto)
    {
        var equipo = _mapper.Map<Equipo>(_equipoFullDto);
        this._unitOfWork.Equipos.Add(equipo);
        await _unitOfWork.SaveAsync();
        if (_unitOfWork == null)
        {
            return BadRequest();            
        }
        equipo.Id = _equipoFullDto.Id;
        return CreatedAtAction(nameof(Post), new {id = _equipoFullDto.Id}, _equipoFullDto );
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EquipoDto>> Put(int id, [FromBody] EquipoDto _equipoDto)
    {
        if (_equipoDto == null)
        {
            return NotFound();            
        }

        var equipo = this._mapper.Map<Equipo>(_equipoDto);
        this._unitOfWork.Equipos.Update(equipo);
        await _unitOfWork.SaveAsync();
        return _equipoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var equipo = await _unitOfWork.Equipos.GetByIdAsync(id);
        if (equipo == null)
        {
            return NotFound();
        }
        _unitOfWork.Equipos.Remove(equipo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    
    }

    }