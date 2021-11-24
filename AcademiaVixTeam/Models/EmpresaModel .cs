using System.ComponentModel.DataAnnotations;

namespace AcademiaVixTeam.Models
{
    public class EmpresaModel
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }

        public string Cnpj { get; set; }
    }
}