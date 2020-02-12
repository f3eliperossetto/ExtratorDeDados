using System;
using System.Collections.Generic;
using System.Text;
using ExtratorDeDados.Modelos;

namespace ExtratorDeDados.Interfaces.Implementacoes
{
    public class ComandoRetorno : IComandoRetorno
    {
        public ComandoRetorno()
        {
            Erros = new List<string>(0);
            Alertas = new List<string>(0);
            Informacoes = new List<string>(0);
        }
        public bool Sucesso { get  ; set ; }
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
        public T Retorno { get; set; }
        public bool Sucesso { get; set; }
        public List<string> Erros { get; set; }
        public List<string> Alertas { get; set; }
        public List<string> Informacoes { get; set; }
    }
}
