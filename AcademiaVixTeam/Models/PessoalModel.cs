using System.ComponentModel.DataAnnotations;

namespace AcademiaVixTeam.Models
{
    public class PessoalModel
    {
        [Key]
        public int Codigo { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int QuantidadeFilhos { get; set; }
        public decimal Salario { get; set; }
    }
}
