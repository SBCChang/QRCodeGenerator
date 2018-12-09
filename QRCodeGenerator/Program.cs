using System;

namespace QRCodeGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parser = new CSVParser("D:\\mapping.csv");
            var content = parser.ReadInColumn(new int[] { 0, 1 });

            foreach (var row in content)
            {
                var image = QRCoder.Encode(row[0]);
                QRCoder.Output(row[1], image);
            }

            Console.ReadKey();
        }
    }
}
