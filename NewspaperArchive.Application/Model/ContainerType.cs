using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewspaperArchive.Application.Model
{
     public class ContainerType
    {
        [Key]
        public int containerTypeID { get; set; }
        public string containerName { get; set; }
        public decimal containerCost { get; set; }
        public string containerType { get; set; }
        public int maxItemCount { get; set; }
        
        //roleid = Convert.ToInt32(reader["roleid"].ToString()),
    }
}
