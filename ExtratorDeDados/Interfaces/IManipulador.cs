using ExtratorDeDados.ModelosServico;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static ExtratorDeDados.Enums.EnumsLeitor;

namespace ExtratorDeDados.Interfaces
{
    public interface IManipulador<T> 
    {
        [JsonIgnore]
        T RegistroAtual { get; set; }
        [JsonIgnore]
        IReadOnlyCollection<ManipuladorComandos> Comandos { get; }
        IReadOnlyCollection<T> Registros { get; }
        void ConfigurarMontagemArquivo();
        void AdicionarComando(Predicate<string> pred, Action<string> metodo, ETipoRegistro novaInstancia);
        void AdicionarComando(Predicate<string> pred, Action<string> metodo);
        void AdicionarRegistro();
        void ReiniciaObjeto();
        void ZerarRegistros();
    }
}
