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
    public class DetalleProductoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleProductoDto>>> Get11()
        {
            var DetalleProductos = await _unitOfWork.DetalleProductos.GetAllAsync();
            return _mapper.Map<List<DetalleProductoDto>>(DetalleProductos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleProductoDto>> Get(int id)
        {
            var DetalleProducto = await _unitOfWork.DetalleProductos.GetByIdAsync(id);
            if (DetalleProducto == null)
                return NotFound(new ApiResponse(404, $"El DetalleProducto solicitado no existe."));

            return _mapper.Map<DetalleProductoDto>(DetalleProducto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleProducto>> Post(DetalleProductoDto DetalleProductoDto)
        {
            var DetalleProducto = _mapper.Map<DetalleProducto>(DetalleProductoDto);
            _unitOfWork.DetalleProductos.Add(DetalleProducto);
            await _unitOfWork.SaveAsync();
            if (DetalleProducto == null)
                return BadRequest(new ApiResponse(400));

            DetalleProductoDto.Id = DetalleProducto.Id;
            return CreatedAtAction(nameof(Post), new { id = DetalleProductoDto.Id }, DetalleProductoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleProductoDto>> Put(int id, [FromBody] DetalleProductoDto DetalleProductoDto)
        {
            if (DetalleProductoDto == null)
                return NotFound(new ApiResponse(404, $"El DetalleProducto solicitado no existe."));

            var DetalleProductoBd = await _unitOfWork.DetalleProductos.GetByIdAsync(id);
            if (DetalleProductoBd == null)
                return NotFound(new ApiResponse(404, $"El DetalleProducto solicitado no existe."));

            var DetalleProducto = _mapper.Map<DetalleProducto>(DetalleProductoDto);
            _unitOfWork.DetalleProductos.Update(DetalleProducto);
            await _unitOfWork.SaveAsync();
            return DetalleProductoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var DetalleProducto = await _unitOfWork.DetalleProductos.GetByIdAsync(id);
            if (DetalleProducto == null)
                return NotFound(new ApiResponse(404, $"El DetalleProducto solicitado no existe."));

            _unitOfWork.DetalleProductos.Remove(DetalleProducto);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}