using AutoMapper;
using EdgeProjectPe.DB.Entities;
using EdgeProjectPe.DB.Repositories.Generic;
using EdgeProjectPe.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeProjectPe.Services.Services
{
    public interface ICompanyService {

        Task CreateCompanyAsync(CompanyDTO company);
        void UpdateCompany(CompanyDTO company);
        Task DeleteCompanyAsync(int id);
        Task<CompanyDTO> GetByIdAsync(int id);

    }
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(IGenericRepository<Company> companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper=mapper;
        }
        public async Task CreateCompanyAsync(CompanyDTO company)
        {
            var companyObj = _mapper.Map<Company>(company);
            await _companyRepository.Insert(companyObj);
            _companyRepository.Save();
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var objCompany = await _companyRepository.GetById(id);
            if (objCompany != null)
            {
                await _companyRepository.Delete(objCompany);
                _companyRepository.Save();
            }
        }

        public async Task<CompanyDTO> GetByIdAsync(int id)
        {
            var objCompany = await _companyRepository.GetById(id);
            return _mapper.Map<CompanyDTO>(objCompany);
        }

        public void UpdateCompany(CompanyDTO company)
        {           
            var companyObj = _mapper.Map<Company>(company);
            _companyRepository.Update(companyObj);
            _companyRepository.Save();           

        }
    }
}
