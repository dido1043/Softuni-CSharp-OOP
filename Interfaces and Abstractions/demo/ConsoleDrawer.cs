using System;
using System.Collections.Generic;
using System.Text;

namespace demo
{
    public class ConsoleDrawer : IDrawer
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteAtPosition(int row, int col, string text)
        {
            Console.SetCursorPosition(row, col);
            Write(text);
        }

        public int BufferHeight { get { return Console.BufferHeight; }  }

    }
}
