using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class PagoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PagoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PagoDto>>> Get11()
        {
            var Pagos = await _unitOfWork.Pagos.GetAllAsync();
            return _mapper.Map<List<PagoDto>>(Pagos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagoDto>> Get(int id)
        {
            var Pago = await _unitOfWork.Pagos.GetByIdAsync(id);
            if (Pago == null)
                return NotFound(new ApiResponse(404, $"El Pago solicitado no existe."));

            return _mapper.Map<PagoDto>(Pago);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pago>> Post(PagoDto PagoDto)
        {
            var Pago = _mapper.Map<Pago>(PagoDto);
            _unitOfWork.Pagos.Add(Pago);
            await _unitOfWork.SaveAsync();
            if (Pago == null)
                return BadRequest(new ApiResponse(400));

            PagoDto.Id = Pago.Id;
            return CreatedAtAction(nameof(Post), new { id = PagoDto.Id }, PagoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagoDto>> Put(int id, [FromBody] PagoDto PagoDto)
        {
            if (PagoDto == null)
                return NotFound(new ApiResponse(404, $"El Pago solicitado no existe."));

            var PagoBd = await _unitOfWork.Pagos.GetByIdAsync(id);
            if (PagoBd == null)
                return NotFound(new ApiResponse(404, $"El Pago solicitado no existe."));

            var Pago = _mapper.Map<Pago>(PagoDto);
            _unitOfWork.Pagos.Update(Pago);
            await _unitOfWork.SaveAsync();
            return PagoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var Pago = await _unitOfWork.Pagos.GetByIdAsync(id);
            if (Pago == null)
                return NotFound(new ApiResponse(404, $"El Pago solicitado no existe."));

            _unitOfWork.Pagos.Remove(Pago);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}