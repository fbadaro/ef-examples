public static class SeedData
{
    public static void EnsureCreatedAndDeleted(ApplicationContext db)
    {
        db.Database.EnsureCreated();
    }

    public static void GapEnsureCreatedAndDeleted()
    {
        using var db1 = new ApplicationContext();
        // using var db2 = new ApplicationContextCidade();

        db1.Database.EnsureCreated();
        // db2.Database.EnsureCreated();

        // Error: O EnsureCreated nao ira criar as tabelas se qualquer tabela ja existir no banco, para resolver esta questao devemos forcar a criacao.
        // var databaseCreator = db2.GetService<IRelationalDatabaseCreator>();
        // databaseCreator.CreateTables();
    }

    public static void ResetDatabase(ApplicationContext db)
    {
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        SeedDataInitial(db);
    }

    public static void SeedDataInitial(ApplicationContext db)
    {
        if (!db.Departamentos.Any())
        {
            db.Departamentos.AddRange(
                new Departamento
                {
                    Descricao = "Descricao 1",
                    Ativo = true,
                    Excluido = true,
                    Status = Status.Enviado,
                    Horario = TimeOnly.FromDateTime(DateTime.Now),
                    Funcionarios = new List<Funcionario>
                    {
                        new Funcionario {
                            Nome = "Camila da Silva Badaro",
                            CPF = "99999999911",
                            RG = "999999998",
                            Endereco = new Endereco {
                                CEP = "09720478",
                                Complemento = "",
                                Logradouro = "Rua 1",
                                Numero = 10
                            }
                        },
                    }
                },
                new Departamento
                {
                    Descricao = "Descricao 2",
                    Ativo = true,
                    Excluido = false,
                    Status = Status.Enviado,
                    Horario = TimeOnly.FromDateTime(DateTime.Now),
                    Funcionarios = new List<Funcionario>
                    {
                        new Funcionario {
                            Nome = "Fabio Badaro",
                            CPF = "99999999900",
                            RG = "999999998",
                            Endereco = new Endereco {
                                CEP = "09720478",
                                Complemento = "",
                                Logradouro = "Rua 2",
                                Numero = 10
                            }
                        },

                        new Funcionario {
                            Nome = "Bel Badaro",
                            CPF = "99999999922",
                            RG = "999999998",
                            Endereco = new Endereco {
                                CEP = "09720478",
                                Complemento = "",
                                Logradouro = "Rua 3",
                                Numero = 10
                            }
                        },
                    }
                }
            );

            db.SaveChanges();
            db.ChangeTracker.Clear();
        }
    }
}