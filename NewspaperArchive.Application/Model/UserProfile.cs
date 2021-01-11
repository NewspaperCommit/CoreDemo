using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewspaperArchive.Application.Model
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public string OIdProvider { get; set; }
        public string OId { get; set; }
    }
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public bool Status { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string EmailAddress { get; set; }
        //public bool RememberMe { get; set; }
    }

    //Demo table
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        //[Required]
       // public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string EmailAddress { get; set; }
      //  public string Address { get; set; }
        public DateTime?  DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public string Token { get; set; }

    }
}
