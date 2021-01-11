using System;
using System.Collections.Generic;
using System.Text;

namespace NewspaperArchive.Application.Model
{
    public class userModel
    {
       
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string EmailAddress { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ScreenName { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string Zipcode { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string Province { get; set; }
            public string DayPhone { get; set; }
            public string NightPhone { get; set; }
            public string FaxNumber { get; set; }
            public string WebsiteUrl { get; set; }
            public int? MyPreference { get; set; }
            public int UserAccountId { get; set; }

            public int? ClippingsShare { get; set; }
            public int Approvalstatus { get; set; }     //  w.r.t  mks For User profile Images.
            public Nullable<System.DateTime> BirthDate { get; set; }

            public Nullable<System.DateTime> DateAdded { get; set; }
            public Nullable<System.DateTime> DateLastUpdate { get; set; }
            public bool IsBlockforClippingArticle { get; set; }
            public bool IsContributor { get; set; }
            public bool IsManager { get; set; }

            public bool isClipStatus { get; set; }
            public bool isObitInclude { get; set; }
            public Nullable<bool> IsLiveChat { get; set; }
            public int? PageViewCount { get; set; }
            public bool IsSSDI { get; set; }
            public bool IsExactSearch { get; set; }
            public bool IsViewerArrows { get; set; }
            public bool toUserName { get; set; }
            public bool IsThumb { get; set; }
            public string UserType { get; set; }
            public int? cartvalue { get; set; }

              public int? ShoppingCartId { get; set; }
        public List<ShoppingCartDetails> ShoppingCartInfo { get; set; }
        public List<ContainerType> ContainerTypeInfo { get; set; }
        public ShoppingCartModel ShoppingCartModel { get; set; }

    }
}
