using ExtratorDeDados.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TesteDados.Teste;
using static ExtratorDeDados.ModelosServico.ExtratorService<TesteDados.Teste.ArquivoDadosBancarios>;

namespace TesteDados
{
    [TestClass]
    public class TesteArquivo
    {
       private readonly IExtratorService<ArquivoDadosBancarios> extratorService;
        public TesteArquivo()
        {
            extratorService = ExtratorServiceFactory.ObterServico<ManipuladorDadosBancariosServico>();
        }
        [TestMethod]
        public void CarregarDadosArquivoComAlertas()
        {
            var resultadoComando = extratorService.CarregarDados($@"{System.IO.Directory.GetCurrentDirectory()}\TesteAlertas.TXT");
            resultadoComando.Status.Should().Be(ExtratorDeDados.Enums.EnumsLeitor.EStatus.ComAlertas);
            resultadoComando.Retorno.Registros.Count.Should().Be(3);
            resultadoComando.Retorno.Registros.ElementAt(2).Financeiro[1].Banco.Should().Contain("NuBank");
        }
        [TestMethod]
        public void CarregarDadosArquivoComErros()
        {
            var resultadoComando = extratorService.CarregarDados($@"{System.IO.Directory.GetCurrentDirectory()}");
            resultadoComando.Status.Should().Be(ExtratorDeDados.Enums.EnumsLeitor.EStatus.Erro);
        }

        [TestMethod]
        public void CarregarDadosArquivoComSucesso()
        {
            var resultadoComando = extratorService.CarregarDados($@"{System.IO.Directory.GetCurrentDirectory()}\TesteSucesso.TXT");
            resultadoComando.Status.Should().Be(ExtratorDeDados.Enums.EnumsLeitor.EStatus.Sucesso);
            resultadoComando.Retorno.Registros.Count.Should().Be(3);
            resultadoComando.Retorno.Registros.ElementAt(2).Financeiro[1].Banco.Should().Contain("NuBank");
        }
    }
}
