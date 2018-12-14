using System;


namespace Lynda_ReflectionForDevelopers
{
    class Program
    {
        static void Main(string[] args)
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
