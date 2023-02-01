using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

public class ApplicationContext : DbContext
{
  private readonly StreamWriter _writer = new StreamWriter("EFLOG.txt", append: true);

  public DbSet<Departamento> Departamentos { get; set; } = default!;
  public DbSet<Funcionario> Funcionarios { get; set; } = default!;
  public DbSet<Estado> Estados { get; set; } = default!;
  public DbSet<Governador> Governadores { get; set; } = default!;
  public DbSet<Cidade> Cidades { get; set; } = default!;

  #region Override Methods

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    const string connectionString = "Server=localhost;Database=DB_EFCourse;User Id=sa;Password=Pwd@1234!;TrustServerCertificate=True;";

    optionsBuilder
        .UseSqlServer(connectionString)
        .EnableSensitiveDataLogging() // Somente habilitar em modo DEBUG
        .EnableDetailedErrors() // Somente habilitar em modo DEBUG
        .LogTo(Console.Write, LogLevel.Information); // Somente habilitar em modo DEBUG

    // Interceptors 1
    // optionsBuilder
    //     .UseSqlServer(connectionString)
    //     .EnableSensitiveDataLogging() // Somente habilitar em modo DEBUG
    //     .EnableDetailedErrors() // Somente habilitar em modo DEBUG
    //     .LogTo(Console.Write, LogLevel.Information) // Somente habilitar em modo DEBUG
    //     .AddInterceptors(new TaggedQueryCommandInterceptor());

    // Retry EF
    // optionsBuilder
    //     .UseSqlServer(connectionString, options => options
    //         .MaxBatchSize(100)
    //         .EnableRetryOnFailure(maxRetryCount: 4, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null))
    //     .EnableSensitiveDataLogging() // Somente habilitar em modo DEBUG
    //     .EnableDetailedErrors(); // Somente habilitar em modo DEBUG, isso mostra os problemas de relacionamento

    // Log 3
    // optionsBuilder
    //     .UseSqlServer(connectionString)
    //     .LogTo(_writer.WriteLine, LogLevel.Information, DbContextLoggerOptions.LocalTime);

    // Log 2
    // optionsBuilder
    //     .UseSqlServer(connectionString)        
    //     .LogTo(Console.WriteLine, new[] { CoreEventId.ContextInitialized, RelationalEventId.CommandExecuted },
    //         LogLevel.Information,
    //         DbContextLoggerOptions.LocalTime);

    // Log 1 && Lazy Load
    // optionsBuilder
    //     .UseSqlServer(connectionString)        
    //     //.UseLazyLoadingProxies() // Metodo para utilizar LazyLoad do pacote dotnet add package Microsoft.EntityFrameworkCore.Proxies            
    //     .LogTo(Console.Write, LogLevel.Information);
  }

  public override void Dispose()
  {
    base.Dispose();
    _writer.Flush();
    _writer.Close();
    _writer.Dispose();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Collations
    // modelBuilder.UseCollation("SQL_Latin_General_CP1_CI_AI");

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
  }

  #endregion
}