using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcademiaVixTeam.Models;

namespace AcademiaVixTeam.Data
{
    public class AcademiaVixTeamContext : DbContext
    {
        public AcademiaVixTeamContext (DbContextOptions<AcademiaVixTeamContext> options)
            : base(options)
        {
        }

        public DbSet<AcademiaVixTeam.Models.PessoalModel> PessoalModel { get; set; }
    }
}
