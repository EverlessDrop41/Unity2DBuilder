using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwoDBuilder.Level
{
    public struct GridPosition
    {
        public int X;
        public int Y;

        public GridPosition(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y:{1}", X, Y);
        }
    }
}
