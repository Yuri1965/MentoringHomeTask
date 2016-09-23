using System;
using System.Linq;
using System.Security.Cryptography;

namespace ProfilingApplication
{

    class Program
    {
        private static string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt, int iterate)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            var passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;
        }

        private static string GeneratePasswordHashUsingSaltUpgrade(string passwordText, byte[] salt, int iterate)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                return Convert.ToBase64String(salt.Concat(hash).ToArray());
            }
        }

        static void Main(string[] args)
        {
            var pass = "zczbxbh7";
            var salt = "45678958asdfghty";
            var saltBytes = new System.Text.UTF8Encoding(false).GetBytes(salt);

            Console.WriteLine(GeneratePasswordHashUsingSalt(pass, saltBytes, 10000));

            Console.WriteLine(GeneratePasswordHashUsingSaltUpgrade(pass, saltBytes, 10000));
        }
    }
}
