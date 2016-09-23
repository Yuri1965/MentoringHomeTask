using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace ProfilingApplication
{
    public class PasswordHashGenerator
    {
        private const int COUNT_ITERATION_DEFAULT = 1000;
        private const int MIN_HASH_SIZE = 16;
        private const int MIN_SALT_SIZE = 8;
        private const int MIN_PASS_SIZE = 8;

        private string inputPassword = "";
        private int iterationCount;
        private byte[] salt;

        private Rfc2898DeriveBytes pbkdf2;
        private static PasswordHashGenerator instance;

        private PasswordHashGenerator()
        {
            iterationCount = COUNT_ITERATION_DEFAULT;
            pbkdf2 = new Rfc2898DeriveBytes(inputPassword, MIN_SALT_SIZE, iterationCount);
            salt = pbkdf2.Salt;
        }

        public static PasswordHashGenerator GetInstance()
        {
            if (instance == null)
            {
                instance = new PasswordHashGenerator();
            }

            return instance;
        }

        public static PasswordHashGenerator GetInstance(string passwordText, string salt, int iterate)
        {
            if (instance == null)
            {
                instance = new PasswordHashGenerator();
            }

            bool resetGenerator = false;
            bool newGenerator = false;

            if (!instance.Salt.Equals(salt, StringComparison.Ordinal))
            {
                instance.Salt = salt;
                instance.pbkdf2.Salt = instance.salt;
                resetGenerator = true;
            }
            if (instance.iterationCount != iterate)
            {
                instance.IterationCount = iterate;
                instance.pbkdf2.IterationCount = instance.iterationCount;
                resetGenerator = true;
            }
            if (!instance.inputPassword.Equals(passwordText, StringComparison.Ordinal))
            {
                instance.InputPassword = passwordText;
                resetGenerator = true;
                newGenerator = true;
            }

            if (newGenerator)
            {
                instance.pbkdf2 = new Rfc2898DeriveBytes(instance.inputPassword, instance.salt, instance.iterationCount);
                resetGenerator = false;
            }

            if (resetGenerator)
            {
                instance.pbkdf2.Reset();
            }

            return instance;
        }

        public int IterationCount
        {
            get { return iterationCount; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Value has to be more than 0");

                iterationCount = value;
            }
        }

        public string Salt
        {
            get { return System.Text.Encoding.UTF8.GetString(salt, 0, salt.Length); }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Value can't be NULL");
                if (value.Length < 8)
                    throw new ArgumentException("The size value has to be more than 8");

                salt = new System.Text.UTF8Encoding(false).GetBytes(value);
            }
        }

        public string InputPassword
        {
            get { return System.Text.Encoding.UTF8.GetString(salt, 0, salt.Length); }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Value can't be NULL");
                if (value.Length < 8)
                    throw new ArgumentException("The size value has to be more than 8");

                salt = new System.Text.UTF8Encoding(false).GetBytes(value);
            }
        }


    }
}
