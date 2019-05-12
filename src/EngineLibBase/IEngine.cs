namespace EngineLibBase
{
   public enum EngineStatus { Stopped, Started }

   public interface IEngine
   {
      EngineStatus Status { get; }
      void Start();
      void Stop();
   }
}
