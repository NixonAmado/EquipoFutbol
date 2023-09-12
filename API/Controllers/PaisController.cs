
using Api.Controllers;
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    public class PaisController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _mapper {get;set;}

    public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaisDto>> Get(int id)
    {
        var pais = await _unitOfWork.Paises.GetByIdAsync(id);
        if (pais == null)
        {
            return NotFound();
        }
        return _mapper.Map<PaisDto>(pais);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
    {
        var pais = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<PaisDto>>(pais);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaisDto>> Post(PaisDto _PaisDto)
    {
        var pais = _mapper.Map<Pais>(_PaisDto);
        this._unitOfWork.Paises.Add(pais);
        await _unitOfWork.SaveAsync();
        if (_unitOfWork == null)
        {
            return BadRequest();            
        }
        pais.Id = _PaisDto.IdPais;
        return CreatedAtAction(nameof(Post), new {id = _PaisDto.IdPais}, _PaisDto );
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Put(int id, [FromBody] PaisDto _PaisDto)
    {
        if (_PaisDto == null)
        {
            return NotFound();            
        }

        var pais = this._mapper.Map<Pais>(_PaisDto);
        this._unitOfWork.Paises.Update(pais);
        await _unitOfWork.SaveAsync();
        return _PaisDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var pais = await _unitOfWork.Paises.GetByIdAsync(id);
        if (pais == null)
        {
            return NotFound();
        }
        _unitOfWork.Paises.Remove(pais);
        await _unitOfWork.SaveAsync();
        return NoContent();
    
    }

    }