using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewspaperArchive.Application.Model
{
    public class EventModel
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int VenueId { get; set; }
        [Required]
        public int EventTypeId { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string HostName { get; set; }
        public string Message { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public class EventTypeModel
    {
        [Key]
        public int EventTypeId { get; set; }
        [Required]
        public string EventType { get; set; }
    }

    public class VenueModel
    {
        [Key]
        public int VenueId { get; set; }
        [Required]
        public string VenueName { get; set; }
    }
}
