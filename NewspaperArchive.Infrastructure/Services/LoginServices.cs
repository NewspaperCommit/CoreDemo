using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Application.Model;
using NewspaperArchive.Application.Services;
using NewspaperArchive.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static NewspaperArchive.Application.Model.LoginModel;
using static NewspaperArchive.Application.Model.ShoppingCartModel;
using System.Web.Mvc;
using NewspaperArchive.Application.Helper;

namespace NewspaperArchive.Infrastructure.Services
{
    
    class LoginServices : ILoginServices
    {
        private readonly SiteInfoDbContext context;
        private readonly ILoginServices _LoginServices;
        private readonly PaymentInformationDbContext paymentcontext;
        private int NumberOfContainers;
        private int InsertedShopingCartId = 0;
        public Decimal ShippingCharge = 0;
        bool totalCostUpdate = true;
        private readonly IContextDataHandler _common;
        //private readonly IJwt _IJwt;
        public LoginServices(SiteInfoDbContext context, PaymentInformationDbContext paymentcontext, IContextDataHandler IContextDataHandler)
        {
            this.context = context;
            this.paymentcontext = paymentcontext;
            _common = IContextDataHandler;
            //_IJwt = IJwt;
            //_LoginServices = ILoginServices;
        }



        public async Task<Apiresponsemodel> ValidateUserLogin(LoginModel model)
        {


            int LoginOrResetLogin = 0;
            var userModel = new userModel();
            Apiresponsemodel response = new Apiresponsemodel();
            var cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "SP_ValidateUserLoginV1_SingleLogin";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            string Ip = "127.0.0.1";
            string SessionId = "fbvya2iu4ppdbydqzbfclqco";
            DbDataReader reader = null;

            try
            {
                SqlParameter parm1 = new SqlParameter();
                parm1.ParameterName = "@UserName";
                parm1.Value = String.IsNullOrEmpty(model.username) ? (object)DBNull.Value : Convert.ToString(model.username.Trim());
                parm1.SqlDbType = SqlDbType.Text;
                SqlParameter parm2 = new SqlParameter();
                parm2.ParameterName = "@Password";
                parm2.Value = String.IsNullOrEmpty(model.password) ? (object)DBNull.Value : Convert.ToString(model.password.Trim());
                parm2.SqlDbType = SqlDbType.Text;
                parm2.Size = 50;
                SqlParameter parm3 = new SqlParameter();
                parm3.ParameterName = "@SessionID";
                parm3.Value = SessionId;
                parm3.SqlDbType = SqlDbType.Text;
                SqlParameter parm4 = new SqlParameter();
                parm4.ParameterName = "@IP";
                parm4.Value = Ip;
                parm4.SqlDbType = SqlDbType.Text;
                SqlParameter parm5 = new SqlParameter();
                parm5.ParameterName = "@LoginTime";
                parm5.Value = DateTime.Now;
                parm5.SqlDbType = SqlDbType.DateTime;
                SqlParameter parm6 = new SqlParameter();
                parm6.ParameterName = "@LoginExpiryTime";
                parm6.Value = DateTime.Now.AddMinutes(20d);
                parm6.SqlDbType = SqlDbType.DateTime;
                SqlParameter parm7 = new SqlParameter();
                parm7.ParameterName = "@LoginOrResetLogin";
                parm7.Value = LoginOrResetLogin;
                parm7.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(parm1);
                cmd.Parameters.Add(parm2);
                cmd.Parameters.Add(parm3);
                cmd.Parameters.Add(parm4);
                cmd.Parameters.Add(parm5);
                cmd.Parameters.Add(parm6);
                cmd.Parameters.Add(parm7);

                if (context.Database.GetDbConnection().State == ConnectionState.Closed)
                {
                    context.Database.GetDbConnection().Open();
                }
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {


                    reader.NextResult();



                }

                if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                        userModel.UserId = Convert.ToInt32(reader["UserId"].ToString());
                        userModel.UserName = reader["UserName"].ToString();
                        userModel.Password = reader["Password"].ToString();
                        userModel.EmailAddress = reader["EmailAddress"].ToString();
                        userModel.FirstName = reader["FirstName"].ToString();
                        userModel.LastName = reader["LastName"].ToString();
                        userModel.ScreenName = reader["ScreenName"].ToString();
                        userModel.Address1 = reader["Address1"].ToString();
                        userModel.Address2 = reader["Address2"].ToString();
                        userModel.City = reader["City"].ToString();
                        userModel.Zipcode = reader["Zipcode"].ToString();
                        userModel.Country = reader["Country"].ToString();
                        userModel.State = reader["State"].ToString();
                        userModel.Province = reader["Province"].ToString();
                        userModel.DayPhone = reader["DayPhone"].ToString();
                        userModel.NightPhone = reader["NightPhone"].ToString();
                        userModel.FaxNumber = reader["FaxNumber"].ToString();
                        userModel.WebsiteUrl = reader["WebsiteUrl"].ToString();
                        userModel.MyPreference = Convert.ToInt32(reader["MyPreference"].ToString());
                       /// userModel.UserAccountId = Convert.ToInt32(reader["UserAccountId"]);
                        userModel.ClippingsShare = Convert.ToInt32(reader["ClippingsShare"].ToString());
                        userModel.Approvalstatus = Convert.ToInt32(reader["Approvalstatus"].ToString());
                        userModel.BirthDate = Convert.ToDateTime(reader["BirthDate"].ToString());
                        userModel.DateAdded = Convert.ToDateTime(reader["DateAdded"].ToString());
                        userModel.DateLastUpdate = Convert.ToDateTime(reader["DateLastUpdate"].ToString());
                        //userModel.IsBlockforClippingArticle = Convert.ToBoolean(reader["IsBlockforClippingArticle"].ToString());
                        //userModel.IsContributor = Convert.ToBoolean(reader["IsContributor"].ToString());
                        //userModel.IsManager = Convert.ToBoolean(reader["IsManager"]);
                        //userModel.isClipStatus = Convert.ToBoolean(reader["isClipStatus"].ToString());
                        //userModel.isObitInclude = Convert.ToBoolean(reader["isObitInclude"].ToString());
                        //userModel.IsLiveChat = Convert.ToBoolean(reader["IsLiveChat"].ToString());
                        userModel.PageViewCount = Convert.ToInt32(reader["PageViewCount"].ToString());
                        userModel.IsSSDI = Convert.ToBoolean(reader["IsSSDI"].ToString());
                        userModel.IsExactSearch = Convert.ToBoolean(reader["IsExactSearch"].ToString());
                        userModel.IsViewerArrows = Convert.ToBoolean(reader["IsViewerArrows"].ToString());
                        userModel.toUserName = Convert.ToBoolean(reader["toUserName"].ToString());
                        userModel.IsThumb = Convert.ToBoolean(reader["IsThumb"].ToString());
                        userModel.UserType = reader["UserType"].ToString();



                    }



                    }
                //JwtToken jwtmodel = new JwtToken();
                //if (userModel.UserId > 0)
                //{

