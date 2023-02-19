using System.IO;
using System.Linq;

namespace SmartVault.Program
{
    partial class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            WriteEveryThirdFileToFile(args[0]);
            GetAllFileSizes();
        }

        private static void GetAllFileSizes()
        {
            var totalFileSize = Directory.GetFiles(@"..\..\..\..\BusinessObjectSchema").Sum(file => new FileInfo(file).Length);
        }

        private static void WriteEveryThirdFileToFile(string accountId)
        {
            var outputPath = "output.txt";
            using (var writer = new StreamWriter(outputPath))
            {
                var files = Directory.GetFiles(@"..\..\..\..\BusinessObjectSchema");
                for (int i = 0; i < files.Length; i++)
                {
                    if ((i + 1) % 3 == 0)
                    {
                        var fileContents = File.ReadAllText(files[i]);
                        writer.Write(fileContents);
                    }
                }
            }
        }
    }
}