using ExtratorDeDados.Ext;


namespace TesteDados.Teste
{
    public class DadosBancarios
    {
        public static implicit operator DadosBancarios(string valor)
        {
            DadosBancarios cli = new DadosBancarios
            {
                Banco = valor.CapturarString(3, 10),
                Ag = valor.CapturarString(14, 4),
                Conta = valor.CapturarString(14, 4)
            };

            return cli;
        }

        public string Banco { get; set; }
        public string Ag { get; set; }
        public string Conta { get; set; }
    }
}