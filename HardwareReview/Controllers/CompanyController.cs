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
        private readonly CompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(CompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
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

    }
}
