using System.ComponentModel.DataAnnotations;

namespace Web_Library.Models
{
    public class EmprestimosModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Recebedor { get; set; }
        [Required]
        public string? Livro { get; set; }
        [Required]
        public string Fornecedor{ get; set; }
        [Required]
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
    }
}
