namespace Mvc_EFCoreQueryFilter.Models;

public class Aluno
{
    public int AlunoId { get; set; }
    public string? Nome { get; set; }
    public bool Ativo { get; set; }
    public Curso? Curso { get; set; }
    public int CursoId { get; set; }
}
