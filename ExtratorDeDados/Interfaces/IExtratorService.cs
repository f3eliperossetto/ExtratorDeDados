namespace ExtratorDeDados.Interfaces
{
   public interface IExtratorService<T>
    {
        IComandoRetorno<IManipulador<T>> CarregarDados(string caminhoArquivo);
    }
}
