using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp212
{
    internal class Program
    {
        public static void turn_cell_to_int(string[] func_list_equastion, int func_cell, out int func_num1, out int func_num2)
        {
            try
            {
                func_num1 = int.Parse(func_list_equastion[func_cell - 1]);
                func_num2 = int.Parse(func_list_equastion[func_cell + 1]);
            }
            finally
            {
                if (func_cell >= func_list_equastion.Length)
                {
                    func_cell = 1;
                }
            }
            }
        public static void calculation(out bool func_con, int func_num, string str_num, int func_num1, int func_num2, ref string[] func_list_equastion, int func_cell)
        {
            try
            {
                func_con = true;
                str_num = func_num.ToString();
                func_list_equastion[func_cell - 1] = str_num;
                func_list_equastion[func_cell] = null;
                func_list_equastion[func_cell + 1] = null;
            }
            finally
            {
                if (func_cell >= func_list_equastion.Length)
                {
                    func_cell = 1;
                }
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

            int cell = 1;
            int counter = 0;

            while (list_equastion.Length != 1)
            {
                bool con = false;
                try
                {
                    if (list_equastion[cell] == "*")
                    {
                        int num, num1, num2;
                        String str_num = "";
                        turn_cell_to_int(list_equastion, cell, out num1, out num2);
                        num = num1 * num2;
                        calculation(out con, num, str_num, num1, num2, ref list_equastion, cell);
                    }

                    if (con == false) 
                    {
                        cell = cell + 2;
                    }

                    counter++;
                }
                finally
                {
                    if (cell >= list_equastion.Length)
                    {
                        cell = 1;
                    }


                }
            }
        }
    }
}
