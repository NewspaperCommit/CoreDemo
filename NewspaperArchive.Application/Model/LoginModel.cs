using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewspaperArchive.Application.Model
{
    public class LoginModel
    {

        //[required]
        //[display(name = "username")]
        [Key]
        public int UserId { get; set; }
        public string username { get; set; }

        //[required]
        //[datatype(datatype.password)]
        //[display(name = "password")]
        public string password { get; set; }
       // public string resetpassword { get; set; }

       // //[display(name = "remember me")]
       // public bool rememberme { get; set; }

       // public string loginmessage { get; set; }
       // public string returnurl { get; set; }
       // public string urllistdetail { get; set; }
       // //
       // public int userid { get; set; }
       // //
       // //[required]
       // //[datatype(datatype.emailaddress)]
       //// [na.website.framework.emailaddressattribute(errormessage = "please enter valid email address")]
       // //[display(name = "email address")]
       // public string emailaddess { get; set; }

       // public string forgotmessage { get; set; }

       // public bool isconcurrent { get; set; }
       // public string redirecturl { get; set; }

       // public bool isblacklisted { get; set; }

    }
}
