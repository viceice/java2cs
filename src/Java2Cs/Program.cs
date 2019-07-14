using System;
using System.IO;

namespace Java2Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Java2Cs");
            Console.WriteLine();


            var input = new DirectoryInfo(@"C:\Users\kriese\projects\gh\sat4j\org.sat4j.core\src\main\java");

            Console.WriteLine($"Processing directory: {input.FullName}");

            var output = new DirectoryInfo(@"C:\Users\kriese\projects\gh\sat4net\src\Sat4Net.Core");

            if (!output.Exists)
                output.Create();

            foreach (var info in input.EnumerateFiles("*.java", new EnumerationOptions { RecurseSubdirectories = true }))
            {
                Console.WriteLine($"Processing file: {info.FullName.Replace(input.FullName, output.FullName)}");
                var tree = Java.JavaHelper.Parse(info.FullName);

                var code = Java.JavaHelper.Generate(tree);

                var dest = info.Directory.FullName.Replace(input.FullName, output.FullName);
                if (!Directory.Exists(dest))
                    Directory.CreateDirectory(dest);

                File.WriteAllText(Path.Combine(dest, info.Name.Replace(".java", ".cs")), code);

                break;
            }

            Console.WriteLine();
            Console.WriteLine("Done.");
        }
    }
}
