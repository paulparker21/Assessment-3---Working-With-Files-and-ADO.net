using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3___Working_With_Files_and_ADO.net
{
    class Program
    {
        static void Main(string[] args)
        {
            var inFile = "../../students.txt"; //the file placed here is the input file 
            var outFile = Directory.GetCurrentDirectory() + "\\" + "finalGrade"; // This goes to the bin/debug folder in the assingment file

            StreamReader streamReader = new StreamReader(inFile);
            var line = "";
            var outf = "";
            string allTests = "";
            while ((line = streamReader.ReadLine())!= null) 
            {
                Console.WriteLine(line);
                var values = line.Split('|');
                int testVal1 = int.Parse(values[1]);
                int testVal2 = int.Parse(values[2]);
                int testVal3 = int.Parse(values[3]);
                int averageVal = (testVal1 + testVal2 + testVal3) / 3;
                allTests = allTests + values[0] + "|" + averageVal.ToString() + "\n";

                foreach (string v in values)
                {
                    Console.WriteLine(v);
                    outf += v + "\n";
                
                }
            }
            streamReader.Close();

            var values2 = allTests.Split('\n');
            for (int i = 0; i < values2.Length-1; i++)
            {
                StreamWriter streamWriter = new StreamWriter(outFile + i + ".txt");
                streamWriter.Write(values2[i]);
                streamWriter.Close();

            }
        }
    }
}
