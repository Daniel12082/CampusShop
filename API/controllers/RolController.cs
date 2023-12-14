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
    public class RolController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RolDto>>> Get11()
        {
            var Roles = await _unitOfWork.Roles.GetAllAsync();
            return _mapper.Map<List<RolDto>>(Roles);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolDto>> Get(int id)
        {
            var Rol = await _unitOfWork.Roles.GetByIdAsync(id);
            if (Rol == null)
                return NotFound(new ApiResponse(404, $"El Rol solicitado no existe."));

            return _mapper.Map<RolDto>(Rol);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Rol>> Post(RolDto RolDto)
        {
            var Rol = _mapper.Map<Rol>(RolDto);
            _unitOfWork.Roles.Add(Rol);
            await _unitOfWork.SaveAsync();
            if (Rol == null)
                return BadRequest(new ApiResponse(400));

            RolDto.Id = Rol.Id;
            return CreatedAtAction(nameof(Post), new { id = RolDto.Id }, RolDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolDto>> Put(int id, [FromBody] RolDto RolDto)
        {
            if (RolDto == null)
                return NotFound(new ApiResponse(404, $"El Rol solicitado no existe."));

            var RolBd = await _unitOfWork.Roles.GetByIdAsync(id);
            if (RolBd == null)
                return NotFound(new ApiResponse(404, $"El Rol solicitado no existe."));

            var Rol = _mapper.Map<Rol>(RolDto);
            _unitOfWork.Roles.Update(Rol);
            await _unitOfWork.SaveAsync();
            return RolDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Rol = await _unitOfWork.Roles.GetByIdAsync(id);
            if (Rol == null)
                return NotFound(new ApiResponse(404, $"El Rol solicitado no existe."));

            _unitOfWork.Roles.Remove(Rol);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}