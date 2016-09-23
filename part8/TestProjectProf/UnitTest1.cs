using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace TestProjectProf
{
    [TestClass]
    public class UnitTest1
    {
        private static byte[] GeneratePasswordHashUsingSaltUpgrade6(Rfc2898DeriveBytes generatorHash)
        {
            return generatorHash.GetBytes(20);
        }

        private static string GeneratePasswordHashUsingSaltUpgrade5(Rfc2898DeriveBytes generatorHash)
        {
            return Convert.ToBase64String(generatorHash.GetBytes(20));
        }

        private static void GeneratePasswordHashUsingSaltUpgrade4(Rfc2898DeriveBytes generatorHash, out string result)
        {
            result = Convert.ToBase64String((generatorHash.Salt.ToArray()).Concat((generatorHash.GetBytes(20)).ToArray()).ToArray());
        }

        private static string GeneratePasswordHashUsingSaltUpgrade3(string password, byte[] salt, int iterate)
        {
            return Convert.ToBase64String(salt.Concat((new Rfc2898DeriveBytes(password, salt, iterate)).GetBytes(20)).ToArray());
        }

        private static byte[] GeneratePasswordHashUsingSaltUpgrade2(string password, byte[] salt, int iterate)
        {
            return (new Rfc2898DeriveBytes(password, salt, iterate)).GetBytes(20);
        }

        private static byte[] GeneratePasswordHashUsingSaltUpgrade1(byte[] password, byte[] salt, int iterate)
        {
            return (new Rfc2898DeriveBytes(password, salt, iterate)).GetBytes(20);
        }

        private static string GeneratePasswordHashUsingSaltUpgrade(string password, byte[] salt, int iterate)
        {
            return Convert.ToBase64String(salt.Concat((new Rfc2898DeriveBytes(password, salt, iterate)).GetBytes(20)).ToArray());
        }



        //private static byte[] GeneratePasswordHashUsingSalt_4(string passwordText, byte[] salt, int iterate)
        //{
        //    return (new Rfc2898DeriveBytes(passwordText, salt, iterate)).GetBytes(20);
        //}

        //private static string GeneratePasswordHashUsingSalt_3(string passwordText, byte[] salt, int iterate)
        //{
        //    var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
        //    byte[] hash = pbkdf2.GetBytes(20);
        //    return Convert.ToBase64String(salt.Concat(hash.ToArray()).ToArray());
        //}

        private string GeneratePasswordHashUsingSalt_2(string passwordText, byte[] salt, int iterate)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);

            byte[] hash = new byte[20];

            for (int i = 0; i < 20; i++)
            {
                // вот тут параллельная обработка нужна или потоки?
                hash[i] = pbkdf2.GetBytes(1).ToArray()[0];
            }

            return Convert.ToBase64String(salt.Concat(hash.ToArray()).ToArray());
        }

        private string GeneratePasswordHashUsingSalt_4(string passwordText, byte[] salt, int iterate)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, 1000);
            byte[] hash = new byte[20];

            for (int i = 0; i < 10; i++)
            {
                hash = pbkdf2.GetBytes(20);


                //if (i == 9)
                //    hash = pbkdf2.GetBytes(20);
                //else
                //    pbkdf2.GetBytes(20);
            }

            return Convert.ToBase64String(salt.Concat(hash.ToArray()).ToArray());
        }

        //оригинальный метод
        private string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt, int iterate)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            var passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;
        }

        //private static string GeneratePasswordHashUsingSalt_1(string passwordText, byte[] salt, int iterate)
        //{
        //    var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, 1);
        //    byte[] hash = new byte[20];

        //    //hash = pbkdf2.GetBytes(20);

        //    for (int i = 1; i < iterate; i++)
        //    {
        //        hash = pbkdf2.GetBytes(20);
        //        pbkdf2.Reset();
        //    }

        //    byte[] hashBytes = new byte[36];
        //    Array.Copy(salt, 0, hashBytes, 0, 16);
        //    Array.Copy(hash, 0, hashBytes, 16, 20);

        //    var passwordHash = Convert.ToBase64String(hashBytes);

        //    return passwordHash;
        //}

        [TestMethod]
        public void TestMethod2()
        {
            var pass = "zczbxbh7";
            var salt = "45678958asdfghty";
            var saltBytes = new System.Text.UTF8Encoding(false).GetBytes(salt.ToCharArray(), 0, 16);
            var passBytes = new System.Text.UTF8Encoding(false).GetBytes(pass);
            
            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();
            //Rfc2898DeriveBytes pbkdf2;
            string hashPass = "";
            byte[] hashPassBytes = new byte[20];

            string tmpPass = "";

            stopwatch.Reset();
            // Begin timing.
            stopwatch.Start();
            for (int i = 0; i < 100; i++)
            {
                tmpPass = pass + i.ToString();
                //hashPass = GeneratePasswordHashUsingSalt_1(tmpPass, saltBytes, 10000);
                hashPass = GeneratePasswordHashUsingSalt_2(tmpPass, saltBytes, 10000);
            }
            // Stop timing.
            stopwatch.Stop();
            // Write result.
            Console.WriteLine("Time elapsed origin 1: {0}", stopwatch.Elapsed);
            Console.WriteLine(hashPass);

            stopwatch.Reset();
            // Begin timing.
            stopwatch.Start();
            for (int i = 0; i < 100; i++)
            {
                tmpPass = pass + i.ToString();
                hashPass = GeneratePasswordHashUsingSalt(tmpPass, saltBytes, 10000);
            }
            // Stop timing.
            stopwatch.Stop();
            // Write result.
            Console.WriteLine("Time elapsed origin: {0}", stopwatch.Elapsed);
            Console.WriteLine(hashPass);


            //stopwatch.Reset();
            //pbkdf2 = new Rfc2898DeriveBytes(pass, saltBytes, 10000);
            //hashPass = "";
            //// Begin timing.
            //stopwatch.Start();

            //for (int i = 0; i < 1000; i++)
            //{
            //    tmpPass = pass + i.ToString();
            //    pbkdf2 = new Rfc2898DeriveBytes(pass, saltBytes, 10000);
            //    hashPassBytes = GeneratePasswordHashUsingSaltUpgrade6(pbkdf2);
            //    //pbkdf2.Reset();
            //}

            //// Stop timing.
            //stopwatch.Stop();
            //// Write result.
            //Console.WriteLine("Time elapsed upgrade 6: {0}", stopwatch.Elapsed);
            //hashPass = Convert.ToBase64String(saltBytes.Concat(hashPassBytes).ToArray());
            //Console.WriteLine(hashPass);

            //stopwatch.Reset();
            //pbkdf2 = new Rfc2898DeriveBytes(pass, saltBytes, 10000);
            //hashPass = "";
            //// Begin timing.
            //stopwatch.Start();

            //for (int i = 0; i < 100; i++)
            //{
            //    hashPass = GeneratePasswordHashUsingSaltUpgrade5(pbkdf2);
            //    pbkdf2.Reset();
            //}

            //// Stop timing.
            //stopwatch.Stop();
            //// Write result.
            //Console.WriteLine("Time elapsed upgrade 5: {0}", stopwatch.Elapsed);
            //Console.WriteLine(hashPass);


            //stopwatch.Reset();
            //using (pbkdf2 = new Rfc2898DeriveBytes(pass, saltBytes, 10000))
            //{
            //    // Begin timing.
            //    stopwatch.Start();
            //    string hashPass5 = "";
            //    GeneratePasswordHashUsingSaltUpgrade4(pbkdf2, out hashPass5);
            //    // Stop timing.
            //    stopwatch.Stop();
            //    // Write result.
            //    Console.WriteLine("Time elapsed upgrade 4: {0}", stopwatch.Elapsed);
            //    Console.WriteLine(hashPass5);

            //    pbkdf2.Dispose();
            //}

            //stopwatch.Reset();
            //// Begin timing.
            //stopwatch.Start();
            //var hashPass4 = GeneratePasswordHashUsingSaltUpgrade3(pass, saltBytes, 10000);
            //// Stop timing.
            //stopwatch.Stop();
            //// Write result.
            //Console.WriteLine("Time elapsed upgrade 3: {0}", stopwatch.Elapsed);
            //Console.WriteLine(hashPass4);

            //stopwatch.Reset();
            //// Begin timing.
            //stopwatch.Start();
            //var hashPass3 = GeneratePasswordHashUsingSaltUpgrade2(pass, saltBytes, 10000);
            //// Stop timing.
            //stopwatch.Stop();
            //// Write result.
            //Console.WriteLine("Time elapsed upgrade 2: {0}", stopwatch.Elapsed);
            //Console.WriteLine(Convert.ToBase64String(hashPass3));

            //stopwatch.Reset();
            //// Begin timing.
            //stopwatch.Start();
            //var hashPass1 = GeneratePasswordHashUsingSaltUpgrade1(passBytes, saltBytes, 10000);
            //// Stop timing.
            //stopwatch.Stop();
            //// Write result.
            //Console.WriteLine("Time elapsed upgrade 1: {0}", stopwatch.Elapsed);
            //Console.WriteLine(Convert.ToBase64String(hashPass1));

            //stopwatch.Reset();
            //// Begin timing.
            //stopwatch.Start();
            //var hashPass = GeneratePasswordHashUsingSaltUpgrade(passBytes, saltBytes, 10000);
            //// Stop timing.
            //stopwatch.Stop();
            //// Write result.
            //Console.WriteLine("Time elapsed upgrade: {0}", stopwatch.Elapsed);
            //Console.WriteLine(hashPass);

        }

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var pass = "zczbxbh7";
        //    var salt = "45678958asdfghty";
        //    var saltBytes = new System.Text.UTF8Encoding(false).GetBytes(salt);

        //    // Create new stopwatch.
        //    Stopwatch stopwatch = new Stopwatch();
        //    // Begin timing.
        //    stopwatch.Start();

        //    var hashPass = GeneratePasswordHashUsingSalt(pass, saltBytes, 10000);

        //    // Stop timing.
        //    stopwatch.Stop();
        //    // Write result.
        //    Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

        //    Console.WriteLine(hashPass);
        //}

        }
    }
