using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cibergestion.Controllers
{
    public class funcionarios
    {
        [Key]
        [Display(Name = "Código")]
        public int id{ get; set; }

        [Display(Name = "")]
        public int codigo_fun { get; set; }
        
        [Required]
        [MaxLength(40)]
        [Display(Name = "Nome")]
        public string nome{ get; set; }
        
        [Required]
        [MaxLength (14)]
        [MinLength(13)]
        [Display(Name = "Telefone")]
        
        [Phone(ErrorMessage ="(99)99999-9999")]
        public string telefone{ get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public string tipo{ get; set; }
    }
}
