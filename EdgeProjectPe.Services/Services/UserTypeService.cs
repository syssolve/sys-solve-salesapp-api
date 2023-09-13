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
    public interface IUserTypeService {
        Task CreateUserTypeAsync(UserTypeDTO usertype);
        void UpdateUserType(UserTypeDTO usertype);
        Task DeleteUserTypeAsync(int id);
        Task<UserTypeDTO> GetByIdAsync(int id);
    }

    public class UserTypeService : IUserTypeService
    {
        private readonly IGenericRepository<Usertype> _usertypeRepository;
        private readonly IMapper _mapper;

        public UserTypeService(IGenericRepository<Usertype> UsertypeRepository, IMapper mapper) {
            _mapper=mapper;
            _usertypeRepository=UsertypeRepository;
        }
        public async Task CreateUserTypeAsync(UserTypeDTO usertype)
        {
            var usertypeObj = _mapper.Map<Usertype>(usertype);
            await _usertypeRepository.Insert(usertypeObj);
            _usertypeRepository.Save();
        }

        public async Task DeleteUserTypeAsync(int id)
        {
            var objusertype = await _usertypeRepository.GetById(id);
            if (objusertype != null)
            {
                await _usertypeRepository.Delete(objusertype);
                _usertypeRepository.Save();
            }
        }

        public async Task<UserTypeDTO> GetByIdAsync(int id)
        {
            var objuser = await _usertypeRepository.GetById(id);
            return _mapper.Map<UserTypeDTO>(objuser);
        }

        public void UpdateUserType(UserTypeDTO usertype)
        {
            var usertypeObj = _mapper.Map<Usertype>(usertype);
            _usertypeRepository.Update(usertypeObj);
            _usertypeRepository.Save();
        }
    }
}
