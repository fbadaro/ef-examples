using Microsoft.EntityFrameworkCore;

public static class DataStrategies
{
  public static void ExecuteStrategy(ApplicationContext db)
  {
    var strategy = db.Database.CreateExecutionStrategy();

    // Quando o banco de dados estiver usando configurações de estrategias de resiliencia, sempre é bom ter o controle das transacoes.
    strategy.Execute(() =>
    {
      using var transaction = db.Database.BeginTransaction();

      db.Departamentos.Add(new Departamento
      {
        Descricao = "",
        Ativo = true,
        Excluido = false
      });

      db.SaveChanges();
      transaction.Commit();
    });
  }
}