using LaytonTemple.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaytonTemple.Models
{
    public class ApptContext: DbContext
    {
        public ApptContext (DbContextOptions<ApptContext> options) : base (options)
        {

        }

        public DbSet<GroupInfo> Groups { get; set; }
        public DbSet<AvailableTimes> AvailableTimes { get; set; }
    }
}
