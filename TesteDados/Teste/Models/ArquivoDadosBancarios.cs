using ExtratorDeDados.Ext;

using System.Collections.Generic;

using TesteDados.Teste.Models;

namespace TesteDados.Teste
{
    public class ArquivoDadosBancarios
    {
        public ArquivoDadosBancarios()
        {
            Financeiro = new List<DadosBancarios>();
            Documento = new DadosDocumento();
        }

        public void Popular(string valor)
        {
            Nome = valor.CapturarString(3, 23);
            Idade = valor.CapturarString(27, 2);
            DataNascimento = valor.CapturarString(29, 8);
        }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string DataNascimento { get; set; }
        public DadosDocumento Documento { get; set; }
        public List<DadosBancarios> Financeiro { get; set; }
    }
}