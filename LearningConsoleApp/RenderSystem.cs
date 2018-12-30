using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleBuffer;

namespace LearningConsoleApp
{
    class RenderSystem
    {

        Game game;
        static int width = 80;
        static int height = 20;
        buffer myBuf;

        public RenderSystem(Game game)
        {
            this.game = game;
            Console.CursorVisible = false;
            Console.Title = "???";
            System.Console.SetWindowSize(width, height);
            System.Console.SetBufferSize(width, height);
            Console.Clear();
            myBuf = new buffer(width, height, width, height);
        }


        public void Render()
        {
            int x, y, tile;
            for (x = 0; x < 80; x++)
            {
                for (y = 0; y < 20; y++)
                {
                    tile = game.GetMap().Fields(y, x);
                    switch (tile)
                    {
                        case Map.NOTHING:
                            myBuf.Draw(" ", x, y, 15);
                            break;
                        case Map.WALL:
                            myBuf.Draw("#", x, y, 15);
                            break;
                        case Map.HERO:
                            myBuf.Draw("8", x, y, 15);
                            break;
                    }
                }
            }
            myBuf.Draw(game.fps.ToString("0000.00") +" fps    ", 0, 0, 15);
            myBuf.Print();
        }

        public void Render2()
        {
            int x, y, tile;
            //Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (x = 0; x<20; x++)
            {
                for (y=0;y<80;y++)
                {
                    tile = game.GetMap().Fields(x, y);
                    switch (tile)
                    {
                        case Map.NOTHING:
                            Console.Write(" ");
                            break;
                        case Map.WALL:
                            Console.Write("#");
                            break;
                        case Map.HERO:
                            Console.Write("8");
                            break;
                    }
                }
            }
        }

    }
}
