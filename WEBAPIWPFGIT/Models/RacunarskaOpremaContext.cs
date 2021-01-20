using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCLRacunari;

namespace WEBAPIWPFGIT.Models
{
    public class RacunarskaOpremaContext:DbContext
    {
        public RacunarskaOpremaContext(DbContextOptions<RacunarskaOpremaContext> opcije) : base(opcije)
        {
        }
        /// <summary>
        /// /////
        /// </summary>
        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
    }
}
