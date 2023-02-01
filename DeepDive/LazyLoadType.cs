public static class LazyLoadType
{
  public static void LazyLoadLoad()
  {
    using var db = new ApplicationContext();

    SeedData.SeedDataInitial(db);

    // Os dados relacionados sao carregados sobre demanda pelo banco de dados com a propriedade e acessada.
    var departamentos = db
        .Departamentos
        .ToList();

    foreach (var item in departamentos)
    {
      Console.WriteLine("------------------------------------");
      Console.WriteLine($"Departamento: {item.Descricao}");

      if (item.Funcionarios?.Any() ?? false)
      {
        foreach (var funcionario in item.Funcionarios)
        {
          Console.WriteLine($"\tFuncionario: {funcionario.Nome}");
        }
      }
      else
      {
        Console.WriteLine("\tNao existe funcionario para este Departamento");
      }
    }
  }
}