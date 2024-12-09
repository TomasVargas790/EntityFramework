
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using projectef.Models;

namespace projectef;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        List<Categoria> categoriasInit =
        [
            new Categoria()
            {
                CategoriaId = Guid.Parse("dede8ef4-a93f-4b7c-a8a8-770c21446b08"),
                Nombre = "Actividades pendientes",
                Peso = 20
            },
            new Categoria()
            {
                CategoriaId = Guid.Parse("cb62f99c-82b5-47c0-8f44-72e9566b377f"),
                Nombre = "Actividades personales",
                Peso = 50
            },
        ];


        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(c => c.CategoriaId);
            categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(c => c.Descripcion).IsRequired(false);
            categoria.Property(c => c.Peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = [
            new Tarea(){
                TareaId = Guid.Parse("af6bc98f-7e3c-42ff-826b-825bbf89d7a8"),
                CategoriaId = Guid.Parse("dede8ef4-a93f-4b7c-a8a8-770c21446b08"),
                Prioridad = Prioridad.Mediana,
                Titulo = "Pago de servicios publicos",
                FechaCreacion = DateTime.Now
            },
            new Tarea(){
                TareaId = Guid.Parse("9e59edc3-632a-43ef-b647-3560b57fd4cd"),
                CategoriaId = Guid.Parse("cb62f99c-82b5-47c0-8f44-72e9566b377f"),
                Prioridad = Prioridad.Baja,
                Titulo = "Terminar de ver pelicula en Netflix",
                FechaCreacion = DateTime.Now
            },
        ];

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(t => t.TareaId);
            tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(t => t.CategoriaId);
            tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(t => t.Descripcion).IsRequired(false);
            tarea.Property(t => t.Prioridad);
            tarea.Property(t => t.FechaCreacion);
            tarea.Ignore(t => t.Resumen);
            tarea.HasData(tareasInit);
        });

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));

    }
}