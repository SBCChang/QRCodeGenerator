using System.Collections.Generic;
using System.IO;

namespace QRCodeGenerator
{
    public class CSVParser
    {
        private readonly string _filePath;

        public CSVParser(string filePath)
        {
            _filePath = filePath;
        }

        public List<List<string>> ReadInColumn(IEnumerable<int> columnIndexes)
        {
            var result = new List<List<string>>();
            var content = File.ReadLines(_filePath);

            foreach (var row in content)
            {
                var rowResult = new List<string>();
                var segment = row.Split(',');

                foreach (var index in columnIndexes)
                {
                    if (index < segment.Length)
                    {
                        rowResult.Add(segment[index]);
                    }
                }
                result.Add(rowResult);
            }

            return result;
        }

    }
}
