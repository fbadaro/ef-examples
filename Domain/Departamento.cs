public enum Status
{
  Enviado,
  Cancelado
}

public class Departamento
{
  public int Id { get; set; }

  public string Descricao { get; set; } = default!;

  public bool Ativo { get; set; }

  public bool Excluido { get; set; }

  public TimeOnly Horario { get; set; }

  public Status Status { get; set; }

  public EnumTestOne EnumTestOne { get; set; } = EnumTestOne.OptionA;

  public EnumTestTwo EnumTestTwo { get; set; } = EnumTestTwo.OptionA;

  public EnumTestThree EnumTestThree { get; set; } = EnumTestThree.OptionA;

  public EnumTestFour EnumTestFour { get; set; } = EnumTestFour.AOption;

  public List<Funcionario> Funcionarios { get; set; } = new();

  // Quando utilizado com o UseLazyLoadingProxies e necessario alterar a assinatura para virtual é assim  EF
  // se encarrega de carregar os dados quando esta propriedade for acessada.

  // Existe outra maneira de fazer essa implementacao sem a necessidade de alterar a configuracao do ApplicationContext
  // e mudar a assinatura da propriedade, que é utilizar a interface ILazyLoader
  // public virtual List<Funcionario> Funcionarios { get; set; } = new();

  public Departamento()
  {

  }
}