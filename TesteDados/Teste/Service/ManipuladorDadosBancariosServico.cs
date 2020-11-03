using ExtratorDeDados.Enums;
using ExtratorDeDados.Ext;
using ExtratorDeDados.Interfaces.Implementacoes;

namespace TesteDados.Teste
{
    public class ManipuladorDadosBancariosServico : Manipulador<ArquivoDadosBancarios>
    {

        private const string TIPOREGISTRO_FINANCEIRO = "02";
        private const string TIPOREGISTRO_DOCUMENTO = "01";
        private const string TIPOREGISTRO_CLIENTE = "00";
        public ManipuladorDadosBancariosServico()
        {
            ConfigurarMontagemArquivo();
        }
        public override void ConfigurarMontagemArquivo()
        {
            AdicionarComando(EhTipoRegistroCliente, PopulaCliente, EnumsLeitor.ETipoRegistro.ObjetoPai);
            AdicionarComando(EhTipoRegistroDocumento, PopulaDocumento);
            AdicionarComando(EhTipoRegistroFinanceiro,PopulaFinanceiro);
        }

        private bool EhTipoRegistroFinanceiro(string tipoRegistro) => tipoRegistro.CapturarString(0, 2) == TIPOREGISTRO_FINANCEIRO;
        private bool EhTipoRegistroDocumento(string tipoRegistro) => tipoRegistro.CapturarString(0, 2) == TIPOREGISTRO_DOCUMENTO;
        private bool EhTipoRegistroCliente(string tipoRegistro) => tipoRegistro.CapturarString(0, 2) == TIPOREGISTRO_CLIENTE;
        private void PopulaCliente(string linha) => RegistroAtual.Popular(linha);
        private void PopulaDocumento(string linha) => RegistroAtual.Documento.Popular(linha);
        private void PopulaFinanceiro(string linha) => RegistroAtual.Financeiro.Add(linha);

    }
}
