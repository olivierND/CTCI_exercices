using System;
using System.Linq;
using System.Reflection;

namespace CITC_exercices
{
    class Program
    {
        static void Main(string[] args)
        {
            Type[] types = GetTypesInNamespace();
            Array.Sort(types, (t1, t2) => string.Compare(t1.Name, t2.Name, StringComparison.Ordinal));


            int chapter = 1;

            Console.WriteLine(
                "-------------------------------------- Chapter " + chapter + " --------------------------------------" +
                Environment.NewLine);

            for (int i = 0; i < types.Length; i++)
            {
                IQuestion instance = Activator.CreateInstance(types[i]) as IQuestion;
                instance?.Run();

                if (i + 1 < types.Length && types[i].Namespace != types[i + 1].Namespace)
                {
                    Console.WriteLine(
                        Environment.NewLine +
                        "-------------------------------------- Chapter " + ++chapter + " --------------------------------------" +
                        Environment.NewLine);
                }
            }
        }

        private static Type[] GetTypesInNamespace()
        {
            Assembly assembly = typeof(Chapter01.Q01_1).GetTypeInfo().Assembly;

            return
                assembly.GetTypes()
                    .Where(t => string.Equals(t.GetInterfaces().FirstOrDefault()?.Name, "IQuestion", StringComparison.Ordinal))
                    .ToArray();
        }
    }
}
