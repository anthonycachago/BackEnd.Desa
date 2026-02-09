using BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infrastructure.DataBase.ConfigShema;


public class BcaUsuaConfig : IEntityTypeConfiguration<BcaUsuaEntity>
{
    public void Configure(EntityTypeBuilder<BcaUsuaEntity> builder)
    {
        builder.ToTable("bcausua");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("usua_cod_usua")
            .HasColumnType("int")
            .ValueGeneratedOnAdd(); // importante para IDENTITY

        // Mapear columnas restantes
        builder.Property(x => x.UsuaCodEmpl)
            .HasColumnName("usua_cod_empl")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.UsuaCodPerf)
            .HasColumnName("usua_cod_perf")
            .HasColumnType("char(2)")
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(x => x.UsuaNomUsua)
            .HasColumnName("usua_nom_usua")
            .HasColumnType("char(25)")
            .HasMaxLength(25)
            .IsRequired();

        builder.Property(x => x.UsuaPasswd)
            .HasColumnName("usua_passwd")
           .HasColumnType("varbinary(64)")
            .IsRequired(false);

        builder.Property(x => x.UsuaFecUac)
            .HasColumnName("usua_fec_uac")
            .HasColumnType("date")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired(false);

        builder.Property(x => x.UsuaNumAgen)
            .HasColumnName("usua_num_agen")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(x => x.UsuaBanUsua)
            .HasColumnName("usua_ban_usua")
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(x => x.UsuaImpPred)
            .HasColumnName("usua_imp_pred")
            .HasColumnType("char(100)")
            .HasMaxLength(100)
            .HasDefaultValue(string.Empty)
            .IsRequired(false);
    }
}