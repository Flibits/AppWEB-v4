using AppWEB.Data.Mapeamento;
using AppWEB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWEB.Data
{
    public class JovemProgramadorContexto: DbContext
    {
        public JovemProgramadorContexto(DbContextOptions<JovemProgramadorContexto> options): base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapping());
        }

        public DbSet<AlunoModel> Aluno { get; set; }



    }
}
