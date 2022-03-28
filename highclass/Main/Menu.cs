using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Main
{
    public class Menu
    {
        public static void text()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("We hebben helaas nog geen menu. Coming soon!\n");
                Console.WriteLine("\nKlik op 'Enter' om terug te gaan naar het hoofdmenu.");
                ConsoleKeyInfo done = Console.ReadKey();
                if (done.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}