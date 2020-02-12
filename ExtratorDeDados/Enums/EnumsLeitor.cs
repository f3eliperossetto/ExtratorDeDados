using System;
using System.Collections.Generic;
using System.Text;

namespace ExtratorDeDados.Enums
{
   public class EnumsLeitor
    {
        public enum EStatusImportacao
        {
            Nao_Importado,
            Importado,
            ImportadoComErro,
            EmAndamento
        }

        public enum ETipoRegistro
        {
            ObjetoPai,
            Registro,
        }
    }
}
