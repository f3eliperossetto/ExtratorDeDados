using System;
using System.Collections.Generic;
using ExtratorDeDados.ModelosServico;
using System.Linq;
using static ExtratorDeDados.Enums.EnumsLeitor;

namespace ExtratorDeDados.Interfaces.Implementacoes
{
    public abstract class ManipuladorArquivoService<TRegistroArquivo> : IManipulador<TRegistroArquivo>
    {
        private readonly IList<ManipuladorComandos> comandos;
        private IList<TRegistroArquivo> registros;
        public ManipuladorArquivoService()
        {
            comandos = new List<ManipuladorComandos>();
            registros = new List<TRegistroArquivo>();
            ConfigurarMontagemArquivo();
        }
        public TRegistroArquivo RegistroAtual { get ; set ; }
        public IReadOnlyCollection<TRegistroArquivo> Registros => registros.ToArray();
        public IReadOnlyCollection<ManipuladorComandos> Comandos => comandos.ToArray();

        public void AdicionarComando(Predicate<string> pred, Action<string> metodo, ETipoRegistro tipo)
                   => comandos.Add(new ManipuladorComandos(pred, metodo, tipo));
        public void AdicionarComando(Predicate<string> pred, Action<string> metodo)
                  => comandos.Add(new ManipuladorComandos(pred, metodo, ETipoRegistro.Registro));

        public void AdicionarRegistro()  =>  registros.Add(RegistroAtual);
        public abstract void ConfigurarMontagemArquivo();

        public void ReiniciaObjeto() => RegistroAtual = Activator.CreateInstance<TRegistroArquivo>();

        public void ZerarRegistros()
        => registros = new List<TRegistroArquivo>();

    }
}
