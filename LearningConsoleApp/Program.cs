using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 40);
            Console.CursorVisible = false;
            Game newGame = new Game();
            newGame.Run();
        }
    }
}
