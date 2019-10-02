namespace chapter_06
{
   interface IMultiVariant<out T, in U>
   {
      T Make();
      void Take(U arg);
   }
}
