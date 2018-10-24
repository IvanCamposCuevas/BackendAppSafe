using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace BackSafe.Negocio
{
    class Encriptador
    {
        public static string IV = "qo1lc3sjd8zpt9cx";
        public static string key = "ow7dxys8glfor9tnc2ansdfo1etkfjcv";

        public static string Encrypt (string descrypt)
        {
            byte[] textoBytes = ASCIIEncoding.ASCII.GetBytes(descrypt);
            AesCryptoServiceProvider encDec = new AesCryptoServiceProvider();
            encDec.BlockSize = 128;
            encDec.KeySize = 256;
            encDec.Key = ASCIIEncoding.ASCII.GetBytes(key);
            encDec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            encDec.Padding = PaddingMode.PKCS7;
            encDec.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = encDec.CreateEncryptor(encDec.Key, encDec.IV);

            byte[] enc = icrypt.TransformFinalBlock(textoBytes, 0, textoBytes.Length);
            icrypt.Dispose();

            return Convert.ToBase64String(enc);
        }

        public static string Decrypt(string encrypted)
        {
            byte[] encBytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider encDec = new AesCryptoServiceProvider();
            encDec.BlockSize = 128;
            encDec.KeySize = 256;
            encDec.Key = ASCIIEncoding.ASCII.GetBytes(key);
            encDec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            encDec.Padding = PaddingMode.PKCS7;
            encDec.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = encDec.CreateDecryptor(encDec.Key, encDec.IV);

            byte[] dec = icrypt.TransformFinalBlock(encBytes, 0, encBytes.Length);
            icrypt.Dispose();

            return ASCIIEncoding.ASCII.GetString(dec);
        }
    }
}
