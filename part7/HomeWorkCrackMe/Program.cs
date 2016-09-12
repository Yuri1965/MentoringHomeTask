using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HomeWorkCrackMe
{
    class Program
    {
        // коллекция наших корректных кодов
        private static string[] myKeys = { "1234-5678-dfdfd", "1234-999-aaaccc", "78788-999-kkkmmmrrr" };

        // форма из сборки CrackMe.exe
        private static CrackMe.Form1 form = new CrackMe.Form1();

        //метод клика на кнопку, который подсунем в CrackMe.exe, вместо оригинальной реализации
        private static void BtnClick(object sender, EventArgs e)
        {
            string[] code = form.eval_d.Text.Split('-');

            form.eval_f.Text = "";

            if (CheckCode(code))
                form.eval_f.Text = "Code IS CORRECT";
            else
                form.eval_f.Text = "Code IS WRONG";

            form.eval_f.Visible = true;
        }

        //проверка кода в нашей коллекции
        private static bool CheckCode(string[] code)
        {
            bool result = false;
            var chkCode = String.Concat(code);

            foreach (var c in myKeys)
            {
                if (chkCode.Equals(c.Replace("-", ""), StringComparison.OrdinalIgnoreCase))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        
        static void Main(string[] args)
        {
            string originCode = "";
            string[] splitCode;
            bool res = false;

            //используем алгоритм проверки кода, который внутри CrackMe.exe 
            //правильный код вернется если символы = числа в пределах значений Int32(можно чтобы был разделитель "-" был или НЕ был)
            //а также чтобы было соединение с какой нибудь сетью (NetworkInterfaces), к примеру VPN EPAM


            // это правильный код
            try
            {
                originCode = "1234-2345";
                splitCode = originCode.Split('-');
                Console.WriteLine("execute CheckCode method with code = {0}", originCode);
                res = form.eval_a(splitCode);
                if (res)
                    Console.WriteLine("CheckCode method return: Code {0} IS CORRECT!", originCode);
                else
                    Console.WriteLine("CheckCode method return: Code {0} IS WRONG or NetworkInterfaces not found!", originCode);
            }
            catch (Exception e)
            {
                Console.WriteLine("CheckCode method return: Code {0} IS WRONG!\nError: {1}", originCode, e.Message);
            }

            // это НЕ правильный код
            try
            {
                originCode = "1234-2345-adadsds-wewew";
                splitCode = originCode.Split('-');
                Console.WriteLine("\nexecute CheckCode method with code = {0}", originCode);
                res = form.eval_a(splitCode);
                if (res)
                    Console.WriteLine("CheckCode method return: Code {0} IS CORRECT!", originCode);
                else
                    Console.WriteLine("CheckCode method return: Code {0} IS WRONG or NetworkInterfaces not found!", originCode);
            }
            catch (Exception e)
            {
                Console.WriteLine("CheckCode method return: Code {0} IS WRONG!\nError: {1}", originCode, e.Message);
            }

            // а тепреь переопределим вызовы проверки правильности кода на свою реализацию
            // и будем вызывать прямо с интерфейса формы прооверку кода
            form.eval_c.Click -= form.eval_a;
            form.eval_c.Click += BtnClick;
            form.ShowDialog();
        }
    }
}
