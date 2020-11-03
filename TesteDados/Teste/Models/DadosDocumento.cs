using ExtratorDeDados.Ext;

namespace TesteDados.Teste.Models
{
    public class DadosDocumento
    {
        public void Popular(string valor)
        {
            Cpf = valor.CapturarString(3, 11);
            Rg = valor.CapturarString(15, 9);

        }
        public string Cpf { get; set; }
        public string Rg { get; set; }
    }
}
