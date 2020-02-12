using ExtratorDeDados.Interfaces;
using ExtratorDeDados.Interfaces.Implementacoes;
using System.Linq;

namespace ExtratorDeDados.ModelosServico
{
    public  class ExtratorService<T> : IExtratorService<T>
    {
        private readonly IManipulador<T> _manipulador;
        private readonly IProcessamento<T> _processamento;
        private ExtratorService(IManipulador<T> manipulador)
        {
            _manipulador = manipulador;
        }
        private ExtratorService(IManipulador<T> manipulador, IProcessamento<T> processamento)
        {
            _manipulador = manipulador;
            _processamento = processamento;
        }

        public IComandoRetorno Importar()
        {
            IComandoRetorno retorno = new ComandoRetorno();

            foreach (T registro in _manipulador.Registros)
            {
                try
                {
                    _processamento.ProcessarRegistro(registro);
                }
                catch (System.Exception ex)
                {
                    retorno.Erros.Add(ex.Message);
                }
            }

            return retorno;
        }

        public IComandoRetorno<IManipulador<T>> CarregarDados(string caminhoArquivo)
        {
            IComandoRetorno<IManipulador<T>> resultado = new ComandoRetorno<IManipulador<T>>();

            try
            {
                if (_manipulador.Registros.Count > 0)
                    _manipulador.ZerarRegistros();

                string[] linhas = System.IO.File.ReadAllLines(caminhoArquivo);
                int cont = 0;
                foreach (string linhaArquivo in linhas)
                {
                    foreach (ManipuladorComandos comando in _manipulador.Comandos)
                    {
                        if (comando.Condicao(linhaArquivo))
                        {
                            try
                            {
                                if (comando.Tipo == Enums.EnumsLeitor.ETipoRegistro.ObjetoPai)
                                {
                                    _manipulador.ReiniciaObjeto();
                                    _manipulador.AdicionarRegistro();
                                }
                                comando.PopulaObjeto(linhaArquivo);
                            }
                            catch (System.Exception ex)
                            {
                                resultado.Erros.Add($"Erro ao Capturar a linha:{cont}-{linhaArquivo}  Detalhes Erro: {ex.Message}");
                            }
                        }
                    }
                    cont++;
                }
            }
            catch (System.Exception ex)
            {
                resultado.Erros.Add(ex.Message);
            }

            if (resultado.Erros.Count == 0 && resultado.Alertas.Count == 0)
            {
                resultado.Sucesso = true;
                resultado.Informacoes.Add("Arquivo lido com sucesso!");
            }
            else
                resultado.Sucesso = false;



            resultado.Retorno = _manipulador;

            return resultado;
        }


        public static class ExtratorServiceFactory
        {
            public static ExtratorService<T> ObterSomenteLeitura(IManipulador<T> manipulador)
            {
                return new ExtratorService<T>(manipulador);
            }
            public static ExtratorService<T> ObterLeoturaImportacao(IManipulador<T> manipulador, IProcessamento<T> processamento)
            {
                return new ExtratorService<T>(manipulador, processamento);
            }
        }
    }
}
