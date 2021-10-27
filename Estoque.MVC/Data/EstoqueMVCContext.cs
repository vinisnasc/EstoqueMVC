using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estoque.MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Estoque.MVC.Data
{
    public class EstoqueMVCContext : IdentityDbContext<IdentityUser>
    {
        public EstoqueMVCContext (DbContextOptions<EstoqueMVCContext> options) : base(options)
        {
        }

        public DbSet<EPI> EPI { get; set; }
        public DbSet<Retirada> Retirada { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
