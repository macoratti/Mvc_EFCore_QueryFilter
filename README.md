Os Global Query Filters (Filtros de Consulta Globais) são uma maneira de aplicar condições de
filtro a todas as consultas feitas em uma entidade específica

Esses filtros são aplicados automaticamente a todas as consultas que envolvam esses tipos de 
entidade, a menos que sejam desativados explicitamente

Podemos definir um Global Query Filter para entidade Produto no método OnModelCreating no 
contexto do banco de dados usando o método HasQueryFilter e especificando a expressão para
filtrar somente os produtos ativos

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Produto>().HasQueryFilter(p => p.Ativo);
}

Para desativar um Global Query Filter no Entity Framework Core, você pode usar o método 
IgnoreQueryFilters() em sua consulta

public void MinhaConsulta()
{
    // Desativando o filtro global temporariamente
    var produtos = Produtos.IgnoreQueryFilters().ToList();
}

É importante notar que o IgnoreQueryFilters() é aplicado apenas para a consulta em que é chamado. 

