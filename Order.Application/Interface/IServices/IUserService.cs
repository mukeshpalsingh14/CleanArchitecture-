using Order.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Interface.IServices
{
    public interface IUserService
    {
        //iRegisterUser

        Task<UserDTO> IRegisterUser(UserDTO userDTO);
        Task<UserLoginDTO> ILoginUser(UserLoginDTO userDTO);

        Task<UserDTO> ILoginUserDetail(UserLoginDTO userDTO);


    }
}
