namespace AcademiaVixTeam.Business
{
    public static class PessoalBusiness
    {
        public static bool ValidaExclusaoPessoalAtiva(string situacaoPessoal)
        {
            if (situacaoPessoal.Equals("Ativo"))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public static bool ValidaEditarPessoalInativa(string situacaoPessoal)
        {
            if (situacaoPessoal.Equals("Ativo"))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool ValidaQuantidadeFilhos(int quantidadeFilhosPessoal)
        {
            if (quantidadeFilhosPessoal >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool ValidaDataNascimento(DateTime dataNascimentoPessoal)
        {
            if (dataNascimentoPessoal >= new DateTime(1990, 1, 1))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
