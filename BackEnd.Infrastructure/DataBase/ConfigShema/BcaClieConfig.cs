

using BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Infrastructure.DataBase.ConfigShema;


public class BcaClieConfig : IEntityTypeConfiguration<BcaClieEntity>
{
    public void Configure(EntityTypeBuilder<BcaClieEntity> builder)
    {

        builder.ToTable("bcaclie");

      
        builder.HasKey(x => x.Id)
            .HasName("pk_bcaclie");

        builder.Property(x => x.Id)
            .HasColumnName("clie_cod_clie")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ClieCodTcli)
            .HasColumnName("clie_cod_tcli")
            .IsRequired();

        builder.Property(x => x.ClieCodOfic)
            .HasColumnName("clie_cod_ofic")
            .IsRequired();

        builder.Property(x => x.ClieCodTide)
            .HasColumnName("clie_cod_tide")
            .HasColumnType("char(1)")
            .IsRequired();

        builder.Property(x => x.ClieIdeClie)
            .HasColumnName("clie_ide_clie")
            .HasColumnType("char(13)")
            .IsRequired();

        builder.Property(x => x.ClieFecIngr)
            .HasColumnName("clie_fec_ingr")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.ClieNatJuri)
            .HasColumnName("clie_nat_juri")
            .IsRequired();

        builder.Property(x => x.ClieEstClie)
            .HasColumnName("clie_est_clie")
            .IsRequired();

        // Campos opcionales
    
        builder.Property(x => x.ClieNumClie)
            .HasColumnName("clie_num_clie");

        builder.Property(x => x.ClieApeClie)
            .HasColumnName("clie_ape_clie")
            .HasColumnType("char(60)");

        builder.Property(x => x.ClieNomClie)
            .HasColumnName("clie_nom_clie")
            .HasColumnType("char(30)");

        builder.Property(x => x.ClieFecNac)
            .HasColumnName("clie_fec_nac")
            .HasColumnType("date");

        builder.Property(x => x.ClieCodSect)
            .HasColumnName("clie_cod_sect");

        builder.Property(x => x.ClieDirDomi)
            .HasColumnName("clie_dir_domi")
            .HasColumnType("char(55)");

        builder.Property(x => x.ClieFecUac)
            .HasColumnName("clie_fec_uac")
            .HasColumnType("datetime");

        builder.Property(x => x.ClieFecSali)
            .HasColumnName("clie_fec_sali")
            .HasColumnType("date");

        builder.Property(x => x.ClieEmaClie)
            .HasColumnName("clie_ema_clie")
            .HasColumnType("char(80)");

        builder.Property(x => x.ClieCalClie)
            .HasColumnName("clie_cal_clie");

        builder.Property(x => x.ClieRepLega)
            .HasColumnName("clie_rep_lega")
            .HasColumnType("varchar(50)");

        builder.Property(x => x.ClieIdeRepr)
            .HasColumnName("clie_ide_repr")
            .HasColumnType("char(13)");

        builder.Property(x => x.ClieTideRepr)
            .HasColumnName("clie_tide_repr")
            .HasColumnType("char(1)");

        builder.Property(x => x.ClieCodPais)
            .HasColumnName("clie_cod_pais");

        builder.Property(x => x.ClieCodUsua)
            .HasColumnName("clie_cod_usua");

        builder.Property(x => x.ClieCodOfct)
            .HasColumnName("clie_cod_ofct");

        builder.Property(x => x.ClieRefDire)
            .HasColumnName("clie_ref_dire")
            .HasColumnType("char(100)");

        builder.Property(x => x.ClieCodCocu)
            .HasColumnName("clie_cod_cocu");

        builder.Property(x => x.ClieEstAdic)
            .HasColumnName("clie_est_adic");

        builder.Property(x => x.ClieCodDisc)
            .HasColumnName("clie_cod_disc");

        builder.Property(x => x.ClieCodTviv)
            .HasColumnName("clie_cod_tviv");

        builder.Property(x => x.ClieValVivi)
            .HasColumnName("clie_val_vivi")
            .HasPrecision(15, 2);

        builder.Property(x => x.ClieNumCarg)
            .HasColumnName("clie_num_carg");

        builder.Property(x => x.ClieCodTcsr)
            .HasColumnName("clie_cod_tcsr");

        builder.Property(x => x.ClieCodAuid)
            .HasColumnName("clie_cod_auid");

        builder.Property(x => x.ClieFecAsan)
            .HasColumnName("clie_fec_asan")
            .HasColumnType("date");

        builder.Property(x => x.ClieCodProf)
            .HasColumnName("clie_cod_prof");

        builder.Property(x => x.ClieBanPeps)
            .HasColumnName("clie_ban_peps");

        builder.Property(x => x.ClieCodTvin)
            .HasColumnName("clie_cod_tvin");

        builder.Property(x => x.ClieBanGrup)
            .HasColumnName("clie_ban_grup")
            .HasDefaultValue((short)0);

        builder.Property(x => x.ClieCodGrup)
            .HasColumnName("clie_cod_grup")
            .HasDefaultValue(0);

        builder.Property(x => x.ClieCodTres)
            .HasColumnName("clie_cod_tres");

        builder.Property(x => x.CliePaiResi)
            .HasColumnName("clie_pai_resi");

        builder.Property(x => x.ClieBanPdpe)
            .HasColumnName("clie_ban_pdpe")
            .HasDefaultValue((short)0);

        builder.Property(x => x.ClieHueDact)
            .HasColumnName("clie_hue_dact")
            .HasColumnType("char(10)");

       
        // Índices y restricciones
    
        builder.HasIndex(x => x.ClieIdeClie)
            .IsUnique()
            .HasDatabaseName("uc_bcaclie");

        builder.HasIndex(x => new
        {
            x.ClieCodTcli,
            x.ClieNumClie,
            x.ClieCodOfic
        })
        .IsUnique()
        .HasDatabaseName("uc_bcaclie_1");



    }
}