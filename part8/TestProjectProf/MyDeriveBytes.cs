using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace TestProjectProfiling
{
    //код класса портирован из System.Security.Cryptography.Rfc2898DeriveBytes (убран лишний код, который не относится к решению задачи)
    public class MyRfc2898DeriveBytes : DeriveBytes
    {
        private byte[] m_buffer;
        private byte[] m_salt;
        private HMACSHA1 m_hmacsha1;
        private uint m_iterations;
        private uint m_block;
        private int m_startIndex;
        private int m_endIndex;

        public byte[] Salt
        {
            get
            {
                return (byte[])this.m_salt.Clone();
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (value.Length < 8)
                    throw new ArgumentException();
                this.m_salt = (byte[])value.Clone();
                this.Initialize();
            }
        }

        public MyRfc2898DeriveBytes(string password, byte[] salt, int iterations)
            : this(new UTF8Encoding(false).GetBytes(password), salt, iterations)
        {
        }

        //основной момент ускорения генерации хеша от пароля в реализации этого конструктора(см. комментарий ниже)
        public MyRfc2898DeriveBytes(byte[] password, byte[] salt, int iterations)
        {
            this.Salt = salt;
            this.m_iterations = (uint)iterations;

            // Передаём в конструктор HMACSHA1 вторым параметром true, чтобы использовалась managed-реализация 
            // SHA1. Работает НАМНОГО быстрее.
            this.m_hmacsha1 = new HMACSHA1(password, true);
            this.Initialize();
        }

        public override byte[] GetBytes(int cb)
        {
            if (cb <= 0)
                throw new ArgumentOutOfRangeException("cb");

            byte[] numArray1 = new byte[cb];
            int dstOffsetBytes = 0;
            int byteCount = this.m_endIndex - this.m_startIndex;
            if (byteCount > 0)
            {
                if (cb >= byteCount)
                {
                    Array.Copy(this.m_buffer, this.m_startIndex, numArray1, 0, byteCount);
                    this.m_startIndex = this.m_endIndex = 0;
                    dstOffsetBytes += byteCount;
                }
                else
                {
                    Array.Copy(this.m_buffer, this.m_startIndex, numArray1, 0, cb);
                    this.m_startIndex = this.m_startIndex + cb;
                    return numArray1;
                }
            }
            while (dstOffsetBytes < cb)
            {
                byte[] numArray2 = this.Func();
                int num1 = cb - dstOffsetBytes;
                if (num1 > 20)
                {
                    Array.Copy((Array)numArray2, 0, (Array)numArray1, dstOffsetBytes, 20);
                    dstOffsetBytes += 20;
                }
                else
                {
                    Array.Copy((Array)numArray2, 0, (Array)numArray1, dstOffsetBytes, num1);
                    int num2 = dstOffsetBytes + num1;
                    Array.Copy((Array)numArray2, num1, (Array)this.m_buffer, this.m_startIndex, 20 - num1);
                    this.m_endIndex = this.m_endIndex + (20 - num1);
                    return numArray1;
                }
            }
            return numArray1;
        }

        public override void Reset()
        {
            this.Initialize();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;
            if (this.m_hmacsha1 != null)
                this.m_hmacsha1.Dispose();
            if (this.m_buffer != null)
                Array.Clear((Array)this.m_buffer, 0, this.m_buffer.Length);
            if (this.m_salt == null)
                return;
            Array.Clear((Array)this.m_salt, 0, this.m_salt.Length);
        }

        private void Initialize()
        {
            if (this.m_buffer != null)
                Array.Clear((Array)this.m_buffer, 0, this.m_buffer.Length);
            this.m_buffer = new byte[20];
            this.m_block = 1U;
            this.m_startIndex = this.m_endIndex = 0;
        }

        private byte[] Func()
        {
            byte[] inputBuffer = new byte[4]
      {
        (byte) (this.m_block >> 24),
        (byte) (this.m_block >> 16),
        (byte) (this.m_block >> 8),
        (byte) this.m_block
      };

            this.m_hmacsha1.TransformBlock(this.m_salt, 0, this.m_salt.Length, (byte[])null, 0);
            this.m_hmacsha1.TransformBlock(inputBuffer, 0, inputBuffer.Length, (byte[])null, 0);
            this.m_hmacsha1.TransformFinalBlock(EmptyArray<byte>.Value, 0, 0);
            byte[] hashValue = this.m_hmacsha1.Hash;
            this.m_hmacsha1.Initialize();
            byte[] numArray = hashValue;
            for (int index1 = 2; (long)index1 <= (long)this.m_iterations; ++index1)
            {
                this.m_hmacsha1.TransformBlock(hashValue, 0, hashValue.Length, (byte[])null, 0);
                this.m_hmacsha1.TransformFinalBlock(EmptyArray<byte>.Value, 0, 0);
                hashValue = this.m_hmacsha1.Hash;
                for (int index2 = 0; index2 < 20; ++index2)
                    numArray[index2] ^= hashValue[index2];
                this.m_hmacsha1.Initialize();
            }
            this.m_block = this.m_block + 1U;
            return numArray;
        }
    }

    internal class EmptyArray<T>
    {
        public static readonly T[] Value = new T[0];
    }
}