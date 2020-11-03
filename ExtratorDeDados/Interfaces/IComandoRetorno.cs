using System.Collections.Generic;

using static ExtratorDeDados.Enums.EnumsLeitor;

namespace ExtratorDeDados.Interfaces
{
    public interface IComandoRetorno<T> : IComandoRetorno
    {
         T Retorno { get; set; }
    }
    public interface IComandoRetorno
    {
        EStatus Status { get; set; }
        bool LeituraRealizada { get; set; }
        List<string> Erros { get; set; }
        List<string> Alertas { get; set; }
        List<string> Informacoes { get; set; }
    }
}
