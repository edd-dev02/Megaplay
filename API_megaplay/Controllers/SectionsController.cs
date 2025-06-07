using API_megaplay.Models;
using API_megaplay.Models.Dtos;
using API_megaplay.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_megaplay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public SectionsController(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        // Endpoint obtener Secciones
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetSections()
        {
            var sections = _sectionRepository.GetSections();
            var sectionsDto = new List<SectionDto>();

            foreach (var section in sections)
            {
                sectionsDto.Add(_mapper.Map<SectionDto>(section));
            }

            return Ok(sectionsDto);
        }

        // Endpoint para obtener una sección mediante el id
        [HttpGet("{id:int}", Name = "GetSection")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Sección no encontrada
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetSection(int id) // El nombre del parametro debe ser igual al reflejado en la ruta de la propiedad
        {
            var section = _sectionRepository.GetSection(id);

            if (section == null)
            {
                return NotFound($"La sección con el ID {id} no existe");
            }

            var sectionDto = _mapper.Map<SectionDto>(section);

            return Ok(sectionDto);
        }

        // Endpoint crear una nueva sección
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status201Created)] // Se creó correctamente
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Error en el servidor
        public IActionResult CreateSection([FromBody] CreateSectionDto createSectionDto)
        {
            if (createSectionDto == null)
            {
                return BadRequest(ModelState);
            }

            // Verificar que no exista la sección que se quiere crear
            if (_sectionRepository.SectionExists(createSectionDto.SectionName))
            {
                ModelState.AddModelError("CustomError", "La sección ya existe");
                return BadRequest(ModelState);
            }

            // Convertir la entidad del DTO en una entidad de dominio
            var section = _mapper.Map<Section>(createSectionDto);

            if (!_sectionRepository.CreateSection(section))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al guardar el registro {section}");
                return StatusCode(500, ModelState);
            }

            // Si todo salió bien
            return CreatedAtRoute("GetSection", new { id = section.Id }, section);
        }

        // Endpoint para actualizar una Sección
        [HttpPatch("{id:int}", Name = "UpdateSection")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Sección no encontrada
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Error en el servidor
        public IActionResult UpdateSection(int id, [FromBody] CreateSectionDto updateSectionDto)
        {
            // Verificar si existe la categoría
            if (!_sectionRepository.SectionExists(id))
            {
                return NotFound($"La sección con el ID {id} no existe");
            }

            // Verificar que no sea nulo
            if (updateSectionDto == null)
            {
                return BadRequest(ModelState);
            }

            // Convertir la entidad del DTO en una entidad de dominio
            var section = _mapper.Map<Section>(updateSectionDto);

            section.Id = id;

            if (!_sectionRepository.UpdateSection(section))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al actualizar el registro {section.SectionName}");
                return StatusCode(500, ModelState);
            }

            // Si todo salió bien
            return NoContent();
        }

        // Endpoint eliminar una sección
        [HttpDelete("{id:int}", Name = "DeleteSection")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Sección no encontrada
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Error en el servidor
        public IActionResult DeleteSection(int id)
        {
            // Verificar si existe el género
            if (!_sectionRepository.SectionExists(id))
            {
                return NotFound($"La sección con el ID {id} no existe");
            }

            var section = _sectionRepository.GetSection(id);

            // Validar que no sea nulo
            if (section == null)
            {
                return NotFound($"La sección con el ID {id} no existe");
            }

            section.Id = id;

            if (!_sectionRepository.DeleteSection(section))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al eliminar el registro {section.SectionName}");
                return StatusCode(500, ModelState);
            }

            // Si todo salió bien
            return NoContent();
        }
    }
}
