using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Presentation.Mvc.Helper
{
    public static class SecurityHelper
    {


        public static string CriptografarSenha( string senha)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(senha);
                byte[] hash = mySHA256.ComputeHash(bytes);
                string hashString = string.Empty;
                hashString += System.Text.Encoding.UTF8.GetString(hash);
                return hashString;
            }

        }
    }
}
