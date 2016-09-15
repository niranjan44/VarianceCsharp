using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarianceCsharp
{
    class Program
    {
       

        public class Mammal
        {
            virtual public void Display()
            {
                Console.WriteLine("Mammal: " + GetHashCode());
            }

        }

        public class Zebra : Mammal
        {
            public override void Display()
            {
                Console.WriteLine("Zebra: " + GetHashCode());
            }
        }

        delegate void ContraVariantDelegateType<in T>(T a);
        delegate T CovariantDelegateType<out T>();

        static void Main(string[] args)
        {
            {
                Console.WriteLine("\ncontravariance with object");
                Zebra z = new Zebra();
                ContraVariantMethod(z);
            }

            {
                Console.WriteLine("\ncontravariance with an arry");

                Zebra z1 = new Zebra();
                Zebra z2 = new Zebra();
                Zebra z3 = new Zebra();

                Zebra[] z_Array = { z1, z2, z3 };
                ContraVariantMethod(z_Array);
            }


            {
                Console.WriteLine("\ncontravariance with interface");

                Zebra z1 = new Zebra();
                Zebra z2 = new Zebra();
                Zebra z3 = new Zebra();

                List<Zebra> z_List = new List<Zebra> {z1,z2,z3 };
                //not supported in .NET 3.5
                ContraVariantMethod(z_List);
            }

            {
                Console.WriteLine("\ncontravariance with delegate");

                ContraVariantDelegateType<Mammal> mammal_Method = MyMammalMethod;
                ContraVariantDelegateType<Zebra> zebra_Method = mammal_Method;
                Zebra z = new Zebra();
                zebra_Method(z);
            }


            Console.Read();
        }

        static void ContraVariantMethod(Mammal m)
        {
            m.Display();
        }

        static void ContraVariantMethod(Mammal[] mammals)
        {
            foreach (Zebra z in mammals)
                z.Display();
        }
        static void ContraVariantMethod(IEnumerable<Mammal> mammals)
        {
            foreach (Zebra z in mammals)
                z.Display();
        }
        static void MyMammalMethod(Mammal mammal)
        {
            mammal.Display();
        }

    }
}
