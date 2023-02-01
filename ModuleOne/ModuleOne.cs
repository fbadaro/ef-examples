using Microsoft.EntityFrameworkCore;

public static class ModuleOne
{
  public static void TagQueries(ApplicationContext db)
  {
    SeedData.SeedDataInitial(db);

    var departamentos = db
        .Departamentos
        .TagWith("Eu estou evnaindo um comentario para o servidor")
        .Include(x => x.Funcionarios)
        .ToList();

    foreach (var item in departamentos)
    {
      Console.WriteLine("------------------------------------");
      Console.WriteLine($"Departamento: {item.Descricao}");

      if (item.Funcionarios?.Any() ?? false)
      {
        foreach (var nome in item.Funcionarios)
        {
          Console.WriteLine($"\tFuncionario: {nome}");
        }
      }
      else
      {
        Console.WriteLine("\tNao existe funcionario para este Departamento");
      }
    }
  }

  public static void ParametrizedQueries(ApplicationContext db)
  {
    SeedData.SeedDataInitial(db);

    var departamentos = db
        .Departamentos
        .FromSqlRaw("select * from departamentos")
        .ToList();

    foreach (var item in departamentos)
    {
      Console.WriteLine("------------------------------------");
      Console.WriteLine($"Departamento: {item.Descricao}");

      if (item.Funcionarios?.Any() ?? false)
      {
        foreach (var nome in item.Funcionarios)
        {
          Console.WriteLine($"\tFuncionario: {nome}");
        }
      }
      else
      {
        Console.WriteLine("\tNao existe funcionario para este Departamento");
      }
    }
  }

  public static void DesignedQueries(ApplicationContext db)
  {
    SeedData.SeedDataInitial(db);

    var departamentos = db
        .Departamentos
        .Where(x => x.Id > 0)
        .Select(p => new { p.Descricao, Funcionarios = p.Funcionarios.Select(x => x.Nome) })
        .ToList();

    foreach (var item in departamentos)
    {
      Console.WriteLine("------------------------------------");
      Console.WriteLine($"Departamento: {item.Descricao}");

      if (item.Funcionarios?.Any() ?? false)
      {
        foreach (var nome in item.Funcionarios)
        {
          Console.WriteLine($"\tFuncionario: {nome}");
        }
      }
      else
      {
        Console.WriteLine("\tNao existe funcionario para este Departamento");
      }
    }
  }

  public static void IgnoreGlobalFilters(ApplicationContext db)
  {
    SeedData.SeedDataInitial(db);

    var departamentos = db
        .Departamentos
        .IgnoreQueryFilters() // Ignora os filtros globais
        .Include(x => x.Funcionarios);

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

  public static void ExecuteSQL()
  {
    using var db1 = new ApplicationContext();

    var dbparam = "test";

    // 1 Opcao    
    db1.Database.ExecuteSqlRaw("update departamente set descricao ={0} where id = 1", dbparam);

    // 2 Opcao
    db1.Database.ExecuteSqlInterpolated($"update departamente set descricao ={dbparam} where id = 1");
  }
}