public class Funcionario
{
  public int Id { get; set; }

  public string Nome { get; set; } = default!;

  public string CPF { get; set; } = default!;

  public string RG { get; set; } = default!;

  public int DepartamentoId { get; set; }

  public Departamento Departamento { get; set; } = new();

  public Endereco Endereco { get; set; } = new();

  // Explicacao na entidade relacionada.
  // public virtual Departamento Departamento { get; set; } = new();

  public Funcionario()
  {

  }
}

// Utilizando para um VO OwnedType
public class Endereco
{
  public string Logradouro { get; set; } = default!;

  public int Numero { get; set; }

  public string CEP { get; set; } = default!;

  public string Complemento { get; set; } = default!;

  public Endereco()
  {

  }
}