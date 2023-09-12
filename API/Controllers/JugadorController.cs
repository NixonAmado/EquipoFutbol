
using Api.Controllers;
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class JugadorController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _mapper {get;set;}

        public JugadorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JugadorDto>> Get(int id)
        {
            var jugador = await this._unitOfWork.Jugadores.GetByIdAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            return this._mapper.Map<JugadorDto>(jugador);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<JugadorDto>>> Get()
        {
            var jugadores = await this._unitOfWork.Jugadores.GetAllAsync();
            
            return this._mapper.Map<List<JugadorDto>>(jugadores);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Jugador>> Post(JugadorDto _jugadorDto)
        {
            var jugador = this._mapper.Map<Jugador>(_jugadorDto);
            this._unitOfWork.Jugadores.Add(jugador);
            await _unitOfWork.SaveAsync();
            if (_unitOfWork == null)
            {
                return BadRequest();
            } 
            jugador.Id = _jugadorDto.IdJugador;
            return CreatedAtAction(nameof(Post), new{id = _jugadorDto.IdJugador }, _jugadorDto);
        }                

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JugadorDto>> Put(int id,[FromBody] JugadorDto _jugadorDto ) 
        {
            if (_jugadorDto == null)
            {
                return NotFound();
            }
            var jugador = this._mapper.Map<Jugador>(_jugadorDto);
            this._unitOfWork.Jugadores.Update(jugador);
            await _unitOfWork.SaveAsync();
            return _jugadorDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var jugador = await this._unitOfWork.Jugadores.GetByIdAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }

            this._unitOfWork.Jugadores.Remove(jugador);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

}