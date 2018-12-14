using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lynda_ReflectionForDevelopers
{
    public class Mirror
    {

     

        public Mirror( Type type)
        {
            MirroredType = type;
        }

        public Type MirroredType { get; set; }
        private const BindingFlags flags = BindingFlags.Instance
                                | BindingFlags.Static
                                | BindingFlags.Public
                                | BindingFlags.NonPublic;


        public void DumpType()
        {
            Console.WriteLine($"{MirroredType.Name}, loaded from {MirroredType.Assembly.FullName}");
            Console.WriteLine($" inherits from {MirroredType.BaseType.Name}");
            Console.WriteLine($" implements:  ");
            foreach (var interFaces in MirroredType.GetInterfaces())
            {
                Console.WriteLine($"{interFaces.Name,  20}");
            }
        }

        public void DumpProperties()
        {
            Console.WriteLine( "Properties:");
            var flags = BindingFlags.Instance
                                | BindingFlags.Static
                                | BindingFlags.Public
                                | BindingFlags.NonPublic;



            foreach (var prop in MirroredType.GetProperties(flags))
            {
                Console.WriteLine($"{prop.Name} : {prop.PropertyType}");
                Console.WriteLine($"r:{prop.CanRead} w:{prop.CanWrite}");
            }
        }

        public void DumpMethods()
        {
            Console.WriteLine("Methods:");
            foreach (var meth in MirroredType.GetMethods(flags))
            {
                Console.WriteLine($"{meth.Name} : {meth.ReturnType}" );
                foreach (var param in meth.GetParameters())
                {
                    Console.WriteLine($"\ttakes :{param.Name}, : {param.ParameterType}");
                }
            }
        }

        public void DumpConstructors()
        {
            Console.WriteLine("Constructors:");

            foreach (var ctor in MirroredType.GetConstructors(flags))
            {
                Console.WriteLine("--->");
                foreach (var param in ctor.GetParameters())
                {
                    Console.WriteLine($"\ttakes :{param.Name}, : {param.ParameterType}");
                }
            }
        }

        public void DumpFields()
        {
            Console.WriteLine("Fields:");

            foreach (var fld in MirroredType.GetFields(flags))
            {
                Console.WriteLine($"{fld.Name}: {fld.FieldType}");
            }
        }

    }
}
