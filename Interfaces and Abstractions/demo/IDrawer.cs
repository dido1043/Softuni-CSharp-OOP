using System;
using System.Collections.Generic;
using System.Text;

namespace demo
{
    public interface IDrawer 
    {
        public void WriteLine(string text);

        public void Write(string text);

        public void WriteAtPosition(int row, int col, string text);

    }
}
