using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnApi.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnApi.Data
{
    public class LearnDbContext(DbContextOptions<LearnDbContext> options) : DbContext(options)
    {
        public required DbSet<Learn> Learns { get; set; }
    }
}