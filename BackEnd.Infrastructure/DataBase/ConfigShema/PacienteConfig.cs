using Microsoft.EntityFrameworkCore;
using BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infrastructure.DataBase.ConfigShema;

public class PacienteConfig : IEntityTypeConfiguration<PacienteEntity>
{
    public void Configure(EntityTypeBuilder<PacienteEntity> builder)
    {
        builder.ToTable("paciente");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("bigint")
            .ValueGeneratedOnAdd(); // importante para IDENTITY

        builder.Property(x => x.Nombre)
            .HasColumnName("nombre")
            .HasColumnType("VARCHAR(100)")
            .IsRequired(false);

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasColumnType("VARCHAR(100)")
            .IsRequired(false);

    }
}
