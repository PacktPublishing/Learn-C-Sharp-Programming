namespace chapter_04
{
   public interface IEngine
   {
      double Power { get; }

      void Start();
   }

   public class DieselEngine : IEngine
   {
      private double _power;
      public double Power { get { return _power; } }

      public void Start() { }
   }
}
