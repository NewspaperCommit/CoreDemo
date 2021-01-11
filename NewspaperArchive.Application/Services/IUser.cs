using NewspaperArchive.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewspaperArchive.Application.Common.Dtos;
using NewspaperArchive.Application.Common.Dtos.User;

namespace NewspaperArchive.Application.Services
{
    public interface IUser
    {
        Task<IEnumerable<Users>> GetAccountList();
        Task<int> Login(LoginDTO model);

        Task<int> AddUser(Users model);
        Task<CheckUserExistDto> CheckUserExist(Users users);

    }
}
