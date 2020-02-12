using ExtratorDeDados.Interfaces.Implementacoes;
using System;
using System.Collections.Generic;
using System.Text;
using static ExtratorDeDados.Enums.EnumsLeitor;

namespace ExtratorDeDados.Interfaces
{
  public  interface IProcessamento<T> 
    {
        EStatusImportacao StatusImportacao { get; set; }
        IComandoRetorno ProcessarRegistro(T registro);
    }
}
