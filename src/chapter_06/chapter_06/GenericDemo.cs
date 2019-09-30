namespace chapter_06
{
   public class GenericDemo<T>
   {
      public T Value { get; private set; }

      public GenericDemo(T value)
      {
         Value = value;
      }

      public override string ToString() => $"{typeof(T)} : {Value}";
   }
}
