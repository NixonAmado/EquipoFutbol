
using Api.Controllers;
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    public class TipoNominaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _mapper {get;set;}

    public TipoNominaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoNominaDto>> Get(int id)
    {
        var tipoNomina = await _unitOfWork.TipoNominas.GetByIdAsync(id);
        if (tipoNomina == null)
        {
            return NotFound();
        }
        return _mapper.Map<TipoNominaDto>(tipoNomina);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoNominaDto>>> Get()
    {
        var tipoNomina = await _unitOfWork.TipoNominas.GetAllAsync();
        return _mapper.Map<List<TipoNominaDto>>(tipoNomina);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoNominaDto>> Post(TipoNominaDto _tipoNominaDto)
    {
        var tipoNomina = _mapper.Map<TipoNomina>(_tipoNominaDto);
        this._unitOfWork.TipoNominas.Add(tipoNomina);
        await _unitOfWork.SaveAsync();
        if (_unitOfWork == null)
        {
            return BadRequest();            
        }
        tipoNomina.Id = _tipoNominaDto.IdTipoNomina;
        return CreatedAtAction(nameof(Post), new {id = _tipoNominaDto.IdTipoNomina}, _tipoNominaDto );
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoNominaDto>> Put(int id, [FromBody] TipoNominaDto _tipoNominaDto)
    {
        if (_tipoNominaDto == null)
        {
            return NotFound();            
        }

        var tipoNomina = this._mapper.Map<TipoNomina>(_tipoNominaDto);
        this._unitOfWork.TipoNominas.Update(tipoNomina);
        await _unitOfWork.SaveAsync();
        return _tipoNominaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var tipoNomina = await _unitOfWork.TipoNominas.GetByIdAsync(id);
        if (tipoNomina == null)
        {
            return NotFound();
        }
        _unitOfWork.TipoNominas.Remove(tipoNomina);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    }