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
    public class CategoriaProductoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaProductoDto>>> Get11()
        {
            var CategoriaProductos = await _unitOfWork.CategoriaProductos.GetAllAsync();
            return _mapper.Map<List<CategoriaProductoDto>>(CategoriaProductos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaProductoDto>> Get(int id)
        {
            var CategoriaProducto = await _unitOfWork.CategoriaProductos.GetByIdAsync(id);
            if (CategoriaProducto == null)
                return NotFound(new ApiResponse(404, $"El CategoriaProducto solicitado no existe."));

            return _mapper.Map<CategoriaProductoDto>(CategoriaProducto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaProducto>> Post(CategoriaProductoDto CategoriaProductoDto)
        {
            var CategoriaProducto = _mapper.Map<CategoriaProducto>(CategoriaProductoDto);
            _unitOfWork.CategoriaProductos.Add(CategoriaProducto);
            await _unitOfWork.SaveAsync();
            if (CategoriaProducto == null)
                return BadRequest(new ApiResponse(400));

            CategoriaProductoDto.Id = CategoriaProducto.Id;
            return CreatedAtAction(nameof(Post), new { id = CategoriaProductoDto.Id }, CategoriaProductoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaProductoDto>> Put(int id, [FromBody] CategoriaProductoDto CategoriaProductoDto)
        {
            if (CategoriaProductoDto == null)
                return NotFound(new ApiResponse(404, $"El CategoriaProducto solicitado no existe."));

            var CategoriaProductoBd = await _unitOfWork.CategoriaProductos.GetByIdAsync(id);
            if (CategoriaProductoBd == null)
                return NotFound(new ApiResponse(404, $"El CategoriaProducto solicitado no existe."));

            var CategoriaProducto = _mapper.Map<CategoriaProducto>(CategoriaProductoDto);
            _unitOfWork.CategoriaProductos.Update(CategoriaProducto);
            await _unitOfWork.SaveAsync();
            return CategoriaProductoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var CategoriaProducto = await _unitOfWork.CategoriaProductos.GetByIdAsync(id);
            if (CategoriaProducto == null)
                return NotFound(new ApiResponse(404, $"El CategoriaProducto solicitado no existe."));

            _unitOfWork.CategoriaProductos.Remove(CategoriaProducto);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}