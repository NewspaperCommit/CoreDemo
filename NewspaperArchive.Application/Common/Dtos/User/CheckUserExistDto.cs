using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewspaperArchive.Application.Common.Dtos.User
{
   public  class CheckUserExistDto
    {
        [Key]
        public int Userid { get; set; }
        public string Firstname { get; set; }
        //public string EmailAddress { get; set; }
        public string Status { get; set; }
        //public string UserName { get; set; }
        
    }
}
