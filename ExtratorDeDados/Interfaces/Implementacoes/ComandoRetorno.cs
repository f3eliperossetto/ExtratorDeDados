using System.Collections.Generic;

namespace ExtratorDeDados.Interfaces.Implementacoes
{
    public class ComandoRetorno : IComandoRetorno
    {
        public Enums.EnumsLeitor.EStatus Status { get; set; }
        public bool LeituraRealizada { get  ; set ; }
        public List<string> Erros { get ; set; }
        public List<string> Alertas { get ; set ; }
        public List<string> Informacoes { get ; set ; }
    }

    public class ComandoRetorno<T> : IComandoRetorno<T>
    {
        public ComandoRetorno()
        {
            Erros = new List<string>(0);
            Alertas = new List<string>(0);
            Informacoes = new List<string>(0);
        }
        public Enums.EnumsLeitor.EStatus Status { get; set; }
        public T Retorno { get; set; }
        public bool LeituraRealizada { get; set; }
        public List<string> Erros { get; set; }
        public List<string> Alertas { get; set; }
        public List<string> Informacoes { get; set; }
    }
}
