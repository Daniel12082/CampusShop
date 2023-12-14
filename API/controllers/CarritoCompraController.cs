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
    public class CarritoCompraController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarritoCompraController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CarritoCompraDto>>> Get11()
        {
            var CarritoCompras = await _unitOfWork.CarritoCompras.GetAllAsync();
            return _mapper.Map<List<CarritoCompraDto>>(CarritoCompras);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CarritoCompraDto>> Get(int id)
        {
            var CarritoCompra = await _unitOfWork.CarritoCompras.GetByIdAsync(id);
            if (CarritoCompra == null)
                return NotFound(new ApiResponse(404, $"El CarritoCompra solicitado no existe."));

            return _mapper.Map<CarritoCompraDto>(CarritoCompra);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarritoCompra>> Post(CarritoCompraDto CarritoCompraDto)
        {
            var CarritoCompra = _mapper.Map<CarritoCompra>(CarritoCompraDto);
            _unitOfWork.CarritoCompras.Add(CarritoCompra);
            await _unitOfWork.SaveAsync();
            if (CarritoCompra == null)
                return BadRequest(new ApiResponse(400));

            CarritoCompraDto.Id = CarritoCompra.Id;
            return CreatedAtAction(nameof(Post), new { id = CarritoCompraDto.Id }, CarritoCompraDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarritoCompraDto>> Put(int id, [FromBody] CarritoCompraDto CarritoCompraDto)
        {
            if (CarritoCompraDto == null)
                return NotFound(new ApiResponse(404, $"El CarritoCompra solicitado no existe."));

            var CarritoCompraBd = await _unitOfWork.CarritoCompras.GetByIdAsync(id);
            if (CarritoCompraBd == null)
                return NotFound(new ApiResponse(404, $"El CarritoCompra solicitado no existe."));

            var CarritoCompra = _mapper.Map<CarritoCompra>(CarritoCompraDto);
            _unitOfWork.CarritoCompras.Update(CarritoCompra);
            await _unitOfWork.SaveAsync();
            return CarritoCompraDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var CarritoCompra = await _unitOfWork.CarritoCompras.GetByIdAsync(id);
            if (CarritoCompra == null)
                return NotFound(new ApiResponse(404, $"El CarritoCompra solicitado no existe."));

            _unitOfWork.CarritoCompras.Remove(CarritoCompra);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}