                //    jwtmodel = _IJwt.Authenticate(userModel);

                //}

                ShoppingCartItemsCount obj = new ShoppingCartItemsCount();
                obj = await GetItemCount(userModel.UserId, 1);
                if(obj != null)
                {
                    
                        userModel.ShoppingCartId = obj.ShoppingCartId;
                        userModel.cartvalue = obj.ItemCount;
                 }
                //ShoppingCartContainerInfo obj1 = new ShoppingCartContainerInfo();
                //obj1 = await GetShoppingCartAndContainerDetails(Convert.ToInt32(userModel.ShoppingCartId), 1);
                //if (obj1 !=null)
                //{
                //    userModel.ShoppingCartId = obj.ShoppingCartId;
                //    userModel.cartvalue = obj.ItemCount;
                //    userModel.ShoppingCartInfo = obj1.ShoppingCartInfo;
                //    userModel.ContainerTypeInfo = obj1.ContainerTypeInfo;

                //}
                ShoppingCartModel objshoppingCartModel = new ShoppingCartModel();
                var model1 = new ShoppingCartContainerInfo();
                objshoppingCartModel = await getCartDetailsNew(model1, false);
                userModel.ShoppingCartModel = objshoppingCartModel;
               
               
                response.Data = userModel;
               

                response.Message = "Successful";
                response.Status = 200;
            


            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.Status = 400;
            }
            finally
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
                if (context.Database.GetDbConnection().State == ConnectionState.Open)
                {
                    context.Database.GetDbConnection().Close();

                }
            }
            return response;
        }
        public async Task<ShoppingCartItemsCount> GetItemCount(int intUserID, int WebsiteID=1)
        {
            //int retunId = 0;
            Apiresponsemodel response = new Apiresponsemodel();
            ShoppingCartItemsCount model = new ShoppingCartItemsCount();

            try
            {
                SqlParameter userIdParam = new SqlParameter("@UserId", intUserID);
                SqlParameter WebsiteIDParam = new SqlParameter("@WebsiteID", WebsiteID);

                var result = paymentcontext.StatusValue.FromSqlRaw("exec [dbo].[NA_Get_ShoppingcartItemCount_MultiAccount] @UserId, @WebsiteID", userIdParam,
                   WebsiteIDParam);
                foreach (var k in result)
                {
                    model.ItemCount = k.ItemCount;
                    model.ShoppingCartId = k.ShoppingCartId;

                }
                
            }
            catch(Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.Status = 400;

            }
            finally
            {

                if (context.Database.GetDbConnection().State == ConnectionState.Open)
                {
                    context.Database.GetDbConnection().Close();
                }
            }
            return await Task.FromResult<ShoppingCartItemsCount>(model);
        }
        public async Task<ShoppingCartContainerInfo> GetShoppingCartAndContainerDetails(int intShoppingCartID, int WebsiteID = 1)
        {
            List<ShoppingCartDetails> ShoppingCartInfo = new List<ShoppingCartDetails>();
            List<ContainerType> ContainerTypeInfo = new List<ContainerType>();
            var model = new ShoppingCartContainerInfo();
            Apiresponsemodel response = new Apiresponsemodel();
            //ShoppingCartContainerInfo _shoppingCartContainerInfo = null;
            //intShoppingCartID = 441437;
            DbDataReader reader = null;
            try
            {
               // _shoppingCartContainerInfo = new ShoppingCartContainerInfo();
                var cmd = paymentcontext.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "NA_Get_CartOrderCheckoutWithPgV1";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                SqlParameter parm1 = new SqlParameter();
                parm1.ParameterName = "@ShoppingCartID";
                parm1.Value = intShoppingCartID;
                parm1.SqlDbType = SqlDbType.Int;
                SqlParameter parm2 = new SqlParameter();
                parm2.ParameterName = "@websiteid";
                parm2.Value = WebsiteID;
                parm2.SqlDbType = SqlDbType.Int;

                cmd.Parameters.Add(parm1);
                cmd.Parameters.Add(parm2);

                if (paymentcontext.Database.GetDbConnection().State == ConnectionState.Closed)
                {
                    paymentcontext.Database.GetDbConnection().Open();
                }
                reader = cmd.ExecuteReader();
               
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShoppingCartInfo.Add(new ShoppingCartDetails()
                        {
                            shoppingcartid = Convert.ToInt32(reader["ShoppingCartId"].ToString()),
                            totalcost = Convert.ToDecimal(reader["totalcost"].ToString()),
                            ShoppingCartitemsId = Convert.ToInt32(reader["ShoppingCartitemsId"].ToString()),
                            quantity = Convert.ToInt32(reader["quantity"].ToString()),
                            itemcost = Convert.ToDecimal(reader["itemcost"].ToString()),
                            containercost = Convert.ToDecimal(reader["containercost"].ToString()),
                            colorname = reader["colorname"].ToString(),
                            colorid = Convert.ToInt32(reader["colorid"].ToString()),
                            containername = reader["containername"].ToString(),
                            containertypeid = Convert.ToInt32(reader["containertypeid"].ToString()),
                            userid = Convert.ToInt32(reader["userid"].ToString()),
                            itemtypename = reader["itemtypename"].ToString(),
                            itemtypeid = Convert.ToInt32(reader["itemtypeid"].ToString()),
                            shoppingcartimage = reader["shoppingcartimage"].ToString(),
                            websitetitle = reader["websitetitle"].ToString(),
                            countryName = reader["countryName"].ToString(),
                            stateName = reader["stateName"].ToString(),
                            cityName = reader["cityName"].ToString(),
                            pubTitle = reader["pubTitle"].ToString(),
                            pubDate = reader["pubDate"].ToString(),
                            pubid = Convert.ToInt32(reader["pubid"].ToString()),
                            countryid = Convert.ToInt32(reader["countryid"].ToString()),
                            stateid = Convert.ToInt32(reader["stateid"].ToString()),
                            cityid = Convert.ToInt32(reader["cityid"].ToString()),
                            destimagepath = reader["destimagepath"].ToString(),
                            imageid = Convert.ToInt32(reader["imageid"].ToString()),
                            itemvalue = Convert.ToInt32(reader["itemvalue"].ToString()),
                            pagenum = Convert.ToInt32(reader["pagenum"].ToString()),
                            displayname = reader["displayname"].ToString(),
                            //initialcost = Convert.ToDecimal(reader["initialcost"].ToString()),
                            //plantype = reader["plantype"].ToString(),
                            //planid = Convert.ToInt32(reader["planid"].ToString()),
                            //roleid = Convert.ToInt32(reader["roleid"].ToString()),
                            //initialPlanLength = Convert.ToInt32(reader["initialPlanLength"].ToString())
                        });
                    }
                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ContainerTypeInfo.Add(new ContainerType()
                        {
                            containerTypeID = Convert.ToInt32(reader["containerTypeID"].ToString()),
                            containerName = reader["containerName"].ToString(),
                            containerCost = Convert.ToDecimal(reader["containerCost"].ToString()),
                            containerType = reader["containerType"].ToString(),
                            maxItemCount = Convert.ToInt32(reader["maxItemCount"].ToString())
                            

                        });


                    }
                }
                model.ShoppingCartInfo = ShoppingCartInfo;
                model.ContainerTypeInfo = ContainerTypeInfo;

                response.Data = model;
                response.Message = "Successful";
                response.Status = 200;


            }



            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.Status = 400;

            }
            finally
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
                if (paymentcontext.Database.GetDbConnection().State == ConnectionState.Open)
                {
                    paymentcontext.Database.GetDbConnection().Close();

                }
            }
            return await Task.FromResult<ShoppingCartContainerInfo>(model);
        }



        private async Task<ShoppingCartModel>  getCartDetailsNew(ShoppingCartContainerInfo objShoppingCartContainerInfo, bool IsRemove)
        {
            ShoppingCartModel model = new ShoppingCartModel();
            List<ShoppingCartDetails> objCartDetails = null;
            List<ContainerType> objContainerDetails = null;

            model.TotalCost = 0;
            model.CartDetails = new List<ShoppingCartDetailsModel>();

            if (objShoppingCartContainerInfo != null && objShoppingCartContainerInfo.ContainerTypeInfo != null)
            {
                objCartDetails = objShoppingCartContainerInfo.ShoppingCartInfo;

            }
            else
            {
                var shoppingCartId = 441437;
                //if (Session["clsShoppingCart"] != null || InsertedShopingCartId != 0)
                //{

                //    if (InsertedShopingCartId > 0)
                //    {
                //        shoppingCartId = InsertedShopingCartId;
                //    }
                //else
                //{
                //    shoppingCartId = _common.GetIntegerValue(Session["clsShoppingCart"], 0);
                //}

                if (shoppingCartId > 0)
                {
                    objShoppingCartContainerInfo = await GetShoppingCartAndContainerDetails(shoppingCartId, 1);
                    objCartDetails = objShoppingCartContainerInfo.ShoppingCartInfo;

                }
                //}
                objCartDetails = objShoppingCartContainerInfo.ShoppingCartInfo;

            }
            if (objCartDetails != null && objCartDetails.Count > 0)
            {
                //Session["shoppingCartCount"] = objCartDetails.Count;
                foreach (var item in objCartDetails)
                {
                    DateTime dtParse;

                    var cart = new ShoppingCartDetailsModel();
                    var _color = new List<SelectListItem>();
                    _color.Insert(0, new SelectListItem { Value = "1", Text = "White", Selected = 1 == _common.GetIntegerValue(item.colorid, 0) });
                    _color.Insert(1, new SelectListItem { Value = "2", Text = "Cream", Selected = 2 == _common.GetIntegerValue(item.colorid, 0) });
                    _color.Insert(2, new SelectListItem { Value = "3", Text = "Fawn", Selected = 3 ==  _common.GetIntegerValue(item.colorid, 0) });
                    cart.Colors = _color;                                                             

                    //Added By Rachna Singh 

                    objContainerDetails = objShoppingCartContainerInfo.ContainerTypeInfo;
                    cart.ShippingPackages = new List<SelectListItem>();
                    foreach (var c in objContainerDetails)
                    {
                        if (c.containerName != "Box" && c.containerName != "Flat")//do not add Box and Flat as a possible selection
                        {
                            cart.ShippingPackages.Add(new SelectListItem()
                            {
                                Text = c.containerName + " $" + c.containerCost + " - " + c.containerType,
                                Value = c.containerTypeID.ToString(),
                                Selected = c.containerTypeID == _common.GetIntegerValue(item.containertypeid, 0)
                            });

                        }
                    }
                    cart.ImageId = _common.GetStringValue(item.imageid, "0");
                    cart.Item = "22\"x30\" Newspaper Reproduction";
                    cart.Item = "22\"x30\" Newspaper Poster Print on 90lb 100% cotton fiber based paper.";

                    if (!String.IsNullOrWhiteSpace(item.pubTitle))
                    {
                        cart.Description = "<b> The " + _common.GetStringValue(item.pubTitle, "No description found").Replace(", The", "") + "<br />" +
                                        (DateTime.TryParse(_common.GetStringValue(item.pubDate, ""), out dtParse) ? dtParse.ToLongDateString() : "") + "<br/> pg. " + _common.GetStringValue(item.pagenum, "0") + "<br />" +
                                       _common.GetStringValue(item.cityName, "") + ", " + _common.GetStringValue(item.stateName, "") + "<br /> " +
                                       _common.GetStringValue(item.countryName, "") + "</b>";
                    }
                    else
                    {
                        cart.Description = "<b>No description found</b>";
                    }

                    cart.ItemTypeId = _common.GetIntegerValue(item.itemtypeid, 1);
                    cart.Quantity = _common.GetIntegerValue(item.quantity, 1);
                    cart.UnitPrice = _common.GetStringValue(item.itemcost, "0");
                    cart.ShippingPackageId = _common.GetStringValue(item.containertypeid, "");
                    cart.ColorId = _common.GetStringValue(item.colorid, "1");
                    cart.ItemTypeName = _common.GetStringValue(item.itemtypename, "Order Print");
                    cart.ShoppingCartItemsId = _common.GetIntegerValue(item.ShoppingCartitemsId, 0);
                    cart.ItemValue = _common.GetStringValue(item.itemvalue, "");
                    cart.ItemTypeId = _common.GetIntegerValue(item.itemtypeid, 1);

                    model.CartDetails.Add(cart);
                   

                }

                if (!IsRemove)
                {
                    CalculateTotalsNew(model, objShoppingCartContainerInfo);
                }

            }
            else
            {
                //Session["shoppingCartCount"] = string.Empty;
            }

            return model;
        }

       


        public Decimal CalculateTotalsNew(ShoppingCartModel model, ShoppingCartContainerInfo objShoppingCartContainerInfo)
        {
            Decimal FinalShippingTotal = 0;
            NumberOfContainers = 0;
            Decimal SubTotal = 0;
            Decimal ShippingTotal = 0;
            Decimal TotalPrice = 0;

            int ContainerID = 0;
            int Quantity = 0;


            Decimal UnitPrice = 0;
            Decimal Cost = 0;
            Decimal CartSubTotal = 0;
            Decimal ShippingSubTotal = 0;
            Decimal TotalAmount = 0;
            Decimal DiscountedAmount = 0;

            var container = objShoppingCartContainerInfo.ContainerTypeInfo;

            int[] ContainerCounter = new int[container.Count + 1];

            // Process subtotal
            foreach (var itemname in model.CartDetails)
            {

                Quantity = _common.GetIntegerValue(itemname.Quantity, 1);
                UnitPrice = 0;
                switch (itemname.ItemTypeName)
                {
                    case "Order Print":
                        ContainerID = _common.GetIntegerValue(itemname.ShippingPackageId, 0);
                        UnitPrice = Convert.ToDecimal(itemname.UnitPrice);
                        ContainerCounter[ContainerID] += Quantity;
                        break;
                }

            }
            //Added for buy 2 get 1 free offer.
            int quantity = 0;
            foreach (var item in model.CartDetails)
            {
                quantity = quantity + item.Quantity;
            }

            TotalAmount = quantity * UnitPrice;
            CartSubTotal = CalculateCostAfterDiscount(quantity, UnitPrice);
            DiscountedAmount = TotalAmount - CartSubTotal;
            int offerQuantity = (quantity / 3);
            int RemainingQuantity = (quantity - offerQuantity);
            model.DiscountDetails = "<span> <b>As per buy 2 get 1 offer</b> <br/> Total Quantity: " + quantity.ToString() + "<br/> Discounted Quantity: " + offerQuantity + "<br/> Quantity Charged: " + RemainingQuantity + "<br/> <b>Cart Total: " + RemainingQuantity * UnitPrice + "<br/> (Quantity charged * Unit Price)</span>";

            foreach (var type in container)
            {

                if (type.maxItemCount != 0 && type.maxItemCount != null)
                {
                    int nc = calculatecontainers(type, ContainerCounter);
                    Decimal RealPrice = Convert.ToDecimal(type.containerCost);
                    UnitPrice = RealPrice;
                    Cost = UnitPrice;
                    NumberOfContainers += nc;
                    FinalShippingTotal += nc * Cost;
                }

            }

            if (model.CartDetails.Count > 0 && ShippingSubTotal == 0)
            {
                ShippingSubTotal = ShippingCharge;
            }
            model.TotalAmount = TotalAmount;
            model.DiscountedAmount = DiscountedAmount;
            model.SubTotal = SubTotal = CartSubTotal;
            model.ShippingTotal = ShippingTotal = ShippingSubTotal;
            if (totalCostUpdate)
            {
                //Session["shoppingCartTotal"] = model.TotalCost = TotalPrice = SubTotal + ShippingTotal;
                model.TotalCost = TotalPrice = SubTotal + ShippingTotal;
            }
            else
            {
                model.TotalCost = TotalPrice = SubTotal + ShippingTotal;
            }
            return TotalPrice;
        }

        public decimal CalculateCostAfterDiscount(int itemCount, decimal itemCost)
        {
            var discountedCost = ((itemCount / 3) * (itemCost * 2)) + ((itemCount % 3) * itemCost);
            return discountedCost;
        }

        public int calculatecontainers(ContainerType type, int[] containercounter)
        {
            int containerid = _common.GetIntegerValue(type.containerTypeID, 0);
            int maxcount = _common.GetIntegerValue(type.maxItemCount, 0);
            int remainder = 0;
            //number of containers needed for shipment
            int nc = Math.DivRem(containercounter[containerid], maxcount, out remainder);
            if (remainder > 0) nc++; //a remainder value requires another container
            return nc;
        }

           }
}
