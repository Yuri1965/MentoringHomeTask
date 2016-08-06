using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeTask2
{
    [TestClass]
    public class MapperTest
    {
        private void DoTestMapper<TSource, TTarget>(TSource source)
        {
            var mapGenerator = new MappingGenerator();
            var mapper = mapGenerator.Generate<TSource, TTarget>();

            var res = mapper.Map(source);

            Assert.IsTrue(mapGenerator.MemberwiseEqual(source, res), "result is not equal to source");

            Console.WriteLine(res.ToString());
        }

        private class WithInts1
        {
            public int a;
            public int b;
            public int c;
            private int d = 1;

            public override string ToString()
            {
                StringBuilder resultString = new StringBuilder();

                resultString.Append(this.GetType());
                resultString.Append("\n a = " + a.ToString());
                resultString.Append("\n b = " + b.ToString());
                resultString.Append("\n c = " + c.ToString());
                resultString.Append("\n d = " + d.ToString());

                return resultString.ToString();
            }
        }

        private class WithInts2
        {
            public int b;
            public int a;
            private int d;

            public override string ToString()
            {
                StringBuilder resultString = new StringBuilder();

                resultString.Append(this.GetType());
                resultString.Append("\n a = " + a.ToString());
                resultString.Append("\n b = " + b.ToString());
                resultString.Append("\n d = " + d.ToString());

                return resultString.ToString();
            }
        }

        private class WithPrivateData1
        {
            public double a = 5;

            private int B { get; set; }
            private int e = 45;
            public int c = 25;

            public override string ToString()
            {
                StringBuilder resultString = new StringBuilder();

                resultString.Append(this.GetType());
                resultString.Append("\n a = " + a.ToString());
                resultString.Append("\n B = " + B.ToString());
                resultString.Append("\n c = " + c.ToString());

                return resultString.ToString();
            }
        }

        private class WithPrivateData2
        {
            public int a = 77;

            private int D { get; set; }
            private int F { get; set; }
            private int e = 12;
            private int f = 88;
            private int c = 99;

            public override string ToString()
            {
                StringBuilder resultString = new StringBuilder();

                resultString.Append(this.GetType());
                resultString.Append("\n a = " + a.ToString());
                resultString.Append("\n D = " + D.ToString());
                resultString.Append("\n F = " + F.ToString());
                resultString.Append("\n e = " + e.ToString());
                resultString.Append("\n f = " + f.ToString());
                resultString.Append("\n c = " + c.ToString());

                return resultString.ToString();
            }
        }

        private class WithPrivateData3
        {
            public double a = 123;

            private int D { get; set; }
            private int F { get; set; }
            private int e = 12;
            private int f = 88;
            private int c = 199;

            public override string ToString()
            {
                StringBuilder resultString = new StringBuilder();

                resultString.Append(this.GetType());
                resultString.Append("\n a = " + a.ToString());
                resultString.Append("\n D = " + D.ToString());
                resultString.Append("\n F = " + F.ToString());
                resultString.Append("\n e = " + e.ToString());
                resultString.Append("\n f = " + f.ToString());
                resultString.Append("\n c = " + c.ToString());

                return resultString.ToString();
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            WithPrivateData1 source = new WithPrivateData1() { a = 15 };
            Console.WriteLine(source.ToString());

            DoTestMapper<WithPrivateData1, WithPrivateData2>(source);
        }

        [TestMethod]
        public void TestMethod2()
        {
            WithInts1 source = new WithInts1() { a = 10, b = 2 };
            Console.WriteLine(source.ToString());

            DoTestMapper<WithInts1, WithInts2>(source);
        }

        [TestMethod]
        public void TestMethod3()
        {
            WithPrivateData1 source = new WithPrivateData1() { a = 10, c = 999 };
            Console.WriteLine(source.ToString());

            DoTestMapper<WithPrivateData1, WithPrivateData3>(source);
        }
    }
}
