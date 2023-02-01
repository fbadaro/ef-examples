public class Governador
{
  public int Id { get; set; }

  public string Nome { get; set; } = default!;

  // Usando o FluentAPI
  public int EstadoId { get; set; }

  // Usando o FluentAPI
  public Estado Estado { get; set; } = new();

  public Governador()
  {

  }
}