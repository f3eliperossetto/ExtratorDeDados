using ExtratorDeDados.Enums;
using ExtratorDeDados.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDados.Teste
{
    public class Processamento : IProcessamento<RegistroArquivo>
    {
        public EnumsLeitor.EStatusImportacao StatusImportacao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IComandoRetorno ProcessarRegistro(RegistroArquivo registro)
        {
            throw new NotImplementedException();
        }
    }
}
