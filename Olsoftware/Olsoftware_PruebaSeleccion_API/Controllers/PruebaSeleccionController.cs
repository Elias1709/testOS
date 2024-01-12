using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Olsoftware_PruebaSeleccion_API.Datos;
using Olsoftware_PruebaSeleccion_API.Modelos;
using Olsoftware_PruebaSeleccion_API.Modelos.Dto;
using System.Net;
using ApplicationDbContext = Olsoftware_PruebaSeleccion_API.Datos.ApplicationDbContext;

namespace Olsoftware_PruebaSeleccion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaSeleccionController : ControllerBase
    {
        private readonly ILogger <PruebaSeleccionController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public PruebaSeleccionController(ILogger<PruebaSeleccionController> logger, ApplicationDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<APIResponse>> GetPruebaSeleccion()
        {
            try
            {
                _logger.LogInformation("Obtener todas las pruebas");
                _response.Resultado = await _db.PruebaSeleccions.ToListAsync();
                _response.statusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex) 
            {
                _response.IsExitoso = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString()};
            }
            return _response;
        }

        [HttpGet("id:int", Name = "GetPruebaSeleccion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetPruebaSeleccion(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Error al traer la prueba de seleccion con Id " + id);
                    _response.statusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }

                var pruebaSeleccion = await _db.PruebaSeleccions.FirstOrDefaultAsync(v => v.Id == id);

                if (pruebaSeleccion == null)
                {
                    _response.statusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _response.Resultado = _mapper.Map<PruebaSeleccionDto>(pruebaSeleccion);
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

        public async Task <ActionResult<APIResponse>> CrearPruebaSeleccion([FromBody] PruebaSeleccionDto pruebaSeleccionDto)
        {
            try
            {
                if(!ModelState.IsValid )
                {
                    return BadRequest(ModelState);
                }

                if(pruebaSeleccionDto == null)
                {
                    return BadRequest(pruebaSeleccionDto);
                }

                if (pruebaSeleccionDto.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                PruebaSeleccion modelo = _mapper.Map<PruebaSeleccion>(pruebaSeleccionDto);

                modelo.FechaInicio = pruebaSeleccionDto.FechaInicio;
                modelo.FechaFin = pruebaSeleccionDto.FechaFin;
                
                modelo.FechaActualizacion = DateTime.Now;

                await _db.PruebaSeleccions.AddAsync(modelo);
                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.Created;
                await _db.SaveChangesAsync();

                return CreatedAtRoute("GetPruebaSeleccion", new { id = pruebaSeleccionDto.Id }, pruebaSeleccionDto);
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

        public async Task <IActionResult> DeletePruebaSeleccion(int id)
        {
            try
            {
                if (id ==0)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var pruebaSeleccion = await _db.PruebaSeleccions.FirstOrDefaultAsync(v => v.Id == id);

                if(pruebaSeleccion == null)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _db.PruebaSeleccions.Remove(pruebaSeleccion);
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

        public async Task <IActionResult> UpdatePruebaSeleccion(int id, [FromBody] PruebaSeleccionDto pruebaSeleccionDto)
        {
            if(pruebaSeleccionDto == null && id!= pruebaSeleccionDto.Id)
            {
                _response.IsExitoso = false;
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            PruebaSeleccion modelo = _mapper.Map<PruebaSeleccion>(pruebaSeleccionDto);

            modelo.FechaInicio = pruebaSeleccionDto.FechaInicio;
            modelo.FechaFin = pruebaSeleccionDto.FechaFin;

            modelo.FechaActualizacion = DateTime.Now;

            _db.PruebaSeleccions.Update(modelo);
            _response.statusCode = HttpStatusCode.NoContent;
            await _db.SaveChangesAsync();

            return Ok(_response);
        }
    }
}
