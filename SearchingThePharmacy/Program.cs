using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Тест

namespace SearchingThePharmacy
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine("Write file name and your coordinates");
            string s = Console.ReadLine();
            string[] tmp = s.Split(' ');
            double[] vb = new double[3];
            string[] Parts = null;
            double s1, s2;
            //  double Sc;
            double Min1, Min2, Min3;
            int M1, M2, M3;
            double[] Scale = new double[10000];
            string cc = tmp[0];
            double ss1 = Double.Parse(tmp[1]);
            double ss2 = Double.Parse(tmp[2]);
            string[] apteka = File.ReadAllLines(cc);
            int n = apteka.Length;
            for (int j = 1; j < apteka.Length; j++)
            {
                Parts = apteka[j].Split('|');
                s1 = Double.Parse(Parts[2]);
                s2 = Double.Parse(Parts[3]);
                Scale[j - 1] = Math.Sqrt((ss1 - s1) * (ss1 - s1) + (ss2 - s2) * (ss2 - s2));
            }
            if (Scale[0] > Scale[1])
            {
                if (Scale[1] > Scale[2]) { Min1 = Scale[2]; Min2 = Scale[1]; Min3 = Scale[0]; M1 = 3; M2 = 2; M3 = 1; }
                else
                {
                    if (Scale[0] > Scale[2]) { Min1 = Scale[1]; Min2 = Scale[2]; Min3 = Scale[0]; M1 = 2; M2 = 3; M3 = 1; }
                    else { Min1 = Scale[1]; Min2 = Scale[0]; Min3 = Scale[2]; M1 = 2; M2 = 1; M3 = 3; }
                }
            }
            else
            {
                if (Scale[0] > Scale[2]) { Min1 = Scale[2]; Min2 = Scale[0]; Min3 = Scale[1]; M1 = 3; M2 = 1; M3 = 2; }
                else
                {
                    if (Scale[1] > Scale[2]) { Min1 = Scale[0]; Min2 = Scale[2]; Min3 = Scale[1]; M1 = 1; M2 = 3; M3 = 2; }
                    else { Min1 = Scale[0]; Min2 = Scale[1]; Min3 = Scale[2]; M1 = 1; M2 = 2; M3 = 3; }
                }
            }
            for (int i = 3; i < n - 1; i++)
            {
                if (Scale[i] < Min1) { Min3 = Min2; M3 = M2; Min2 = Min1; M2 = M1; Min1 = Scale[i]; M1 = i + 1; }
                else if (Scale[i] < Min2) { Min3 = Min2; M3 = M2; Min2 = Scale[i]; M2 = i + 1; }
                else if (Scale[i] < Min3) { Min3 = Scale[i]; M3 = i + 1; }
            }

            Parts = apteka[M1].Split('|');
            Console.WriteLine(Parts[0] + "| " + Parts[1]);
            Parts = apteka[M2].Split('|');
            Console.WriteLine(Parts[0] + "| " + Parts[1]);
            Parts = apteka[M3].Split('|');
            Console.WriteLine(Parts[0] + "| " + Parts[1]);
            //   Console.WriteLine("Min1, Min2, Min3 equals\n"+ Min1 + "\t" + M1 +"\n" + Min2 + "\t" + M2 + "\n" +  Min3 + "\t" + M3);
            Console.ReadKey();
        }
    }
}
