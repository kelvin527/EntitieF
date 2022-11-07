using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Reflection;

namespace Pelicula.Api.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        /*ESTE METODO SE USA PARA COMVERTIR EL TIPO DE DATO DE C# A SQL*/
        protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
        {
            modelConfigurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*este metodo es para que todas las configuraciones de las Entidades que se encuentran
             es una carpeta con el mismo nombre puedan ejecutarse*/
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());/*Assembly sirve para escanear el proyecto buscando configuraciones de entidades
                                                                                           y ejecutarla como si estuvieran en el api fluente*/


            /*asi se hace una llave primaria en un api fluente
           // modelBuilder.Entity<Genero>().HasKey(x => x.Id);*/
            //***********************************************************************
         /* modelBuilder.Entity<Cine>().Property(pro=> pro.Precio).HasPrecision(9,2);
          dandole preci*/
         //********************************************************************************
         /*modelBuilder.Entity<Pelicula>().Property(pro=> pro.PostelrURL).HasMaxLength(500)
                .IsUnicode(false);/*IsUnicode sirve para que la URL tome todos los caracteres
                                   de la misma, no importar el caracter*/
         //***************************************************************************************
            /*modelBuilder.Entity<SalaDeCine>().Property(pro => pro.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones);//esto es para poner un valor por defecto a esa tabla*/
            //*******************************************************************************************************
            /*asi se crea una llave compuesta
            modelBuilder.Entity<PeliculaActor>().HasKey(prop => new { prop.PeliculaId, prop.ActorId });*/
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CineOfertas { get; set; }
        public DbSet<SalaDeCine> SalaDeCines { get; set; }
        public DbSet<PeliculaActor> PeliculaActor { get; set; }

    }
}
