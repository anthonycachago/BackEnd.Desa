

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Core.Models;

public class BcaClieEntity:ModelBase
{
    [Column("clie_cod_tcli")]
    public int ClieCodTcli { get; set; }

    [Column("clie_num_clie")]
    public int? ClieNumClie { get; set; }

    [Required]
    [Column("clie_cod_ofic")]
    public int ClieCodOfic { get; set; }

    [Required]
    [Column("clie_cod_tide")]
    [StringLength(1)]
    public string ClieCodTide { get; set; } = null!;

    [Required]
    [Column("clie_ide_clie")]
    [StringLength(13)]
    public string ClieIdeClie { get; set; } = null!;

    [Column("clie_ape_clie")]
    [StringLength(60)]
    public string? ClieApeClie { get; set; }

    [Column("clie_nom_clie")]
    [StringLength(30)]
    public string? ClieNomClie { get; set; }

    [Column("clie_fec_nac")]
    public DateTime? ClieFecNac { get; set; }

    [Column("clie_cod_sect")]
    public int? ClieCodSect { get; set; }

    [Column("clie_dir_domi")]
    [StringLength(55)]
    public string? ClieDirDomi { get; set; }

    [Column("clie_fec_uac")]
    public DateTime? ClieFecUac { get; set; }

    [Required]
    [Column("clie_fec_ingr")]
    public DateTime ClieFecIngr { get; set; }

    [Column("clie_fec_sali")]
    public DateTime? ClieFecSali { get; set; }

    [Column("clie_ema_clie")]
    [StringLength(80)]
    public string? ClieEmaClie { get; set; }

    [Required]
    [Column("clie_nat_juri")]
    public short ClieNatJuri { get; set; }

    [Required]
    [Column("clie_est_clie")]
    public short ClieEstClie { get; set; }

    [Column("clie_cal_clie")]
    public int? ClieCalClie { get; set; }

    [Column("clie_rep_lega")]
    [StringLength(50)]
    public string? ClieRepLega { get; set; }

    [Column("clie_ide_repr")]
    [StringLength(13)]
    public string? ClieIdeRepr { get; set; }

    [Column("clie_tide_repr")]
    [StringLength(1)]
    public string? ClieTideRepr { get; set; }

    [Column("clie_cod_pais")]
    public int? ClieCodPais { get; set; }

    [Column("clie_cod_usua")]
    public int? ClieCodUsua { get; set; }

    [Column("clie_cod_ofct")]
    public int? ClieCodOfct { get; set; }

    [Column("clie_ref_dire")]
    [StringLength(100)]
    public string? ClieRefDire { get; set; }

    [Column("clie_cod_cocu")]
    public int? ClieCodCocu { get; set; }

    [Column("clie_est_adic")]
    public short? ClieEstAdic { get; set; }

    [Column("clie_cod_disc")]
    public short? ClieCodDisc { get; set; }

    [Column("clie_cod_tviv")]
    public int? ClieCodTviv { get; set; }

    [Column("clie_val_vivi")]
    public decimal? ClieValVivi { get; set; }

    [Column("clie_num_carg")]
    public short? ClieNumCarg { get; set; }

    [Column("clie_cod_tcsr")]
    public int? ClieCodTcsr { get; set; }

    [Column("clie_cod_auid")]
    public int? ClieCodAuid { get; set; }

    [Column("clie_fec_asan")]
    public DateTime? ClieFecAsan { get; set; }

    [Column("clie_cod_prof")]
    public int? ClieCodProf { get; set; }

    [Column("clie_ban_peps")]
    public short? ClieBanPeps { get; set; }

    [Column("clie_cod_tvin")]
    public int? ClieCodTvin { get; set; }

    [Column("clie_ban_grup")]
    public short ClieBanGrup { get; set; } = 0;

    [Column("clie_cod_grup")]
    public int ClieCodGrup { get; set; } = 0;

    [Column("clie_cod_tres")]
    public int? ClieCodTres { get; set; }

    [Column("clie_pai_resi")]
    public int? CliePaiResi { get; set; }

    [Column("clie_ban_pdpe")]
    public short ClieBanPdpe { get; set; } = 0;

    [Column("clie_hue_dact")]
    [StringLength(10)]
    public string? ClieHueDact { get; set; }
}
