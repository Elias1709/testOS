using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Olsoftware_Aspirante_API.Datos;
using Olsoftware_Aspirante_API.Modelos;
using Olsoftware_Aspirante_API.Modelos.Dto;
using System.Net;

namespace Olsoftware_Aspirante_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspiranteController : ControllerBase
    {
        private readonly ILogger<AspiranteController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public AspiranteController(ILogger<AspiranteController> logger, ApplicationDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task <ActionResult<APIResponse>>GetAspirantes()
        {
            try
            {
                _logger.LogInformation("Obtener todos los aspirantes");

                _response.Resultado = await _db.Aspirantes.ToListAsync();
                _response.statusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("id:int", Name = "GetAspirante")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task <ActionResult<APIResponse>> GetPruebaSeleccion(int id)
        {
            try
            {
                if(id == 0)
                {
                    _logger.LogError("Error al traer al aspirante con Id " + id);
                    _response.statusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }
                var aspirante = await _db.Aspirantes.FirstOrDefaultAsync(v => v.Id == id);

                if (aspirante == null)
                {
                    _response.statusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _response.Resultado = _mapper.Map<AspiranteDto>(aspirante);
                _response.statusCode = HttpStatusCode.OK;

                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CrearAspirante([FromBody] AspiranteDto aspiranteDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (aspiranteDto == null)
                {
                    return BadRequest(aspiranteDto);
                }

                if (aspiranteDto.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                Aspirante modelo = _mapper.Map<Aspirante>(aspiranteDto);

                modelo.FechaActualizacion = DateTime.Now;

                await _db.Aspirantes.AddAsync(modelo);
                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.Created;
                await _db.SaveChangesAsync();

                return CreatedAtRoute("GetAspirante", new { id = aspiranteDto.Id }, aspiranteDto);
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteAspirante(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var aspirante = await _db.Aspirantes.FirstOrDefaultAsync(v => v.Id == id);
                if (aspirante == null)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _db.Aspirantes.Remove(aspirante);
                _response.statusCode = HttpStatusCode.NoContent;
                await _db.SaveChangesAsync();

                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return BadRequest(_response);

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateAspirante(int id, [FromBody] AspiranteDto aspiranteDto)
        {
            if (aspiranteDto == null || id != aspiranteDto.Id)
            {
                _response.IsExitoso = false;
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            Aspirante modelo = _mapper.Map<Aspirante>(aspiranteDto);

            modelo.FechaActualizacion = DateTime.Now;

            _db.Aspirantes.Update(modelo);
            _response.statusCode = HttpStatusCode.NoContent;
            await _db.SaveChangesAsync();

            return Ok(_response);
        }
    }


}
