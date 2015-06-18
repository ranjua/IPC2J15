using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ProyectoIPC2.Clases
{
    public class Cifrado
    {

        /// <summary>
        /// Clase para encriptar info
        /// </summary>
        /// <param name="strTexto">contraseña</param>
        /// <param name="strTexto2">llave</param>
        /// <returns></returns>
        public byte[] Encriptar(string strTexto, string strTexto2)
        {
            byte[] objKey = Encoding.UTF8.GetBytes(strTexto2);
            HMACSHA1 Llave = new HMACSHA1(objKey);
            try
            {
                string rehash = StringB(Llave.ComputeHash(Encoding.UTF8.GetBytes(strTexto)));
                for (int x = 0; x < 1000; x++)
                {
                    rehash = StringB(Llave.ComputeHash(Encoding.UTF8.GetBytes(rehash)));
                }
                byte[] Encripr = Llave.ComputeHash(Encoding.UTF8.GetBytes(rehash));
                return Encripr;
            }
            finally
            {
                Llave.Clear();
            }
        }

        public bool CompareByteArray(string arrayA, string arrayB)
        {
            if (arrayA.Length != arrayB.Length)
                return false;
            if (!arrayA.Equals(arrayB))
                return false;



            return true;
        }
        public string StringB(byte[] arrayA)
        {
            string s = "";
            for (int i = 0; i <= arrayA.Length - 1; i++)
            {
                s += "" + arrayA[i] + "-";
            }
            return s;
        }

    }
}