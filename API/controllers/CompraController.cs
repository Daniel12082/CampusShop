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
    public class CompraController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompraController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CompraDto>>> Get11()
        {
            var Compras = await _unitOfWork.Compras.GetAllAsync();
            return _mapper.Map<List<CompraDto>>(Compras);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CompraDto>> Get(int id)
        {
            var Compra = await _unitOfWork.Compras.GetByIdAsync(id);
            if (Compra == null)
                return NotFound(new ApiResponse(404, $"El Compra solicitado no existe."));

            return _mapper.Map<CompraDto>(Compra);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Compra>> Post(CompraDto CompraDto)
        {
            var Compra = _mapper.Map<Compra>(CompraDto);
            _unitOfWork.Compras.Add(Compra);
            await _unitOfWork.SaveAsync();
            if (Compra == null)
                return BadRequest(new ApiResponse(400));

            CompraDto.Id = Compra.Id;
            return CreatedAtAction(nameof(Post), new { id = CompraDto.Id }, CompraDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CompraDto>> Put(int id, [FromBody] CompraDto CompraDto)
        {
            if (CompraDto == null)
                return NotFound(new ApiResponse(404, $"El Compra solicitado no existe."));

            var CompraBd = await _unitOfWork.Compras.GetByIdAsync(id);
            if (CompraBd == null)
                return NotFound(new ApiResponse(404, $"El Compra solicitado no existe."));

            var Compra = _mapper.Map<Compra>(CompraDto);
            _unitOfWork.Compras.Update(Compra);
            await _unitOfWork.SaveAsync();
            return CompraDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Compra = await _unitOfWork.Compras.GetByIdAsync(id);
            if (Compra == null)
                return NotFound(new ApiResponse(404, $"El Compra solicitado no existe."));

            _unitOfWork.Compras.Remove(Compra);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}