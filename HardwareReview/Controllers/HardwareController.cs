using AutoMapper;
using HardwareReview.Dto;
using HardwareReview.Models;
using HardwareReview.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HardwareReview.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HardwareController : Controller
    {
        private readonly IHardwareRepository _hardwareRepository;
        private readonly IMapper _mapper;

        public HardwareController(IHardwareRepository hardwareRepository, IMapper mapper)
        {
            _hardwareRepository = hardwareRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hardware>))]
        public IActionResult GetHardawres()
        {
            var hardware = _mapper.Map<List<HardwareDto>>(_hardwareRepository.GetHardwares());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(hardware);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Hardware))]
        [ProducesResponseType(400)]
        public IActionResult GetHardware(int Id)
        {
            if (!_hardwareRepository.HardwareExists(Id))
                return NotFound();

            var hardware = _mapper.Map<HardwareDto>(_hardwareRepository.GetHardwareById(Id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(hardware);
        }

        [HttpGet("{Id}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetHardwareRating(int Id)
        {
            if (!_hardwareRepository.HardwareExists(Id))
                return NotFound();

            var rating = _hardwareRepository.GetHardwareRating(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateHardware([FromQuery] int companyId, [FromQuery] int categoryId, [FromBody] HardwareDto hardwareCreate)
        {
            if (hardwareCreate == null)
                return BadRequest(ModelState);

            var hardware = _hardwareRepository.GetHardwares().Where(c => c.Name.Trim().ToUpper() ==
            hardwareCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (hardware is not null)
            {
                ModelState.AddModelError("", "Hardware already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hardwareMap = _mapper.Map<Hardware>(hardwareCreate);

            if (!_hardwareRepository.CreateHardware(companyId, categoryId, hardwareMap))
            {
                ModelState.AddModelError("", "Somthing went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully created");
        }


    }
}
