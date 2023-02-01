using Microsoft.EntityFrameworkCore;

public static class Helpers
{
  public static void HealthCheckDB(ApplicationContext db)
  {
    if (db.Database.CanConnect())
      Console.WriteLine("Posso me conectar");
    else
      Console.WriteLine("Nao posso me conectar");
  }

  public static void GenerateScript(ApplicationContext db)
  {
    Console.WriteLine(db.Database.GenerateCreateScript());
  }

  public static void GetAllMigrationsInExecTime(ApplicationContext db)
  {
    var migrations = db.Database.GetMigrations().ToList();
    migrations.ForEach(x => Console.WriteLine(x));
  }

  public static void ApplyMigrationsInExecTime(ApplicationContext db)
  {
    // Nao utilizar este metodo de qualquer forma, analisar realmente sua necessidade de utilizacao        
    db.Database.Migrate();
  }

  public static void GetPendingMigrations(ApplicationContext db)
  {
    // dotnet ef migrations add initial --context ApplicationContext        

    var pendingMigrations = db.Database.GetPendingMigrations().ToList();
    pendingMigrations.ForEach(x => Console.WriteLine(x));
  }
}