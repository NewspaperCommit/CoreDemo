using System;
using System.Collections.Generic;
using System.Text;

namespace NewspaperArchive.Application.Common.DTO
{
   public class GetUserDetailDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ScreenName { get; set; }
        public string Address1 { get; set; }
      
    }
}
