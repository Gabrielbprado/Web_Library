using System.ComponentModel.DataAnnotations;

namespace Web_Library.Models
{
    public class EmprestimosModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo Recebedor é Obrigatório")]
        public string? Recebedor { get; set; }
        [Required(ErrorMessage = "O Campo Livro é Obrigatório")]
        public string? Livro { get; set; }
        [Required(ErrorMessage = "O Campo Fornecedor é Obrigatório")]
        public string Fornecedor{ get; set; }
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
    }
}
