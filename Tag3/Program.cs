using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Tag3
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("input.txt");
            string line;
            int x = 0;
            int y = 0;
            int index = 0;
            int count = 0;
            string curline ="";
            while ((line = reader.ReadLine()) != null)
            {
                try{  
                    curline = line;
                    if(index == y){

                        while(curline.Length <= x){
                            curline = curline+line;
                        } 
                        if(curline[x] == '#') count++;
                        y+=2;
                        x+=1;
                    }
                    index++;
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine(count + "Trees");


            reader.Close();
        }
    }
}
