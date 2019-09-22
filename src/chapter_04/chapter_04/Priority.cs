namespace chapter_04
{
   namespace v1
   {
      enum Priority
      {
         Low,
         Normal,
         Important,
         Urgent
      }
   }

   namespace v2
   {
      enum Priority
      {
         Low = 0,
         Normal = 1,
         Important = 2,
         Urgent = 3
      }
   }

   namespace v3
   {
      enum Priority
      {
         Low = 10,
         Normal,
         Important = 20,
         Urgent
      }
   }

   namespace v4
   {
      enum Priority : byte
      {
         Low = 10,
         Normal,
         Important = 20,
         Urgent
      }
   }
}
