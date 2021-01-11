using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Application.Common.Dtos.User;
using NewspaperArchive.Application.Model;
using NewspaperArchive.Application.Services;
using NewspaperArchive.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperArchive.Infrastructure.Services
{
   public class Service:IService
    {
        private readonly SiteInfoDbContext context;
      //  private readonly IParameterManager _parameterManager;
        public Service(SiteInfoDbContext context)
        {
            this.context = context;
          //  _parameterManager= parameterManager;
        }


        public async Task<UserModel> GetUserInfo(int model)
        {

            UserModel lst = new UserModel();
            string userName = "sddev";
            string passowrd = "admin";
            try
            {
                // Settings.  
                SqlParameter usernameParam = new SqlParameter("@UserName", userName.ToString() ?? (object)DBNull.Value);
                SqlParameter passwordParam = new SqlParameter("@UserPassword", passowrd.ToString() ?? (object)DBNull.Value);
                var lst1 = context
                .GetUserInfo
                .FromSqlRaw("exec [dbo].[Summary_Login_V1] @UserName, @UserPassword", usernameParam, passwordParam);
                foreach(var k in lst1)
                {
                    lst.UserId = k.UserId;
                    lst.Password = k.Password;
                    lst.UserName = k.UserName;
                    lst.Status = k.Status;
                    lst.Role = k.Role;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult<UserModel>(lst);
        }
        
        //{
        //    string userName = "sddev";
        //    string passowrd = "admin";
        //    SqlParameter usernameParam = new SqlParameter("@UserName", userName.ToString() ?? (object)DBNull.Value);
        //    SqlParameter passwordParam = new SqlParameter("@UserPassword", passowrd.ToString() ?? (object)DBNull.Value);
        //    var user = context.ExecuteStoredProcedureSingleNonEntity<UserModel>
        //         ("Summary_Login_V1 @UserName, @UserPassword", userName, passowrd

        //       //  _parameterManager.GetNew("@UserName", userName, ParameterDirection.Input, SqlDbType.VarChar),
        //       //_parameterManager.GetNew("@UserPassword", passowrd, ParameterDirection.Input, SqlDbType.VarChar)

        //       );

        //    // _unitOfWork.WebsiteScrapingContext.ExecuteStoredProcedureSingleNonEntity<User>
        //    //("GetSummaryUserDetailsByEmailAddress",
        //    //_parameterManager.GetNew("@EmailAddress", emailAddress, ParameterDirection.Input, SqlDbType.VarChar));
        //    return await Task.FromResult<UserModel>(user);
        //}

        //public Task<UserModel> GetUserInfo(int model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
