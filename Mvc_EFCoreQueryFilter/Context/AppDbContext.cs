using Microsoft.EntityFrameworkCore;
using Mvc_EFCoreQueryFilter.Models;

namespace Mvc_EFCoreQueryFilter.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>().HasQueryFilter(c => c.Alunos != null && c.Alunos.Count > 0);

        modelBuilder.Entity<Aluno>().HasQueryFilter(a => a.Ativo);

        modelBuilder.Entity<Curso>().HasData(
           new Curso { Id = 1, Nome = "Inglês" },
           new Curso { Id = 2, Nome = "Matemática" },
           new Curso { Id = 3, Nome = "Ciências" },
           new Curso { Id = 4, Nome = "Química" },
           new Curso { Id = 5, Nome = "Música" }
       );

        modelBuilder.Entity<Aluno>().HasData(
            new Aluno { AlunoId = 1, Nome = "João", Ativo = true, CursoId = 1 },
            new Aluno { AlunoId = 2, Nome = "Maria", Ativo = true, CursoId = 1 },
            new Aluno { AlunoId = 3, Nome = "Pedro", Ativo = false, CursoId = 2 },
            new Aluno { AlunoId = 4, Nome = "Ana", Ativo = true, CursoId = 2 },
            new Aluno { AlunoId = 5, Nome = "Carlos", Ativo = true, CursoId = 3 },
            new Aluno { AlunoId = 6, Nome = "Mariana", Ativo = false, CursoId = 3 },
            new Aluno { AlunoId = 7, Nome = "Lucas", Ativo = true, CursoId = 4 },
            new Aluno { AlunoId = 8, Nome = "Juliana", Ativo = true, CursoId = 4 },
            new Aluno { AlunoId = 9, Nome = "Rodrigo", Ativo = false, CursoId = 1 },
            new Aluno { AlunoId = 10, Nome = "Fernanda", Ativo = true, CursoId = 2 }
        );
    }
}