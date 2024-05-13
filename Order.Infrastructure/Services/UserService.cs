using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Application.Dtos;
using Order.Application.Interface.IServices;
using Order.Domain.Entities;
using Order.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly OrderDbContext _appDbContext;
        private readonly IMapper _mapper;
        public UserService(OrderDbContext context, IMapper mapper)
        {
            _appDbContext = context;     
            _mapper = mapper;
        }
        public Task<UserLoginDTO> ILoginUser(UserLoginDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> ILoginUserDetail(UserLoginDTO userDTO)
        {
            var user = await _appDbContext.User.FirstOrDefaultAsync(x => x.Email == userDTO.Email && x.Password== userDTO.Password);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> IRegisterUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
           await _appDbContext.User.AddAsync(user);

           await  _appDbContext.SaveChangesAsync();

            return _mapper.Map<UserDTO>(user);
        }
    }
}
