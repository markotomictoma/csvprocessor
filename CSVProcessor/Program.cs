using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var detector = new FileHelpers.Detection.SmartFormatDetector();
            const string filePath = @"c:\Users\XTOMIM\Downloads\tab6\MVC_TAB06\MVC_TAB06 - Copy.txt";
            var formats = detector.DetectFileFormat(filePath);
            foreach (var format in formats)
            {
                Console.WriteLine("Format Detected, confidence:" + format.Confidence + "%");
                var delimited = format.ClassBuilderAsDelimited;
                Console.WriteLine("    Delimiter:" + delimited.Delimiter);
                Console.WriteLine("    Fields:");
                String className = "Tab6";
                string lClass = "using FileHelpers;\n\nnamespace CSVProcessor\n{\n[DelimitedRecord(\",\")]\nclass " + className + "\n{\n";
                foreach (var field in delimited.Fields)
                {
                    string line = "        [FieldQuoted('\"', QuoteMode.OptionalForBoth)]\npublic " + field.FieldType + " " + field.FieldName + ";";
                    Console.WriteLine(line);
                    lClass += line += '\n';
                }
                lClass += "\n}\n}";
                Console.WriteLine(lClass);
                ClassGenerator.GenerateClass(className, lClass, @"c:\Users\XTOMIM\Downloads\tab6\MVC_TAB06");
            }


            var engine = new FileHelpers.FileHelperAsyncEngine<Tab6>();

            using (engine.BeginReadFile(filePath))
            {
                int cnt = 0;
                foreach (Tab6 cust in engine)
                {
                    Console.WriteLine(cust);
                    if (cnt != 0)
                    {
                        //int i = int.Parse(cust.PART_BGVG);
                    }
                }
            }





            //var engine = new FileHelpers.FileHelperEngine<Tab6>();
            //var records = engine.ReadFile(filePath);

            //foreach (var record in records)
            //{
            //    Console.WriteLine(record);
            //}
            //Console.ReadLine();
        }
    }
}
