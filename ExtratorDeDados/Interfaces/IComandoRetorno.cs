using ExtratorDeDados.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtratorDeDados.Interfaces
{
    public interface IComandoRetorno<T> : IComandoRetorno
    {
         T Retorno { get; set; }
    }
    public interface IComandoRetorno
    {
        bool Sucesso { get; set; }
        List<string> Erros { get; set; }
        List<string> Alertas { get; set; }
        List<string> Informacoes { get; set; }
    }
}
