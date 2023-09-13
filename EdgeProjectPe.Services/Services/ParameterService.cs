using AutoMapper;
using EdgeProjectPe.DB.Entities;
using EdgeProjectPe.DB.Repositories.Generic;
using EdgeProjectPe.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EdgeProjectPe.Services.Services
{
    public interface IParameterService
    {
        Task CreateParameterAsync(ParameterDTO parameter);
        void UpdateParameter(ParameterDTO parameter);
        Task DeleteParameterAsync(int id);
        Task<ParameterDTO> GetByIdAsync(int id);
    }
    public class ParameterService : IParameterService
    {
        private readonly IGenericRepository<Parameter> _paramRepository;
        private readonly IMapper _mapper;

        public ParameterService(IGenericRepository<Parameter> paramRepository, IMapper mapper)
        {

            _paramRepository = paramRepository;
            _mapper=mapper;
        }

        public async Task CreateParameterAsync(ParameterDTO parameter)
        {
            var paramObj = _mapper.Map<Parameter>(parameter);
            await _paramRepository.Insert(paramObj);
            _paramRepository.Save();
        }

        public async Task DeleteParameterAsync(int id)
        {
            var objParameter = await _paramRepository.GetById(id);
            if (objParameter != null)
            {
                await _paramRepository.Delete(objParameter);
                _paramRepository.Save();
            }
        }

        public async Task<ParameterDTO> GetByIdAsync(int id)
        {
            var objParameter = await _paramRepository.GetById(id);
            return _mapper.Map<ParameterDTO>(objParameter);
        }

        public void UpdateParameter(ParameterDTO invoice)
        {
            var companyObj = _mapper.Map<Parameter>(invoice);
            _paramRepository.Update(companyObj);
            _paramRepository.Save();
        }
    }
}
