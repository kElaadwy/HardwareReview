using AutoMapper;
using HardwareReview.Dto;
using HardwareReview.Models;
using HardwareReview.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HardwareReview.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Company>))]
        public IActionResult GetCompanies()
        {
            var companies = _mapper.Map<List<CompanyDto>>(_companyRepository.GetCompanies());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(companies);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Company))]
        [ProducesResponseType(400)]
        public IActionResult GetCompany(int Id)
        {
            if (!_companyRepository.CompanyExists(Id))
                return NotFound();

            var company = _mapper.Map<CompanyDto>(_companyRepository.GetCompanyById(Id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(company);
        }

        [HttpGet("{companyId}/hardware")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Company>))]
        [ProducesResponseType(400)]
        public IActionResult GetHardwaresOfCompany(int companyId)
        {
            if (!_companyRepository.CompanyExists(companyId))
                return NotFound();

            var hardwares = _mapper.Map<CompanyDto>(_companyRepository.GetHardwaresOfCompany(companyId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(hardwares);
        }

        [HttpGet("{hardwareId}/company")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hardware>))]
        [ProducesResponseType(400)]
        public IActionResult GetCompaniesOfHardware(int hardwareId)
        {
            if (!_companyRepository.CompanyExists(hardwareId))
                return NotFound();

            var companies = _mapper.Map < CompanyDto > (_companyRepository.GetCompaniesOfHardware(hardwareId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(companies);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCompany([FromQuery] int countryId, [FromBody] CompanyDto companyCreate)
        {
            if (companyCreate == null)
                return BadRequest(ModelState);

            var company = _companyRepository.GetCompanies().Where(c => c.Name.Trim().ToUpper() ==
            companyCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (company is not null)
            {
                ModelState.AddModelError("", "Company already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var companyMap = _mapper.Map<Company>(companyCreate);
            companyMap.Country = _countryRepository.GetCountryById(countryId);

            if (!_companyRepository.CreateCompany(companyMap))
            {
                ModelState.AddModelError("", "Somthing went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully created");
        }

        [HttpPut("{companyId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCompany(int companyId, [FromBody] CompanyDto updateCompany)
        {
            if (updateCompany == null)
                return BadRequest(ModelState);

            if (companyId != updateCompany.Id)
                return BadRequest(ModelState);

            if (!_companyRepository.CompanyExists(companyId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var companyMap = _mapper.Map<Company>(updateCompany);

            if (!_companyRepository.UpdateCompany(companyMap))
            {
                ModelState.AddModelError("", "Somthing went wrong while Updating");
                return StatusCode(500, ModelState);
            }

            return Ok("Udated successfully");
        }

    }
}
