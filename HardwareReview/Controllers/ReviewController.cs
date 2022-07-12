using AutoMapper;
using HardwareReview.Dto;
using HardwareReview.Models;
using HardwareReview.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HardwareReview.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController: Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int Id)
        {
            if (!_reviewRepository.ReviewExists(Id))
                return NotFound();

            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReviewById(Id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(review);
        }

        [HttpGet("hardware/{hardwareId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsofHardware(int hardwareId)
        {

            var reviews = _mapper.Map<ReviewDto>(_reviewRepository.GetReviewsOfHardware(hardwareId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

    }
}
