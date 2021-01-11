using NewspaperArchive.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperArchive.Application.Services
{
    public interface IService
    {
        Task<UserModel> GetUserInfo(int model);
    }
}
