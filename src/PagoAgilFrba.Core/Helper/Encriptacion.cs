using System.Security.Cryptography;
using System.Text;

namespace PagoAgilFrba.Core
{
    public static class Encriptacion
    {
        public static string EncrptarSHA256(string input)
        {
            SHA256 hash = SHA256.Create();

            // Convertir la cadena en un array de bytes y calcular hash
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Copiar cada elemento del array a un
            // StringBuilder en formato hexadecimal
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            } return sBuilder.ToString();
        }




    }
}
