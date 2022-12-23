public class Cidade
{
    public int Id { get; set; }

    public string Nome { get; set; } = default!;

    public Estado Estado { get; set; } = new();

    public Cidade()
    {

    }
}