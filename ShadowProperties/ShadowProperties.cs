using Microsoft.EntityFrameworkCore;

public static class ShadowProperties
{
  public static void InserWithShadowProperty(ApplicationContext db)
  {
    var departamento = new Departamento
    {
      Descricao = "Descricao Shadow",
      Ativo = true,
      Excluido = false,
      Horario = TimeOnly.FromDateTime(DateTime.Now),
      Status = Status.Enviado
    };

    db.Departamentos.Add(departamento);
    db.Entry(departamento).Property("UltimaAtualizacao").CurrentValue = DateTime.Now;
    db.SaveChanges();
  }

  public static void FindWithShadowProperty(ApplicationContext db)
  {
    var foo = DateTime.Now.AddDays(-1);

    var departamentos = db.Departamentos.AsNoTracking().Where(x => EF.Property<DateTime>(x, "UltimaAtualizacao") > DateTime.Now.AddDays(-1));

    foreach (var item in departamentos)
    {
      Console.WriteLine("------------------------------------");
      Console.WriteLine($"Departamento: {item.Descricao} \nHorario: {item.Horario.ToString("HH:mm")}");

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