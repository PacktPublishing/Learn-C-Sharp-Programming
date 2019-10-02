namespace chapter_06
{
    class CompareObjects
    {
        public bool Compare<T>(T input1, T input2)
        {
            return input1.Equals(input2);
        }
    }
}