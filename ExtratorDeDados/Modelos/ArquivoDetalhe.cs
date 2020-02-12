using System;
using System.Collections.Generic;
using System.Text;

namespace ExtratorDeDados.Modelos
{
   public class ArquivoDetalhe
    {
        public ArquivoDetalhe(string caminhoCompleto)
        {
            CaminhoCompleto = caminhoCompleto;
            Processado = false;
            Reprocessa = false;
        }

        public string CaminhoCompleto { get; set; }
        public bool Processado { get; set; }
        public bool Reprocessa { get; set; }
    }
}
