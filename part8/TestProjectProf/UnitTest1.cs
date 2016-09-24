using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;

namespace TestProjectProfiling
{
    [TestClass]
    public class UnitTest1
    {
        public static string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt, bool useManagedSha1, int iterate)
        {
            //здесь в зависимости от флага useManagedSha1 вызываем СВОЮ или СИСТЕМНУЮ реализацию класса Rfc2898DeriveBytes
            DeriveBytes pbkdf2 = useManagedSha1 ? (DeriveBytes)new MyRfc2898DeriveBytes(passwordText, salt, iterate) : new Rfc2898DeriveBytes(passwordText, salt, iterate);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            var passwordHash = Convert.ToBase64String(hashBytes);
            return passwordHash;
        }

        [TestMethod]
        public void TestMethod2()
        {
            var pass = "zczbxbh7";
            var salt = "45678958asdfghty";
            var saltBytes = new UTF8Encoding(false).GetBytes(salt.ToCharArray(), 0, 16);

            string hashPass = "";
            string tmpPass = "";
            
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();

            //вызовем GC для чистоты эксперимента
            GC.Collect();
            // Begin timing
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                tmpPass = pass + i.ToString();
                hashPass = GeneratePasswordHashUsingSalt(tmpPass, saltBytes, true, 10000);
            }
            // Stop timing
            stopwatch.Stop();
            // Write result
            Console.WriteLine("Time elapsed UPGRADE method code: {0}", stopwatch.Elapsed);
            Console.WriteLine(hashPass);

            //сбросим счетчик
            stopwatch.Reset();
            //вызовем GC для чистоты эксперимента
            GC.Collect();
            // Begin timing
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                tmpPass = pass + i.ToString();
                hashPass = GeneratePasswordHashUsingSalt(tmpPass, saltBytes, false, 10000);
            }
            // Stop timing
            stopwatch.Stop();
            // Write result
            Console.WriteLine("Time elapsed ORIGIN method code: {0}", stopwatch.Elapsed);
            Console.WriteLine(hashPass);
        }
    }
}
