using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewspaperArchive.Application.Common.Dtos
{
    public class LoginStatusDTO
    {
        [Key]
        public string FirstName { get; set; }
    }

    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ResultDTO
    {
        [Key]
        public int Id { get; set; }
    }
}
