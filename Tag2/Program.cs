using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tag2
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("input.txt");
            var passwords = new List<Password>();
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                try{  
                    passwords.Add(new Password(line.Split(" ")));
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine(passwords.Count());
            Console.WriteLine(passwords.Where(e => e.IsValid()).Count());

            reader.Close();
        }

    }

    class Password
    {
        public int Min, Max;
        public char Character;
        public string PasswordValue;

        public Password(int min, int max, char character, string password)
        {
            Min = min;
            Max = max;
            Character = character;
            PasswordValue = password;
        }

        public Password(string[] parts){
            try{
                if(parts[1].Trim(':').Length != 1){
                    throw new InvalidDataException();
                }

                Min = int.Parse(parts[0].Split('-')[0]);
                Max = int.Parse(parts[0].Split('-')[1]);
                Character = parts[1].Trim(':')[0];
                PasswordValue = parts[2];
            } catch(Exception e){
                throw e;
            }
            
        }

        public bool IsValid(){
            try{
                var first = PasswordValue[Min-1] == Character;
                var second = PasswordValue[Max-1] == Character;
                return first ^ second; 
            }catch{
                return false;
            }

        }
    }

}
