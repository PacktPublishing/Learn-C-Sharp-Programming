using System.Collections.Generic;

namespace chapter_06
{
   class RestrictedDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>
      where TKey : System.Enum
      where TValue : class, new()
   {
      public T Make<T>(TKey key) where T : TValue, new()
      {
         var value = new T();
         if (!TryGetValue(key, out List<TValue> list))
         {
            Add(key, new List<TValue>() { value });
         }
         else
         {
            list.Add(value);
         }

         return value;
      }
   }
}
