using ExtratorDeDados.Enums;
using ExtratorDeDados.Ext;
using ExtratorDeDados.Interfaces.Implementacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDados.Teste
{
    public class RegistroArquivo
    {
        public void Popular(string valor)
        {
            this.Nome = valor.CapturarString(3, 23);
            this.Idade = valor.CapturarString(27, 2);
            this.DataNascimento = valor.CapturarString(29, 8);
            this.Financeiro = new List<DadosBancarios>();
            Documento = new DadosDocumento();
        }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string DataNascimento { get; set; }
        public DadosDocumento Documento { get; set; }
        public List<DadosBancarios> Financeiro { get; set; }
    }
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
    public class DadosBancarios
    {
        public static implicit operator DadosBancarios(string valor)
        {
            DadosBancarios cli = new DadosBancarios();
            cli.Banco = valor.CapturarString(3, 10);
            cli.Ag = valor.CapturarString(14, 4);
            cli.Conta = valor.CapturarString(14, 4);

            return cli;
        }

        public string Banco { get; set; }
        public string Ag { get; set; }
        public string Conta { get; set; }
    }

    public class Arquivo : ManipuladorArquivoService<RegistroArquivo>
    {

        public override void ConfigurarMontagemArquivo()
        {
            AdicionarComando((string tipoRegistro) => { return tipoRegistro.CapturarString(0, 2) == "00"; }, PopulaCliente, EnumsLeitor.ETipoRegistro.ObjetoPai);
            AdicionarComando((string tipoRegistro) => { return tipoRegistro.CapturarString(0, 2) == "01"; }, PopulaDocumento);
            AdicionarComando((string tipoRegistro) => { return tipoRegistro.CapturarString(0, 2) == "02"; }, PopulaFinanceiro);
        }

        private void PopulaCliente(string linha) => RegistroAtual.Popular(linha);
        private void PopulaDocumento(string linha) => RegistroAtual.Documento.Popular(linha);
        private void PopulaFinanceiro(string linha) => RegistroAtual.Financeiro.Add(linha);

    }
}
