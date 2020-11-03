using ExtratorDeDados.Interfaces;
using ExtratorDeDados.Interfaces.Implementacoes;

using System;
using System.IO;
using System.Linq;

namespace ExtratorDeDados.ModelosServico
{
    public  class ExtratorService<TipoArquivo> : IExtratorService<TipoArquivo>
    {
        private readonly IManipulador<TipoArquivo> _manipulador;
        private ExtratorService(IManipulador<TipoArquivo> manipulador)
        {
            _manipulador = manipulador;
        }

        public IComandoRetorno<IManipulador<TipoArquivo>> CarregarDados(string caminhoArquivo)
        {
            IComandoRetorno<IManipulador<TipoArquivo>> resultado = new ComandoRetorno<IManipulador<TipoArquivo>>();

            try
            {
                if (_manipulador.Registros.Count > 0) _manipulador.ZerarRegistros();

                int cont = 0;
                foreach (string linhaArquivo in File.ReadAllLines(caminhoArquivo))
                {
                    var comando = _manipulador.Comandos.FirstOrDefault(cmd => cmd.Condicao(linhaArquivo));
                    if (comando != null)
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
                            resultado.Erros.Add($"Erro ao Capturar a linha:{cont} - {linhaArquivo}  Detalhes Erro: {ex.Message}");
                        }
                    }
                    else
                    {
                        resultado.Alertas.Add($"Linha {cont} - {linhaArquivo}, não mapeada para nenhum modelo");
                    }
                    cont++;
                }
            }
            catch (Exception ex)
            {
                resultado.Erros.Add(ex.Message);
            }

           return ConfiguraStatusFinal(resultado);
        }

        private IComandoRetorno<IManipulador<TipoArquivo>> ConfiguraStatusFinal(IComandoRetorno<IManipulador<TipoArquivo>> resultado)
        {
            if (!resultado.Erros.Any() && !resultado.Alertas.Any())
            {
                resultado.Status = Enums.EnumsLeitor.EStatus.Sucesso;
                resultado.LeituraRealizada = true;
                resultado.Informacoes.Add("Arquivo lido com sucesso!");
            }
            else if (!resultado.Erros.Any() && resultado.Alertas.Any())
            {
                resultado.Status = Enums.EnumsLeitor.EStatus.ComAlertas;
                resultado.LeituraRealizada = true;
                resultado.Informacoes.Add("Arquivo lido com alertas!");
            }
            else
            {
                resultado.LeituraRealizada = false;
                resultado.Status = Enums.EnumsLeitor.EStatus.Erro;
            }

            resultado.Retorno = _manipulador;
            return resultado;
        }

        public static class ExtratorServiceFactory
        {
            public static IExtratorService<TipoArquivo> ObterServico<TipoServico>() where TipoServico : IManipulador<TipoArquivo>
            {
                return new ExtratorService<TipoArquivo>(Activator.CreateInstance<TipoServico>());
            }
        }
    }
}
