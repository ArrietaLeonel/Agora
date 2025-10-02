using Microsoft.EntityFrameworkCore;
using Service.Enums;
using Service.Models;

namespace Backend.DataContext
{
    public class AgoraContext: DbContext
    {
        public DbSet<TipoInscripcion> TipoInscripciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<TipoInscripcionCapacitacion> TiposInscripcionesCapacitaciones { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }

        public AgoraContext(){ }

        public AgoraContext(DbContextOptions<AgoraContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cargamos los datos iniciales de tipo de inscripciones(Público en general, Docentes, Estudiantes, Jubilados)
            modelBuilder.Entity<TipoInscripcion>().HasData(
                new TipoInscripcion { Id = 1, Nombre = "Público en general" },
                new TipoInscripcion { Id = 2, Nombre = "Docentes" },
                new TipoInscripcion { Id = 3, Nombre = "Estudiantes" },
                new TipoInscripcion { Id = 4, Nombre = "Jubilados" }
            );

            //cargamos los datos iniciales de usuarios con los modelos en service

            //cargamos los datos iniciales de usuarios con los modelos en service
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nombre = "Juan", Apellido = "Pérez", Dni = "12345678", Email = "juan.perez@email.com", TipoUsuario= TipoUsuarioEnum.Estudiante, IsDeleted = false },
                new Usuario { Id = 2, Nombre = "María", Apellido = "García", Dni = "87654321", Email = "maria.garcia@email.com", TipoUsuario = TipoUsuarioEnum.Docente, IsDeleted = false },
                new Usuario { Id = 3, Nombre = "Pedro", Apellido = "López", Dni = "11223344", Email = "pedro.lopez@email.com", TipoUsuario = TipoUsuarioEnum.Administrador, IsDeleted = false }
            );


            
            //cargamos los datos iniciales de capacitaciones
            modelBuilder.Entity<Capacitacion>().HasData(
                new Capacitacion { Id = 1, Nombre = "Introducción a la Programación", Detalle = "Aprende los conceptos básicos de programación.", Ponente = "Carlos Gómez", FechaHora = DateTime.Now.AddDays(10), Cupo = 30, InscripcionAbierta = true },
                new Capacitacion { Id = 2, Nombre = "Desarrollo Web con ASP.NET Core", Detalle = "Crea aplicaciones web modernas con ASP.NET Core.", Ponente = "Ana Martínez", FechaHora = DateTime.Now.AddDays(20), Cupo = 25, InscripcionAbierta = true }
            );

            // cargamos los datos iniciales de tipos de inscripciones para capacitaciones, definiendo el costo de inscripción paracada tipo
            modelBuilder.Entity<TipoInscripcionCapacitacion>().HasData(
                new TipoInscripcionCapacitacion { Id = 1, TipoInscripcionId = 1, CapacitacionId = 1, Costo = 10000 },
                new TipoInscripcionCapacitacion { Id = 2, TipoInscripcionId = 2, CapacitacionId = 1, Costo = 5000 },
                new TipoInscripcionCapacitacion { Id = 3, TipoInscripcionId = 3, CapacitacionId = 1, Costo = 3000 },
                new TipoInscripcionCapacitacion { Id = 4, TipoInscripcionId = 4, CapacitacionId = 1, Costo = 2000 },
                new TipoInscripcionCapacitacion { Id = 5, TipoInscripcionId = 1, CapacitacionId = 2, Costo = 12000 },
                new TipoInscripcionCapacitacion { Id = 6, TipoInscripcionId = 2, CapacitacionId = 2, Costo = 6000 },
                new TipoInscripcionCapacitacion { Id = 7, TipoInscripcionId = 3, CapacitacionId = 2, Costo = 4000 },
                new TipoInscripcionCapacitacion { Id = 8, TipoInscripcionId = 4, CapacitacionId = 2, Costo = 3000 }
            );

            // cargamos los datos iniciales de inscripciones
            modelBuilder.Entity<Inscripcion>().HasData(
                new Inscripcion
                {
                    Id = 1,
                    UsuarioId = 1,
                    TipoInscripcionId = 3, // Estudiantes
                    CapacitacionId = 1,
                    Acreditado = false,
                    Importe = 3000,
                    Pagado = false,
                    UsuarioCobroId = null,
                    IsDeleted = false
                },
                new Inscripcion
                {
                    Id = 2,
                    UsuarioId = 2,
                    TipoInscripcionId = 2, // Docentes
                    CapacitacionId = 2,
                    Acreditado = false,
                    Importe = 6000,
                    Pagado = false,
                    UsuarioCobroId = null,
                    IsDeleted = false
                },
                new Inscripcion
                {
                    Id = 3,
                    UsuarioId = 3,
                    TipoInscripcionId = 1, // Público en general
                    CapacitacionId = 1,
                    Acreditado = false,
                    Importe = 10000,
                    Pagado = false,
                    UsuarioCobroId = null,
                    IsDeleted = false
                }
            );

            // Configuramos las querys para que no devuelvan los elementos eliminados
            modelBuilder.Entity<TipoInscripcion>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Usuario>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Capacitacion>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<TipoInscripcionCapacitacion>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Inscripcion>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
