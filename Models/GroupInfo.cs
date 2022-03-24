using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaytonTemple.Models
{
    public class GroupInfo
    {
        //Create database for storing group information
        [Key]
        [Required]
        public int GroupID { get; set; }
        [Required (ErrorMessage ="Please enter a name for your group.")]
        public string groupName { get; set; }
        [Required (ErrorMessage ="Please enter the number of people in your group")]
        public int groupSize { get; set; }
        [Required (ErrorMessage ="Please enter a valid email")]
        public string email { get; set; }
        [Required (ErrorMessage ="Please enter a valid phone number")]
        public string phone { get; set; }
        

        public string timeslot { get; set; }
    }
}
