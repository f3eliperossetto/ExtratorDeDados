using ExtratorDeDados.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteDados.Teste;
using static ExtratorDeDados.ModelosServico.ExtratorService<TesteDados.Teste.RegistroArquivo>;

namespace TesteDados
{
    [TestClass]
    public class TesteArquivo
    {
        [TestMethod]
        public void CarregarDadosArquivo()
        {
            IExtratorService<RegistroArquivo> srv = ExtratorServiceFactory.ObterSomenteLeitura(new Arquivo());
            IComandoRetorno<IManipulador<RegistroArquivo>> ff = srv.CarregarDados(@"C:\tmp\Teste.TXT");
        }
        [TestMethod]
        public void ImportarDadosArquivo()
        {
            IExtratorService<RegistroArquivo> srv = ExtratorServiceFactory.ObterLeoturaImportacao(new Arquivo(), new Processamento());
            IComandoRetorno<IManipulador<RegistroArquivo>> ff = srv.CarregarDados(@"C:\tmp\Teste.TXT");
            srv.Importar();
        }
    }
}
