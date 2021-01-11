using System;
using System.Collections.Generic;
using System.Text;

namespace NewspaperArchive.Domain.Entities.Users
{
    public partial class User : BaseEntity
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
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<System.DateTime> DateLastUpdate { get; set; }
        public int Approvalstatus { get; set; }  
        public bool IsBlockforClippingArticle { get; set; }


    }
   
}
