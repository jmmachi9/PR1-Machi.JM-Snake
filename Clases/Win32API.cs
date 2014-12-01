using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Clases
{
    static class Win32API
    {
        [DllImport("user32.dll")]
        public static extern ushort GetKeystate(short nVirtKey);

        public const ushort KeyDownBit = 0x20;

        public static bool IsKeyPressed(ConsoleKey Key)
        {
            return ((GetKeystate((short)Key) & KeyDownBit) == KeyDownBit);
        }

    }
}
