using AutoMapper;
using EdgeProjectPe.DB.Entities;
using EdgeProjectPe.DB.Repositories.Generic;
using EdgeProjectPe.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EdgeProjectPe.Services.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(UserDTO user);
        void UpdateUser(UserDTO user);
        Task DeleteUserAsync(int id);
        Task<UserDTO> GetByIdAsync(int id);
        UserDTO LoginUser(UserDTO user);

    }

    public class UserService:IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> userRepository,IMapper mapper)
        {
            _userRepository = userRepository; 
            _mapper=mapper;
        }
        public async Task CreateUserAsync(UserDTO user)
        {
            var userObj = _mapper.Map<User>(user);
            await _userRepository.Insert(userObj);
        }
        public void UpdateUser(UserDTO user)
        {
            var userObj = _mapper.Map<User>(user);
            _userRepository.Update(userObj);
        }
        public async Task DeleteUserAsync(int id)
        {
            var objUser = await _userRepository.GetById(id);
            if (objUser != null)
            {
                await _userRepository.Delete(objUser);
            }
        }
        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var objUser =  await _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(objUser);
        }

        public UserDTO LoginUser(UserDTO user)
        {
            var result = _userRepository.GetAll().FirstOrDefault(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password));
            if(result == null)
            {
                return null;
            }

            return _mapper.Map<UserDTO>(result);

        }
    }
}
