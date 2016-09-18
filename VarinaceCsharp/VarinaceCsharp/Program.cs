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

                ContraVariantDelegateType<Mammal> mammal_Method = x=> x.Display();
                ContraVariantDelegateType<Zebra> zebra_Method = mammal_Method;
                Zebra z = new Zebra();
                zebra_Method(z);
            }

            //Covariance
            {
                Console.WriteLine("\ncovariance with object");
                Mammal m = CovariantMethod1();
                m.Display();
            }

            {
                Console.WriteLine("\ncovariancw with an array");
                Mammal[] mammal_Array = CovariantMethod2();
                foreach (Mammal m in mammal_Array)
                    m.Display();
            }
            {
                Console.WriteLine("\ncovariance with interface");
                IEnumerable<Mammal> mammal_IEnumerable = CovariantMethod3();
                foreach (Mammal m in mammal_IEnumerable)
                    m.Display();
            }

            {
                Console.WriteLine("\ncovariance with delegate");
                Zebra z;
                CovariantDelegateType<Zebra> mdt_Zebra = () => new Zebra();
                z = mdt_Zebra();
                z.Display();
                CovariantDelegateType<Mammal> mdt_Mammal = mdt_Zebra;
                z = (Zebra)mdt_Mammal();
                z.Display();

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
        //static void MyMammalMethod(Mammal mammal)
        //{
        //    mammal.Display();
        //}

        //Covariance 

        static Zebra CovariantMethod1()
        {
            return new Zebra();
        }

        static Zebra[] CovariantMethod2()
        {
            Zebra z1 = new Zebra();
            Zebra z2 = new Zebra();
            Zebra z3 = new Zebra();

            return new Zebra[]{z1,z2,z3 };
        }

        static IEnumerable<Zebra> CovariantMethod3()
        {
            Zebra z1 = new Zebra();
            Zebra z2 = new Zebra();
            Zebra z3 = new Zebra();

            List<Zebra> z_List = new List<Zebra>();
            z_List.Add(z1);
            z_List.Add(z2);
            z_List.Add(z3);

            IEnumerable<Zebra> z_Enumerable = z_List;
            return z_Enumerable;
        }



    }
}
