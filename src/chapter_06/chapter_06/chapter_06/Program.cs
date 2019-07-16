using System;

namespace chapter_06
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericDemo<int> objGenericClass1 = new GenericDemo<int>(10);
            objGenericClass1.GetT();

            GenericDemo<string> objGenericClass2 = new GenericDemo<string>("Hello World");
            objGenericClass2.GetT();

            Rectangle<int> rectangle1 = new Rectangle<int>(10, 20);
            rectangle1.GetDimension();

            Rectangle<double> rectangle2 = new Rectangle<double>(5.5, 7.5);
            rectangle2.GetDimension();

            Square objSquare = new Square(10);
            Console.WriteLine("The area of sqaure is " + objSquare.CalculateArea());

            Circle objCircle = new Circle(7.5);
            Console.WriteLine("The area of circle is " + objCircle.CalculateArea());

            Employee employee = new Employee(10000, 500);
            Console.WriteLine("The total salary of employee is " + employee.Add());

            Student student = new Student("John", "Doe");
            Console.WriteLine("The full name of student is " + student.Add());

            TestVehicle<Car> objCar = new TestVehicle<Car>(new Car());
            objCar.GetVehicleType();

            // TestVehicle<HangGlider> objHang = new TestVehicle<HangGlider>(new HangGlider()); // Compile-time error

            CompareObject compareObject = new CompareObject();
            Console.WriteLine(compareObject.Compare<int>(10, 10));
            Console.WriteLine(compareObject.Compare<double>(10.5, 10.8));
            Console.WriteLine(compareObject.Compare<string>("a", "a"));
            Console.WriteLine(compareObject.Compare<string>("a", "b"));

            Console.ReadLine();
        }
    }
}
