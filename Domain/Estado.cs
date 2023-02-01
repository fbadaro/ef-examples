public class Estado
{
  public int Id { get; set; }

  public string Nome { get; set; } = default!;

  // Usando o FluentAPI
  public Governador Governador { get; set; } = new();

  ICollection<Cidade> Cidades { get; set; } = new List<Cidade>();

  public Estado()
  {

  }
}