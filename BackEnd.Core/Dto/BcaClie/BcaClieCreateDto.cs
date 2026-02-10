

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Core.Dto.BcaClie;

public class BcaClieCreateDto
{
   
    public int ClieCodTcli { get; set; }

 
    public int? ClieNumClie { get; set; }

    [Required]
    
    public int ClieCodOfic { get; set; }

    [Required]
  
    public string ClieCodTide { get; set; } = null!;

    [Required]
    
    public string ClieIdeClie { get; set; } = null!;

   
    public string? ClieApeClie { get; set; }

   
    public string? ClieNomClie { get; set; }

    
    public DateTime? ClieFecNac { get; set; }

 
    public int? ClieCodSect { get; set; }

    
    public string? ClieDirDomi { get; set; }

 
    public DateTime? ClieFecUac { get; set; }

    [Required]

    public DateTime ClieFecIngr { get; set; }


    public DateTime? ClieFecSali { get; set; }


    public string? ClieEmaClie { get; set; }

    [Required]
   
    public short ClieNatJuri { get; set; }

    [Required]

    public short ClieEstClie { get; set; }

 
    public int? ClieCalClie { get; set; }

 
    public string? ClieRepLega { get; set; }


    public string? ClieIdeRepr { get; set; }


    public string? ClieTideRepr { get; set; }

 
    public int? ClieCodPais { get; set; }


    public int? ClieCodUsua { get; set; }


    public int? ClieCodOfct { get; set; }



    public string? ClieRefDire { get; set; }

 
    public int? ClieCodCocu { get; set; }

   
    public short? ClieEstAdic { get; set; }

    
    public short? ClieCodDisc { get; set; }

   
    public int? ClieCodTviv { get; set; }


    public decimal? ClieValVivi { get; set; }


    public short? ClieNumCarg { get; set; }

 
    public int? ClieCodTcsr { get; set; }

 
    public int? ClieCodAuid { get; set; }

   
    public DateTime? ClieFecAsan { get; set; }


    public int? ClieCodProf { get; set; }


    public short? ClieBanPeps { get; set; }


    public int? ClieCodTvin { get; set; }


    public short ClieBanGrup { get; set; } = 0;

   
    public int ClieCodGrup { get; set; } = 0;

   
    public int? ClieCodTres { get; set; }

    public int? CliePaiResi { get; set; }

    
    public short ClieBanPdpe { get; set; } = 0;

 
    public string? ClieHueDact { get; set; }
}
