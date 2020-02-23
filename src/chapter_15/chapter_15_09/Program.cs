using System;

namespace chapter_15_09
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new Vector()
            {
                x = 1,
                y = 3,
            };

            SomeMethod(v);
            ReadonlyBehavior(v);
        }

        public static float SomeMethod(in Vector vector)
        {
            // a local copy is done because GetLength is not readonly
            return vector.GetLength();
        }

        public static float ReadonlyBehavior(in Vector vector)
        {
            // no local copy is done because GetLengthRo is readonly
            return vector.GetLengthRo();
        }

    }
}
