using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp
{
    class InputSystem
    {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        public static bool IsKeyDown(int key)
        {
            return (GetAsyncKeyState(key) & 0x8001) != 0;
        }

    }
}
