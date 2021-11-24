using System.ComponentModel.DataAnnotations;

namespace AcademiaVixTeam.Models
{
    public class PessoalModel
    {
        [Key]
        public int Codigo { get; set; }
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Quantidade de Filhos")]
        public int QuantidadeFilhos { get; set; }
        [Display(Name = "Salario")]
        public decimal Salario { get; set; }

        [Display(Name = "Situação")]
        public string Situacao { get; set; }
    }
}
