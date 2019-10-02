namespace chapter_06
{
   class Pair<T, U>
   {
      public T Item1 { get; private set; }
      public U Item2 { get; private set; }

      public Pair(T item1, U item2)
      {
         Item1 = item1;
         Item2 = item2;
      }
   }
}
