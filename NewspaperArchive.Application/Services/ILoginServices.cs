using NewspaperArchive.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static NewspaperArchive.Application.Model.ShoppingCartModel;

namespace NewspaperArchive.Application.Services
{
     public interface ILoginServices
    {

        Task<Apiresponsemodel> ValidateUserLogin(LoginModel model);
        Task<ShoppingCartItemsCount> GetItemCount(int intUserID, int WebsiteID);
        Task<ShoppingCartContainerInfo> GetShoppingCartAndContainerDetails(int intShoppingCartID, int WebsiteID);
    }
}
