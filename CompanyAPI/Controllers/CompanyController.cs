using AutoMapper;
using CompanyAPI.Data;
using CompanyAPI.Dtos;
using CompanyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyAPIRepo _repository;

        private readonly IMapper _mapper;

        public CompanyController(ICompanyAPIRepo repository, IMapper mapper )
        {
            _repository = repository;

            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyCreatedDtoI companyCreatedDtoI)
        {
            var companyModel = _mapper.Map<Company>(companyCreatedDtoI);
            
            await _repository.CreateCompany(companyModel);

            await _repository.SaveChangesAsync();
            var commandReadDto = _mapper.Map<CompanyReadDto>(companyModel);

            return Created("",companyModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanys()
        {
            var companys = await  _repository.GetAllCompanys();

            return Ok(_mapper.Map<IEnumerable<CompanyReadDto>>(companys));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _repository.GetCompanyById(id);
            if(company == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CompanyReadDto>(company));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanys(int id)
        {
            var companyModelRepo = await _repository.GetCompanyById(id);
            if (companyModelRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCompany(companyModelRepo);

            await _repository.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanys(int id, CompanyUpdateDto updateDto)
        {
            var companyModelRepo = await _repository.GetCompanyById(id);
            
            if (companyModelRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(updateDto, companyModelRepo);

            _repository.UpdateCompany(companyModelRepo);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

    }
}
