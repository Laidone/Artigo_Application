using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Artigo_Application.Models;

namespace Artigo_Application.Data
{
    public class Artigo_ApplicationContext : DbContext
    {
        public Artigo_ApplicationContext (DbContextOptions<Artigo_ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Artigo_Application.Models.Artigo> Artigo { get; set; }
    }
}
