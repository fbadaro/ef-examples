using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MappingDepartamento : IEntityTypeConfiguration<Departamento>
{
  public void Configure(EntityTypeBuilder<Departamento> builder)
  {
    // Shadow Property
    builder
      .Property(x => x.Horario)
      .HasConversion(new TimeOnlyToDateTimeConverter());

    builder
      .Property<DateTime>("UltimaAtualizacao"); // Essa propriedade sera gerada e gerenciada pelo EF

    // Filtro Global para esta entidade
    builder
      .HasQueryFilter(x => !x.Excluido);

    // Enums
    builder
      .Property(x => x.EnumTestOne)
      .HasConversion(
        v => v.ToString(),
        v => (EnumTestOne)Enum.Parse(typeof(EnumTestOne), v));

    builder
      .Property(x => x.EnumTestTwo)
      .HasConversion(
        v => v.GetDisplayName(),
        v => (EnumTestTwo)Enum.Parse(typeof(EnumTestTwo), v!));

    builder
      .Property(x => x.EnumTestThree)
      .HasMaxLength(1)
      .IsUnicode(false)
      .HasConversion(
        v => v.GetDisplayNameFirstLetter(),
        v => EnumExtensions.GetValueFromDisplayName<EnumTestThree>(v!));

    builder
      .Property(x => x.EnumTestFour)
      .HasMaxLength(1)
      .IsUnicode(false)
      .HasConversion(
        v => v.ToString().Substring(0, 1),
        v => typeof(EnumTestFour).GetEnumValues().Cast<EnumTestFour>().First(e => e.ToString()[0] == v[0]));

    // Value Converter 1
    // builder
    //     .Property(x => x.Horario)
    //     .HasConversion(d => DateTime.Parse(d.ToString()), d => TimeOnly.FromDateTime(d));

    // Custom Value Converter 2
    // builder
    //     .Property(x => x.Horario)
    //     .HasConversion(new TimeOnlyToDateTimeConverter()); 

    // Sequences
    // modelBuilder.HasSequence("DEPARTAMENTO_SEQ", "CUSTOM_SEQ");
    // modelBuilder.Entity<Departamento>()
    //     .Property(x => x.Id)
    //     .HasDefaultValueSql("NEXT VALUE FOR CUSTOM_SEQ.DEPARTAMENTE_SEQ");

    // Indices
    // modelBuilder.Entity<Departamento>()
    //     .HasIndex(x => new { x.Descricao, x.Ativo })
    //     .HasDatabaseName("IDX_DEPARTAMENTO_ATIVO")
    //     .HasFilter("Descricao IS NOT NULL")
    //     .HasFillFactor(80)
    //     .IsUnique();

    // Schemas
    // modelBuilder.HasDefaultSchema("TBT_"); // Abreviacao do Banco
    // modelBuilder.Entity<Departamento>().ToTable("Departamento", "DXZ_");                               
  }
}