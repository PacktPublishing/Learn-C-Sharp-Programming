using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_06
{
    struct Rectangle<T>
    {
        T Width;
        T Height;

        public Rectangle(T width, T height)
        {
            Width = width;
            Height = height;
        }

        public void GetDimension()
        {
            Console.WriteLine("The width of rectangle is : " + Width);
            Console.WriteLine("The height of rectangle is : " + Height);
        }
    }
}
