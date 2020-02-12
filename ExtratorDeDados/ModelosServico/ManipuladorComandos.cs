using System;
using static ExtratorDeDados.Enums.EnumsLeitor;

namespace ExtratorDeDados.ModelosServico
{
    public class ManipuladorComandos
    {
        public ManipuladorComandos(Predicate<string> condicao, Action<string> populaObjeto, ETipoRegistro tipo)
        {
            Condicao = condicao;
            PopulaObjeto = populaObjeto;
            Tipo = tipo;
        }

        public Predicate<string> Condicao { get; set; }
        public Action<string> PopulaObjeto { get; set; }
        public ETipoRegistro  Tipo { get; set; }
    }
}
