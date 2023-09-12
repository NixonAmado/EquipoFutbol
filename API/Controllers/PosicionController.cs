
using Api.Controllers;
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    public class PosicionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _mapper {get;set;}

    public PosicionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PosicionDto>> Get(int id)
    {
        var posicion = await _unitOfWork.Posiciones.GetByIdAsync(id);
        if (posicion == null)
        {
            return NotFound();
        }
        return _mapper.Map<PosicionDto>(posicion);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PosicionDto>>> Get()
    {
        var posicion = await _unitOfWork.Posiciones.GetAllAsync();
        return _mapper.Map<List<PosicionDto>>(posicion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PosicionDto>> Post(PosicionDto _posicionDto)
    {
        var posicion = _mapper.Map<Posicion>(_posicionDto);
        this._unitOfWork.Posiciones.Add(posicion);
        await _unitOfWork.SaveAsync();
        if (_unitOfWork == null)
        {
            return BadRequest();            
        }
        posicion.Id = _posicionDto.IdPosicion;
        return CreatedAtAction(nameof(Post), new {id = _posicionDto.IdPosicion}, _posicionDto );
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PosicionDto>> Put(int id, [FromBody] PosicionDto _posicionDto)
    {
        if (_posicionDto == null)
        {
            return NotFound();            
        }

        var posicion = this._mapper.Map<Posicion>(_posicionDto);
        this._unitOfWork.Posiciones.Update(posicion);
        await _unitOfWork.SaveAsync();
        return _posicionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var posicion = await _unitOfWork.Posiciones.GetByIdAsync(id);
        if (posicion == null)
        {
            return NotFound();
        }
        _unitOfWork.Posiciones.Remove(posicion);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    }