using System;
using System.Security.Cryptography;
using System.Text;


namespace CriptoStringMD5
{
    class CriptoMD5
    {
        public string RetornarMD5(string Senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return RetonarHash(md5Hash, Senha);
            }
        }

        public bool CompararMD5(string senhaGuardada, string Senha_MD5)
        {
            string senha = RetornarMD5(senhaGuardada);
            if (VerificarHash(Senha_MD5, senha))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string RetonarHash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }

            return sBuilder.ToString();
        }

        private bool VerificarHash(string input, string hash)
        {
            StringComparer compara = StringComparer.OrdinalIgnoreCase;

            if (0 == compara.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
