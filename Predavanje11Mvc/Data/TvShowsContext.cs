using Microsoft.EntityFrameworkCore;
using Predavanje11Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Predavanje11Mvc.Data
{
    public class TvShowsContext : DbContext
    {
        public TvShowsContext(DbContextOptions<TvShowsContext> options)
            : base(options)
        {
        }

        public DbSet<TvShow> TvShow { get; set; }
    }
}
