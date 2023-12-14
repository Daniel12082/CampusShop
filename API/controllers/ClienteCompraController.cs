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
    public class ClienteCompraController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteCompraController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteCompraDto>>> Get11()
        {
            var ClienteCompras = await _unitOfWork.ClienteCompras.GetAllAsync();
            return _mapper.Map<List<ClienteCompraDto>>(ClienteCompras);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteCompraDto>> Get(int id)
        {
            var ClienteCompra = await _unitOfWork.ClienteCompras.GetByIdAsync(id);
            if (ClienteCompra == null)
                return NotFound(new ApiResponse(404, $"El ClienteCompra solicitado no existe."));

            return _mapper.Map<ClienteCompraDto>(ClienteCompra);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteCompra>> Post(ClienteCompraDto ClienteCompraDto)
        {
            var ClienteCompra = _mapper.Map<ClienteCompra>(ClienteCompraDto);
            _unitOfWork.ClienteCompras.Add(ClienteCompra);
            await _unitOfWork.SaveAsync();
            if (ClienteCompra == null)
                return BadRequest(new ApiResponse(400));

            ClienteCompraDto.Id = ClienteCompra.Id;
            return CreatedAtAction(nameof(Post), new { id = ClienteCompraDto.Id }, ClienteCompraDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteCompraDto>> Put(int id, [FromBody] ClienteCompraDto ClienteCompraDto)
        {
            if (ClienteCompraDto == null)
                return NotFound(new ApiResponse(404, $"El ClienteCompra solicitado no existe."));

            var ClienteCompraBd = await _unitOfWork.ClienteCompras.GetByIdAsync(id);
            if (ClienteCompraBd == null)
                return NotFound(new ApiResponse(404, $"El ClienteCompra solicitado no existe."));

            var ClienteCompra = _mapper.Map<ClienteCompra>(ClienteCompraDto);
            _unitOfWork.ClienteCompras.Update(ClienteCompra);
            await _unitOfWork.SaveAsync();
            return ClienteCompraDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var ClienteCompra = await _unitOfWork.ClienteCompras.GetByIdAsync(id);
            if (ClienteCompra == null)
                return NotFound(new ApiResponse(404, $"El ClienteCompra solicitado no existe."));

            _unitOfWork.ClienteCompras.Remove(ClienteCompra);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}