namespace chapter_05
{
   public class Employee
   {
      private string name;
      private double salary;

      public string Name
      {
         get { return name; }
         set { name = value; }
      }

      public double Salary
      {
         get { return salary; }
      }

      public Employee(string name, double salary)
      {
         this.name = name;
         this.salary = salary;
      }

      public void GiveRaise(double percent)
      {
         salary *= (1.0 + percent / 100.0);
      }
   }
}
