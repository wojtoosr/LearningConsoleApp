using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp
{
    class Game
    {
        //InputSystem inputSystem = new InputSystem();
        Hero player;
        RenderSystem renderSystem;
        Map map;
        DateTime _currentTime;
        public double fps = 0.0f;

        public void Run()
        {
            renderSystem = new RenderSystem(this);
            map = new Map();
            player = new Hero(1, 1);
            map.UpdateField(1, 1, Map.HERO);

            do
            {
                //Render
                _currentTime = DateTime.Now;
                renderSystem.Render();
                if (InputSystem.IsKeyDown(0x25))
                    MoveHero(-1, 0);
                if (InputSystem.IsKeyDown(0x26))
                    MoveHero(0, -1);
                if (InputSystem.IsKeyDown(0x27))
                    MoveHero(1, 0);
                if (InputSystem.IsKeyDown(0x28))
                    MoveHero(0, 1);
                System.Threading.Thread.Sleep(100);
                fps = 1.0f / (DateTime.Now - _currentTime).TotalSeconds;
            } while (!InputSystem.IsKeyDown(0x51));
        }

        void MoveHero(int deltaX, int deltaY)
        {
            int targetField;
            targetField = map.Fields(player.PosY + deltaY, player.PosX + deltaX);
            if (targetField == Map.NOTHING)
            {
                map.UpdateField(player.PosY, player.PosX, Map.NOTHING);
                if ((player.PosX + deltaX >= 0) && (player.PosX + deltaX <= 79))
                    player.PosX += deltaX;
                if ((player.PosY + deltaY >= 0) && (player.PosY + deltaY <= 39))
                    player.PosY += deltaY;
                map.UpdateField(player.PosY, player.PosX, Map.HERO);
            }
        }

        public Hero GetPlayer()
        {
            return player;
        }

        public Map GetMap()
        {
            return map;
        }
    }
}
