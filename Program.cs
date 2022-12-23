using Microsoft.EntityFrameworkCore;

using var db = new ApplicationContext();

// EagerType.EagerTypeLoad(db);
// ExplicityType.ExplicityTypeLoad(db);
// LazyLoadType.LazyLoadLoad(db); 

Helpers.HealthCheckDB(db);
Helpers.GenerateScript(db);
SeedData.ResetDatabase(db);

// ShadowProperties.InserWithShadowProperty(db);
// ShadowProperties.FindWithShadowProperty(db);

// var departamentos = db.Departamentos.AsNoTracking().Where(x => x.Status == Status.Enviado).ToList();

// foreach (var item in departamentos)
// {
//     Console.WriteLine("------------------------------------");
//     Console.WriteLine($"Departamento: {item.Descricao} \nHorario: {item.Horario.ToString("HH:mm")}");

//     if (item.Funcionarios?.Any() ?? false)
//     {
//         foreach (var funcionario in item.Funcionarios)
//         {
//             Console.WriteLine($"\tFuncionario: {funcionario.Nome}");
//         }
//     }
//     else
//     {
//         Console.WriteLine("\tNao existe funcionario para este Departamento");
//     }
// }