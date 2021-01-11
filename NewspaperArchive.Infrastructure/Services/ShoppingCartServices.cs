using NewspaperArchive.Application.Model;
using NewspaperArchive.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperArchive.Infrastructure.Services
{
    public class ShoppingCartServices : IShoppingCart
    {
        public ShoppingCartServices()
        {

        }


        public async Task<Apiresponsemodel> CalculateTotalPrice(int totalquantity, int itemBaseTotalQnty,  int deductedQuantity, int itemQuantity, int totalCartDetailCount, int count, string modelUnitPrice)
        {
            Apiresponsemodel response = new Apiresponsemodel();
            int defaultValue = 1;
            int totalDeductedQnty = (totalquantity / 3);
            int quantity = Convert.ToInt32(Math.Round(Convert.ToDecimal((itemQuantity) / 3)));
            if (totalDeductedQnty == deductedQuantity)
            {
                quantity = 0;
                deductedQuantity += quantity;
                itemBaseTotalQnty = itemBaseTotalQnty - itemQuantity;
            }
            else
            {
                if (totalCartDetailCount >= count)
                {
                    if (count != defaultValue)
                    {
                        int pendingQnty = (totalDeductedQnty - deductedQuantity);
                        if (pendingQnty > 0)
                        {
                            if (itemQuantity > 0)
                            {
                                if (pendingQnty <= itemQuantity)
                                {
                                    deductedQuantity = (deductedQuantity + pendingQnty);
                                    quantity = pendingQnty;
                                }
                                else
                                {
                                    deductedQuantity += defaultValue;
                                    quantity = defaultValue;
                                }
                            }
                            else if (pendingQnty == defaultValue)
                            {
                                if (pendingQnty <= itemQuantity)
                                {
                                    deductedQuantity = (deductedQuantity + pendingQnty);
                                    quantity = pendingQnty;
                                }
                            }
                        }
                    }
                    else
                    {
                        deductedQuantity += quantity;
                    }
                }

                itemBaseTotalQnty = itemBaseTotalQnty - itemQuantity;
            }

            // return await Task.FromResult<decimal>(((itemQuantity) - quantity) * (Convert.ToDecimal(modelUnitPrice))); 
            var totalprice = (((itemQuantity) - quantity) * (Convert.ToDecimal(modelUnitPrice)));
            response.Data = totalprice;
            response.Message = "Successful";
            response.Status = 200;
            return response;
        }

        /// <summary>





    }
}
