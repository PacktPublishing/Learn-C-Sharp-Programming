using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_15_09
{
    public struct Vector
    {
        public float x;
        public float y;
        private readonly float SquaredRo => (x * x) + (y * y);
        public readonly float GetLengthRo() => MathF.Sqrt(SquaredRo);
        public float GetLength() => MathF.Sqrt(SquaredRo);
    }

}
