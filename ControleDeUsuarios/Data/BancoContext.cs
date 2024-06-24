using SistemaDeCadastro.Models;
using Microsoft.EntityFrameworkCore;
using SistemaDeCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) :
            base(options)
        {
        }

        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
