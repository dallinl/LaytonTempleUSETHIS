using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaytonTemple.Models.ViewModels
{
    public class GroupView
    {
        [Key]
        [Required]
        public int GroupID { get; set; }
        public GroupInfo groupinfo { get; set; }
        public AvailableTimes Timeslot { get; set; }
    }
}
