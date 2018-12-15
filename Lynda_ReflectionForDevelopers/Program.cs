using System;
using System.Reflection;

namespace Lynda_ReflectionForDevelopers
{
    class Program
    {
        static void Main(string[] args)
        {
            // ReferenceBasics();
            Type ptType = typeof(Point);

           var ctor =  ptType.GetConstructor( new Type[] {typeof(int),  typeof(int) } );
            var pt = ctor.Invoke(new object[] { 12, 12 });
            Console.WriteLine($"Constructed {pt}");

            var xProp = ptType.GetProperty("X");
            var yProp = ptType.GetProperty("Y");
            Console.WriteLine($"{xProp.GetValue(pt)}");
            xProp.SetValue(pt, 24);
           

            var pt2 = ctor.Invoke(new object[] { 12, 13 });
            Console.WriteLine($"pt =  {pt}, pt2 = {pt2}");
            var dist = ptType.GetMethod("Distance");
            var result = dist.Invoke(null, new object[] { pt, pt2 });
            Console.WriteLine($"Distance = {result}");

            var xField = ptType.GetField("<X>k__BackingField",  BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine($"x backing field = {xField.GetValue(pt)}");
            xField.SetValue(pt, 0);
            Console.WriteLine($"pt = {pt}");
            Console.WriteLine($"pt.X = {xProp.GetValue(pt)}");

        }

        private static void ReferenceBasics()
        {
            var ptType = typeof(Point);
            Console.WriteLine(ptType);

            var ptAssem = ptType.Assembly;
            Console.WriteLine(ptAssem.FullName);
            Console.WriteLine(ptAssem.CodeBase);

            foreach (var mod in ptAssem.Modules)
            {
                Console.WriteLine($"Module: {mod}");
            }

            var pt = new Point(5, 5);
            var mirroredPoint = new Mirror(pt.GetType());
            mirroredPoint.DumpType();
            mirroredPoint.DumpProperties();
            mirroredPoint.DumpMethods();
            mirroredPoint.DumpConstructors();
            mirroredPoint.DumpFields();

            var mirroredObject = new Mirror(typeof(System.Int32));
            mirroredObject.DumpType();
        }
    }
}
