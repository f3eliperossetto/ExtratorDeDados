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
        ICollection<ManipuladorComandos> Comandos { get; }
        ICollection<T> Registros { get; }
        void ConfigurarMontagemArquivo();
        /// <summary>
        /// Adiciona um comando a lista de comandos para executar a leitura do arquivo
        /// </summary>
        /// <param name="verificaEntidadeLinha">Metodo que analisa os caracteres da linha, e verifica qual o tipo da mesma</param>
        /// <param name="metodoCapturaDados">Metodo que popula um modelo baseado na linha verificada</param>
        /// <param name="novaInstancia">Verifica se cria uma nova instancia do Objeto quando o mesmo é do tipo Pai</param>
        void AdicionarComando(Predicate<string> verificaEntidadeLinha, Action<string> metodoCapturaDados, ETipoRegistro novaInstancia);
        /// <summary>
        /// Adiciona um comando a lista de comandos para executar a leitura do arquivo
        /// </summary>
        /// <param name="verificaEntidadeLinha">Metodo que analisa os caracteres da linha, e verifica qual o tipo da mesma</param>
        /// <param name="metodoCapturaDados">Metodo que popula um modelo baseado na linha verificada</param>
        void AdicionarComando(Predicate<string> verificaEntidadeLinha, Action<string> metodoCapturaDados);
        void AdicionarRegistro();
        void ReiniciaObjeto();
        void ZerarRegistros();
    }
}
