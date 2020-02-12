namespace ExtratorDeDados.Interfaces
{
   public interface IExtratorService<T>
    {
        IComandoRetorno Importar();
        IComandoRetorno<IManipulador<T>> CarregarDados(string caminhoArquivo);
    }
}
