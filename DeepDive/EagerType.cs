using Microsoft.EntityFrameworkCore;

public static class EagerType
{
    public static void EagerTypeLoad(ApplicationContext db)
    {
        SeedData.SeedDataInitial(db);

        // Traz o resultado em uma unica consulta baseada na propriedade de navegacao, ver: Explosao Cartesiana em Banco de Dados
        var departamentos = db
            .Departamentos
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
}