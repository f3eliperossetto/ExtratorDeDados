using System.Linq;


namespace ExtratorDeDados.Ext
{
   public static class StringExt
    {
         public static string CapturarString(this string value, int startIndex, int length)
        {
            return new string((value ?? string.Empty).Skip(startIndex).Take(length).ToArray());
        }
    }
}
