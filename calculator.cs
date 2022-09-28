using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp212
{
    internal class Program
    {
        public static void calculation(out bool func_con, ref string[] func_list_equastion, ref int func_cell, Func<int, int, int> math_operator)
        {
            try
            {
                func_con = true;
                int func_num1 = int.Parse(func_list_equastion[func_cell - 1]);
                int func_num2 = int.Parse(func_list_equastion[func_cell + 1]);
                int func_num = math_operator(func_num1, func_num2);
                Console.WriteLine(func_num);

                string str_num = func_num.ToString();
                func_list_equastion[func_cell - 1] = str_num;
                func_list_equastion[func_cell] = null;
                func_list_equastion[func_cell + 1] = null;
                return;
            }
            finally
            {
                if (func_cell >= func_list_equastion.Length) { func_cell = 1; }

                if (func_list_equastion.Length < 1) { System.Environment.Exit(0); }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("please enter your equastion:");
            string equastion = Console.ReadLine();
            string[] list_equastion = equastion.Split(' ');
            for (int i = 0; i < list_equastion.Length; i++)
            {
                Console.WriteLine(list_equastion[i]);
            }

            Func<int, int, int> multiply = (a, b) => a * b;
            Func<int, int, int> divide = (a, b) => a / b;
            Func<int, int, int> add = (a, b) => a + b;
            Func<int, int, int> subtract = (a, b) => a - b;

            int cell = 1;
            int counter = 0;

            while (true)
            {
                bool con = false;
                try
                {
                    if (list_equastion[cell] == "*") { calculation(out con, ref list_equastion, ref cell, multiply); }
                    if (list_equastion[cell] == "/") { calculation(out con, ref list_equastion, ref cell, divide); }

                    if (counter >= list_equastion.Length)
                    {
                        if (list_equastion[cell] == "+") { calculation(out con, ref list_equastion, ref cell, add); }
                        if (list_equastion[cell] == "-") { calculation(out con, ref list_equastion, ref cell, subtract); }
                    }

                    if (con == false) { cell = cell + 2; }

                    if (cell >= list_equastion.Length) { cell = 1; }

                    if (list_equastion[1] == null) { Console.WriteLine(list_equastion[0]); System.Environment.Exit(0); }

                    counter++;
                }
                finally
                {
                    if (cell >= list_equastion.Length) { cell = 1; }

                    if (list_equastion.Length < 1) {Console.WriteLine(list_equastion[0]); System.Environment.Exit(0);}

                    counter++;
                }
            }

            Console.WriteLine("main loop is over");
            for (int i = 0; i < list_equastion.Length; i++) { Console.WriteLine(list_equastion[i]); }
            if (list_equastion.Length < 1) { Console.WriteLine("n");}
        }
    }
}
