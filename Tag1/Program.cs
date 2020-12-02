using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tag1
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("input.txt");
            var lines = new List<int>();
            string line;
            int n;
            while ((line = reader.ReadLine()) != null)
            {
                n = int.Parse(line);
                lines.Add(n);
            }

            foreach(var a in lines){
                foreach(var b in lines.Where(e => e != a)){

                    foreach(var c in lines.Where(e => e != a && e != b)){

                        if((a+b+c) == 2020){
                            Console.WriteLine($"a {a}, b {b}, {c}");
                            Console.WriteLine(a*b*c);
                        } 
                    }
                }
            }

            reader.Close();

        }
    }
}
