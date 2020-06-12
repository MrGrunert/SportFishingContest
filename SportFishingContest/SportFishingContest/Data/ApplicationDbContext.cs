using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportFishingContest.Models;

namespace SportFishingContest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contest> Contests { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Fish> Fishes { get; set; }

    }
}
