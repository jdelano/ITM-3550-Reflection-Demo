using System.Reflection;

namespace ReflectionDemoPrep2024;

class Program
{
    static void Main(string[] args)
    {
        Type? T = Type.GetType("ReflectionDemoPrep2024.Customer");
        Console.WriteLine("Properties in Customer Class");
        PropertyInfo[] properties = T!.GetProperties();
        foreach (var property in properties)
        {
            Console.WriteLine(property.Name);
        }
        Console.WriteLine("\nMethods in Customer Class");
        MethodInfo[] methods = T!.GetMethods();
        foreach (var method in methods)
        {
            Console.WriteLine($"{method.ReturnType.Name} {method.Name}");
        }
    }
}

