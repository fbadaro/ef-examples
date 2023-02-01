using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MappingEstado : IEntityTypeConfiguration<Estado>
{
  public void Configure(EntityTypeBuilder<Estado> builder)
  {
    builder
        .HasOne(e => e.Governador)
        .WithOne(e => e.Estado)
        .HasForeignKey<Governador>(g => g.EstadoId);
  }
}