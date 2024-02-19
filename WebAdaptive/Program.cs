using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using WebAdaptive.Classes;

class Program
{
        static void Main(string[] args)
    {
        Coffee coffee1 = new Coffee(1, "Latte", false, 3, 'S');
        Coffee coffee2 = new Coffee(2, "Cappuccino", false, 3, 'M');

        Type coffeClassType = typeof(Coffee);
        TypeInfo coffeeClassTypeInfo = coffeClassType.GetTypeInfo();

        Console.WriteLine($"Type Name: {coffeClassType.Name}");
        Console.WriteLine($"Is Pulic: {coffeeClassTypeInfo.IsPublic}");
        Console.WriteLine($"Is Class: {coffeeClassTypeInfo.IsClass}");

        Console.WriteLine( "------------------------");
        foreach (MemberInfo member in coffeeClassTypeInfo.GetMembers())
        {
            Console.WriteLine($"Name: {member.Name}, Type: {member.MemberType} ");
        }

        Console.WriteLine("------------------------");
        foreach (FieldInfo fieldInfo in coffeeClassTypeInfo.DeclaredFields)
        {
            Console.WriteLine($"Name: {fieldInfo.Name}, Attributes: ({fieldInfo.Attributes}), FieldType: {fieldInfo.FieldType}");
        }

        Console.WriteLine("------------------------");
        foreach (MethodInfo methodInfo in coffeeClassTypeInfo.DeclaredMethods)
        {
            Console.WriteLine($"Name: {methodInfo.Name}, MethodType: {methodInfo.ReturnType}");
        }
        Console.WriteLine("------------------------");
        MethodInfo method = typeof(Coffee).GetMethod("ShowFullInfo");
        method.Invoke(coffee1, null);
    }
}
