using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewspaperArchive.Application.Model;
using static NewspaperArchive.Application.Model.ShoppingCartModel;

namespace NewspaperArchive.Application.Services
{
   public interface IShoppingCart
    {
        //Task<ShoppingCartModel> GetShoppingCartNavigation();
        //Task<ShoppingCartModel> GetCartDetailsNew();

        Task<Apiresponsemodel> CalculateTotalPrice(int totalquantity, int itemBaseTotalQnty, int deductedQuantity, int itemQuantity, int totalCartDetailCount, int count, string modelUnitPrice);
        // ShoppingCartItemsCount GetItemCount(int intUserID, int WebsiteID);

    }
}
