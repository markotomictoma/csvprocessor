using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVProcessor
{
    public class ClassGenerator
    {
        public static void GenerateClass(String name, String content, String path)
        {
            string lPath = path + "\\" + name + ".cs";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(lPath))
                {
                    sw.WriteLine(content);
                }
            }
        }
    }
}
