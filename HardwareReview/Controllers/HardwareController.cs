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

    }
}
