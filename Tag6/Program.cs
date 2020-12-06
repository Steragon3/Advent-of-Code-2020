using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Tag6
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("input.txt");
            string line;
            var groups = new List<Group>();
            var group = new Group();
            while ((line = reader.ReadLine()) != null)
            {
                try{
                    if(line == "") {
                        groups.Add(group);
                        group = new Group();
                    }else{
                        group.Anwers.Add(line);
                    }
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine(line);
                }
            }
            groups.Add(group);
            group = new Group();

            Console.WriteLine(groups.Sum(e => e.Count()));

            reader.Close();
                        
          
        }
    }

    class Group
    {
        public List<string> Anwers = new List<string>();
        
        public int Count(){
            var yes = new List<char>();
            foreach(var person in Anwers){
                for(var i = 0; i < person.Length; i++){
                    var answer = person[i];
                    yes.Add(answer);
                }
            }
            var yescope = new List<char>();
            
            var count = 0;
            foreach(var cont in yes){
                if(yes.FindAll(e => e == cont).Count == Anwers.Count){
                    if(yescope.Contains(cont) == false) yescope.Add(cont);
                }
            }

            return yescope.Count;
        }
    }
}
