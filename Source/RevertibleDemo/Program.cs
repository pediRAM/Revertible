using System.Reflection;

namespace RevertibleDemo
{
    internal class Program
    {
        const string RULER = "------------------------------------------";
        const string RULER2= "==========================================";

        static void Main()
        {
            /*** Create an instance of the revertible class ***/
            Console.WriteLine("Createing revertible properties...");
            var rc = new RevertibleClass
            {
                Enabled = false,
                ID = -1,
                Name = "?",
                SomeObject = null,
            };

            PrintProperties(rc);

            /*** Save current values of the revertible properties, so we can revert them later ***/
            Console.WriteLine("Saving revertible properties...");
            rc.SaveRevertibleProperties();

            PrintProperties(rc);

            /*** Change the value of one or more revertible properties ***/
            Console.WriteLine("Changing values of 'Enabled' property...");
            rc.Enabled = true;

            PrintProperties(rc);

            /*** Change the values of other revertible properties too ***/
            Console.WriteLine("Changing values of 'ID', 'NAME' and 'SomeObject' properties...");
            rc.ID = 123;
            rc.Name = "John DOE";
            rc.SomeObject = rc;

            PrintProperties(rc);

            /*** Revert! ***/
            Console.WriteLine("Reverting values of revertible properties...");
            rc.RevertRevertibleProperties();

            PrintProperties(rc);
        }

        static void PrintProperties(RevertibleClass pRevertibleClass)
        {
            Console.WriteLine("All properties:");
            foreach(var pi in pRevertibleClass.GetRevertibleProperties())
            {
                Console.WriteLine($"{pi.Name,-15} = {pi.GetValue(pRevertibleClass)}");
            }

            Console.WriteLine(RULER);
            Console.WriteLine($"Has been changed: {pRevertibleClass.HasModifiedRevertibleProperties}");
            Console.WriteLine("List of changes properties:");

            if (pRevertibleClass.HasModifiedRevertibleProperties)
            {
                foreach (var propInf in pRevertibleClass.GetModifiedRevertibleProperties())
                    Console.WriteLine($"{propInf.Name}");
            }
            else
            {
                Console.WriteLine("None.");
            }

            Console.WriteLine(RULER2);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
