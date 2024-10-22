using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Dominio.Entidades
{
    public class Veiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;} = default!;

        [Required]
        [StringLength(150)]
        public string Nome {get;set;} = default!;

        [StringLength(150)]
        public string Marca {get; set;} = default!;

        [StringLength(10)]
        public int Ano {get; set;} = default!;
    }
}