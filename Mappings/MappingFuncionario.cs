using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MappingFuncionario : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        // Owned Types
        builder
            .OwnsOne(p => p.Endereco, e =>
            {
                e.Property(x => x.Logradouro).HasColumnName("Logradouro");
                e.Property(x => x.Numero).HasColumnName("Numero");
                e.Property(x => x.CEP).HasColumnName("CEP");
                e.Property(x => x.Complemento).HasColumnName("Complemento");
            });
    }
}