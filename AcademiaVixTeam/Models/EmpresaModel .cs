namespace NovoProj.Models
{
    public class EmpresaModel
    {
        public int Codigo { get; set; }

        public string? Nome { get; set; }

        public bool ShowNome => !string.IsNullOrEmpty(Nome);

        public string? nomeFantasia { get; set; }

        public bool ShownomeFantasia => !string.IsNullOrEmpty(nomeFantasia);

        public int Cnpj { get; set; }
    }
}