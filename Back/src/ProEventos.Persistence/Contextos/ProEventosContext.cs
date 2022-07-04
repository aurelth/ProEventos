using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Palestrant> Palestrants { get; set; }
        public DbSet<PalestrantEvento> PalestrantEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestrantEvento>().HasKey(pe => new {pe.EventoId, pe.PalestrantId});

            modelBuilder.Entity<Evento>()
                .HasMany( e => e.RedeSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrant>()
                .HasMany( e => e.RedesSociais)
                .WithOne(rs => rs.Palestrant)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}