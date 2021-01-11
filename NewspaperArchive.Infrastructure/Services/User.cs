using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Application.Model;
using NewspaperArchive.Application.Services;
using NewspaperArchive.Infrastructure.Persistence.Contexts;
using NewspaperArchive.Application.Common.Dtos;
using NewspaperArchive.Application.Common.Dtos.User;

namespace NewspaperArchive.Infrastructure.Services
{
    public class User : IUser
    {
        private readonly DemoDbContext context;
        public User(DemoDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddUser(Users model)
        {
            int retunId=0;
                SqlParameter FirstNameParam = new SqlParameter("@FirstName", model.FirstName);
                SqlParameter EmailAddressParam = new SqlParameter("@EmailAddress", model.EmailAddress);
                SqlParameter PasswordParam = new SqlParameter("@Password", model.Password);

           
            dynamic result = context.StatusValue.FromSqlRaw("exec [dbo].[Sp_AddUsers] @FirstName, @EmailAddress, @Password", FirstNameParam,
                 EmailAddressParam, PasswordParam);
            //retunId = result;

            // return await Task.FromResult(res;
            foreach (var k in result)
            {
                retunId = k.Id;

            }
            //Users obj = new Users();
            return await Task.FromResult<int>(retunId);
        }

        //public async Task<IEnumerable<User>> GetAccountList()
        //{
        //    IEnumerable<User> lst = await context.User.ToListAsync();
        //    //return await List<Task.FromResult<UserModel>>(lst);
        //    return lst;
        //}

        public async Task<IEnumerable<Users>> GetAccountList()
        {
            IEnumerable<Users> lst = await context.User.ToListAsync();
            return lst;
        }

        public async Task<int> Login(LoginDTO model)
        {
            SqlParameter userNameParam = new SqlParameter("@UserId", model.UserName);
            SqlParameter passwordParam = new SqlParameter("@VenueId", model.Password);

            dynamic result = context.Event.FromSqlRaw("exec [dbo].[Sp_UserLogin] @UserId, @VenueId", userNameParam,
                passwordParam);
            //var result = context.Login.FromSqlRaw("exec [dbo].[Sp_UserLogin]");
            return await Task.FromResult<int>(result);
        }
        public async Task<CheckUserExistDto> CheckUserExist(Users user)
        {
            CheckUserExistDto lst = new CheckUserExistDto();
            string userName = user.EmailAddress;
            string passowrd = user.Password;
            try
            {
                // Settings.  
                SqlParameter usernameParam = new SqlParameter("@UserName", userName.ToString() ?? (object)DBNull.Value);
                SqlParameter passwordParam = new SqlParameter("@UserPassword", passowrd.ToString() ?? (object)DBNull.Value);
                var lst1 = context
                .CheckUserExist
                .FromSqlRaw("exec [dbo].[Sp_CheckUserExist] @UserName, @UserPassword", usernameParam, passwordParam);

                foreach (var k in lst1)
                {
                    lst.Firstname = k.Firstname;
                    lst.Userid = k.Userid;
                    lst.Status = k.Status;

                }
            }
            catch (Exception ex)
            {
                lst.Status = "Error";
                throw ex;
            }
            return await Task.FromResult<CheckUserExistDto>(lst);
            //(IEnumerable<CheckUserExistDto>)await Task.FromResult<CheckUserExistDto>(lst);
        }

        //public async Task<UserModel> GetUserInfo(int model)
    }
}
