public static class ExplicityType
{
    public static void ExplicityTypeLoad()
    {
        using var db = new ApplicationContext();

        SeedData.SeedDataInitial(db);

        // Traz o resultado do relacionamento somente quando é solicitado via regra de negocio        
        var departamentos = db
            .Departamentos
            .ToList();

        // Caso nao seja utilizado o .ToList() na query, o retorno será um AsEnumerable e deixará o DataReader aberto, o que 
        // ocasionara numa excecao, para resolver este problema podemos fazer de 2 formas.

        // 1 - Colocar o ToList() na coleção para o EF efetuar de fato a consulta e carregar os resultados para a memoria de forma antecipada
        // 2 - Habilitar o MultipleActiveResultSets=true na string de conexao com o banco de dados

        foreach (var item in departamentos)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Departamento: {item.Descricao}");

            // Forcando o carregamento da entidade relacionada
            if (item.Id == 2)
            {
                //db.Entry(item).Collection(x => x.Funcionarios).Load();
                db.Entry(item).Collection(x => x.Funcionarios).Query().Where(x => x.Id > 1).ToList();

                foreach (var funcionario in item.Funcionarios)
                {
                    Console.WriteLine($"\tFuncionario: {funcionario.Nome}");
                }
            }
        }
    }
}