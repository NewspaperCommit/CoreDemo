using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewspaperArchive.Application.Common.Dtos
{
    public class EventListDTO
    {
        [Key]
        public int EventId { get; set; }
        public string HostName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string VenueName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
  
    }
}
