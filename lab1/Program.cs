using System;
using PL;
using BLL;
using BLL.Entities;
using BLL.Interfaces;
using System.Text;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            ConsoleMenu.MainMenu();
        }
    }
}
