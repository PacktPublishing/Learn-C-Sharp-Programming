using System;

namespace chapter_05
{   
   struct Position
   {
      public int X { get; private set; }
      public int Y { get; private set; }
      public Position(int x = 0, int y = 0)
      {
         X = x;
         Y = y;
      }
   }

   namespace v1
   {
      class Surface
      {
         private int left;
         private int top;

         public void BeginDraw()
         {
            Console.Clear();
            left = Console.CursorLeft;
            top = Console.CursorTop;
         }

         public void DrawAt(char c, Position position)
         {
            try
            {
               Console.SetCursorPosition(left + position.X, top + position.Y);
               Console.Write(c);
            }
            catch (ArgumentOutOfRangeException e)
            {
               Console.Clear();
               Console.WriteLine(e.Message);
            }
         }
      }
   }

   namespace v1
   {
      class GameUnit
      {
         public Position Position { get; protected set; }

         public GameUnit(Position position)
         {
            Position = position;
         }

         public void Draw(Surface surface)
         {
            surface.DrawAt(GetImage(), Position);
         }

         protected virtual char GetImage() { return ' '; }
      }

      class Terrain : GameUnit
      {
         public Terrain(Position position) : base(position) { }
      }

      class Water : Terrain
      {
         public Water(Position position) : base(position) { }

         protected override char GetImage()
         {
            return '░';
         }
      }

      class Hill : Terrain
      {
         public Hill(Position position) : base(position) { }

         protected override char GetImage()
         {
            return '≡';
         }
      }
   }

   namespace v2
   {
      class GameUnit
      {
         public Position Position { get; protected set; }

         public GameUnit(Position position)
         {
            Position = position;
         }

         public void Draw(v1.Surface surface)
         {
            surface.DrawAt(Image, Position);
         }

         protected virtual char Image => ' ';
      }

      class Terrain : GameUnit
      {
         public Terrain(Position position) : base(position) { }
      }

      class Water : Terrain
      {
         public Water(Position position) : base(position) { }

         protected override char Image => '░';
      }

      class Hill : Terrain
      {
         public Hill(Position position) : base(position) { }

         protected override char Image => '≡';
      }
   }

   namespace v3
   {
      abstract class GameUnit
      {
         public Position Position { get; protected set; }

         public GameUnit(Position position)
         {
            Position = position;
         }

         public void Draw(v1.Surface surface)
         {
            surface.DrawAt(Image, Position);
         }

         protected abstract char Image { get; }
      }

      abstract class Terrain : GameUnit
      {
         public Terrain(Position position) : base(position) { }
      }

      class Water : Terrain
      {
         public Water(Position position) : base(position) { }

         protected override char Image => '░';
      }

      class Hill : Terrain
      {
         public Hill(Position position) : base(position) { }

         protected override char Image => '≡';
      }
   }

   namespace v4
   {
      abstract class GameUnit
      {
         public Position Position { get; protected set; }

         public GameUnit(Position position)
         {
            Position = position;
         }

         public void Draw(v1.Surface surface)
         {
            surface.DrawAt(Image, Position);
         }

         protected abstract char Image { get; }
      }

      abstract class Terrain : GameUnit
      {
         public Terrain(Position position) : base(position) { }
      }

      sealed class Water : Terrain
      {
         public Water(Position position) : base(position) { }

         protected override char Image => '░';
      }

      /*
      class Lake : Water  // ERROR: cannot derive from sealed type
      {
         public Lake(Position position) : base(position) { }
      }
      */

      class Hill : Terrain
      {
         public Hill(Position position) : base(position) { }

         protected override char Image => '≡';
      }
   }

   namespace v5
   {
      abstract class GameUnit
      {
         public Position Position { get; protected set; }

         public GameUnit(Position position)
         {
            Position = position;
         }

         public void Draw(v1.Surface surface)
         {
            surface.DrawAt(Image, Position);
         }

         protected abstract char Image { get; }
      }

      abstract class Terrain : GameUnit
      {
         public Terrain(Position position) : base(position) { }
      }

      class Water : Terrain
      {
         public Water(Position position) : base(position) { }

         protected sealed override char Image => '░';
      }
      
      class Lake : Water
      {
         public Lake(Position position) : base(position) { }

         // protected sealed override char Image => '░'; // ERROR: cannot override sealed member
      }

      class Hill : Terrain
      {
         public Hill(Position position) : base(position) { }

         protected override char Image => '≡';
      }
   }

      namespace v6
   {
      interface ISurface
      {
         void BeginDraw();
         void EndDraw();
         void DrawAt(char c, Position position);
      }

      class Surface : ISurface
      {
         private int left;
         private int top;

         public void BeginDraw()
         {
            Console.Clear();
            left = Console.CursorLeft;
            top = Console.CursorTop;
         }

         public void EndDraw()
         {
            Console.WriteLine();
         }

         public void DrawAt(char c, Position position)
         {
            try
            {
               Console.SetCursorPosition(left + position.X, top + position.Y);
               Console.Write(c);
            }
            catch (ArgumentOutOfRangeException e)
            {
               Console.Clear();
               Console.WriteLine(e.Message);
            }
         }
      }
   }

   namespace v6
   {
      abstract class GameUnit
      {
         public Position Position { get; protected set; }

         public GameUnit(Position position)
         {
            Position = position;
         }

         public void Draw(v6.ISurface surface)
         {
            surface?.DrawAt(Image, Position);
         }

         protected abstract char Image { get; }
      }

      abstract class Terrain : GameUnit
      {
         public Terrain(Position position) : base(position) { }
      }

      class Water : Terrain
      {
         public Water(Position position) : base(position) { }

         protected override char Image => '░';
      }

      class Hill : Terrain
      {
         public Hill(Position position) : base(position) { }

         protected override char Image => '≡';
      }

      interface IMoveable
      {
         void MoveTo(Position pos);
      }

      abstract class ActionUnit : GameUnit, IMoveable
      {
         public ActionUnit(Position position) : base(position) { }

         public void MoveTo(Position pos)
         {
            Position = pos;
         }
      }

      class Meeple : ActionUnit
      {
         public Meeple(Position position) : base(position) { }

         protected override char Image => 'M';
      }
   }

   namespace v7
   {
      abstract class GameUnit
      {
         public Position Position { get; protected set; }

         public GameUnit(Position position)
         {
            Position = position;
         }

         public void Draw(v6.ISurface surface)
         {
            surface?.DrawAt(Image, Position);
         }

         protected abstract char Image { get; }
      }      

      interface IMoveable
      {
         void MoveTo(Position pos);
         void MoveTo(int x, int y);
      }

      abstract class ActionUnit : GameUnit, IMoveable
      {
         public ActionUnit(Position position) : base(position) { }

         public void MoveTo(Position pos)
         {
            Position = pos;
         }

         public void MoveTo(int x, int y)
         {
            Position = new Position(x, y);
         }
      }

      class Meeple : ActionUnit
      {
         public Meeple(Position position) : base(position) { }

         protected override char Image => 'M';
      }
   }
}
