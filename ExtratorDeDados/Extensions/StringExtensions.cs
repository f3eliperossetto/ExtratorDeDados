using System;
using System.Linq;


namespace ExtratorDeDados.Ext
{
   public static class StringExtensions
    {
        public static string CapturarString(this string value, int startIndex, int length)
        {
            return new string((value ?? string.Empty).Skip(startIndex).Take(length).ToArray());
        }
        public static double CapturarDouble(this string value, int startIndex, int length)
        {
            string valor = new string((value ?? string.Empty).Skip(startIndex).Take(length).ToArray());

            if (double.TryParse(valor, out double resultado))
            {
                return resultado;
            }

            return 0;
        }
        public static double CapturarDouble(this string value, int startIndex, int length, int quantidadesCasasDecimais)
        {
            string valor = new string((value ?? string.Empty).Skip(startIndex).Take(length).ToArray());

            if (double.TryParse(valor, out double resultado))
            {
                if (quantidadesCasasDecimais > 0)
                {
                    int divisao = 0;
                    for (int i = 1; i < quantidadesCasasDecimais; i++)
                    {
                        if (i == 1)
                            divisao = 100;
                        else
                            divisao = divisao * 10;

                    }
                    return resultado / divisao;
                }

                return resultado;
            }

            return 0;
        }
        public static int CapturarInt(this string value, int startIndex, int length)
        {
            string valor = new string((value ?? string.Empty).Skip(startIndex).Take(length).ToArray());

            if (int.TryParse(valor, out int resultado))
            {
                return resultado;
            }

            return 0;
        }
        public static decimal CapturarDecimal(this string value, int startIndex, int length)
        {
            string valor = new string((value ?? string.Empty).Skip(startIndex).Take(length).ToArray());

            if (decimal.TryParse(valor, out decimal resultado))
            {
                return resultado;
            }

            return 0;
        }
        public static DateTime? CapturarDateTime(this string value, int startIndex, int length)
        {
            string valor = new string((value ?? string.Empty).Skip(startIndex).Take(length).ToArray());

            if (DateTime.TryParse(valor, out DateTime resultado))
            {
                return resultado;
            }

            return null;
        }
       
    }
}
