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
    public interface IUnitService
    {
        Task CreateUnitAsync(UnitDTO unit);
        void UpdateUnit(UnitDTO unit);
        Task DeleteUnitAsync(int id);
        Task<UnitDTO> GetByIdAsync(int id);
    }
    public class UnitService : IUnitService
    {
        private readonly IGenericRepository<Unit> _unitRepository;
        private readonly IMapper _mapper;

        public UnitService(IGenericRepository<Unit> unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper=mapper;
        }

        public async Task CreateUnitAsync(UnitDTO unit)
        {
            var unitObj = _mapper.Map<Unit>(unit);
            await _unitRepository.Insert(unitObj);
            _unitRepository.Save();
        }

        public async Task DeleteUnitAsync(int id)
        {
            var unitObj = await _unitRepository.GetById(id);
            if (unitObj != null)
            {
                await _unitRepository.Delete(unitObj);
                _unitRepository.Save();
            }
        }

        public async Task<UnitDTO> GetByIdAsync(int id)
        {
            var objunit = await _unitRepository.GetById(id);
            return _mapper.Map<UnitDTO>(objunit);
        }

        public void UpdateUnit(UnitDTO unit)
        {
            var unitObj = _mapper.Map<Unit>(unit);
            _unitRepository.Update(unitObj);
            _unitRepository.Save();
        }
    }
}
