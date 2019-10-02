namespace chapter_06
{
   class ConflictingGenerics<T>
   {
      public void DoSomething<T>(T arg) // warning
      { 
      }
   }
}
