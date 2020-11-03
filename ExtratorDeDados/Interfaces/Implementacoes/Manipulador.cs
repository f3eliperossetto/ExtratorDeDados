using ExtratorDeDados.ModelosServico;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static ExtratorDeDados.Enums.EnumsLeitor;

namespace ExtratorDeDados.Interfaces.Implementacoes
{
    public abstract class Manipulador<TRegistroArquivo> : IManipulador<TRegistroArquivo>
    {
        protected Manipulador()
        {
            Comandos = new Collection<ManipuladorComandos>(new List<ManipuladorComandos>());
            Registros = new Collection<TRegistroArquivo>(new List<TRegistroArquivo>());
        }
        public TRegistroArquivo RegistroAtual { get ; set ; }
        public ICollection<TRegistroArquivo> Registros { get; private set; }
        public ICollection<ManipuladorComandos> Comandos { get; }
        public void AdicionarComando(Predicate<string> verificaEntidadeLinha, Action<string> metodoCapturaDados, ETipoRegistro novaInstancia)
                   => Comandos.Add(new ManipuladorComandos(verificaEntidadeLinha, metodoCapturaDados, novaInstancia));
        public void AdicionarComando(Predicate<string> verificaEntidadeLinha, Action<string> metodoCapturaDados)
                  => Comandos.Add(new ManipuladorComandos(verificaEntidadeLinha, metodoCapturaDados, ETipoRegistro.Registro));
        public void AdicionarRegistro()  =>  Registros.Add(RegistroAtual);   
        public void ReiniciaObjeto() => RegistroAtual = Activator.CreateInstance<TRegistroArquivo>();
        public void ZerarRegistros()  => Registros = new List<TRegistroArquivo>();
        public abstract void ConfigurarMontagemArquivo();
    }
}
