using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tag4
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("input.txt");
            string line;
            var passports = new List<Passport>();
            var passport = new Passport();

            while ((line = reader.ReadLine()) != null)
            {
                try{  

                    if(line == ""){
                        passports.Add(passport);
                        passport = new Passport();
                        continue;
                    }

                    var fields = line.Split(" ");
                    
                    for(var i = 0; i < fields.Length; i++){
                        var att = fields[i].Split(":");
                        
                        passport.setField(att);
                    }



                }catch(Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine(line);
                }
            }
            passports.Add(passport);
            Console.WriteLine(passports.Where(p => p.IsValid()).Count());
            reader.Close();
        }

        
    }

    class Passport
    {
        public string BirthYear = "";
        public string IssueYear = "";
        public string ExpirationYear = "";
        public string Height = "";
        public string HairColor = "";
        public string EyeColor = "";
        public string PassportID = "";
        public string CountryID = "";

        private Regex rx = new Regex("^#(?:[0-9a-fA-F]{3}){1,2}$");
        private List<string> haircolors = new List<string>(){"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
        public void setField(string[] att){
            var field = att[0];
            var value = att[1];

            switch (field)
            {
                case "byr":
                    BirthYear = value;
                    break;
                case "iyr":
                    IssueYear = value;
                    break;
                case "eyr":
                    ExpirationYear = value;
                    break;
                case "hgt":
                    Height = value;
                    break;
                case "hcl":
                    HairColor = value;
                    break;
                case "ecl":
                    EyeColor = value;
                    break;
                case "pid":
                    PassportID = value;
                    break;
                case "cid":
                    CountryID = value;
                    break;
                default:
                    throw new InvalidDataException();
            }

        }
        public bool IsValid(){

            var byr = (int.TryParse(BirthYear, out var by) && by <= 2020 && by >= 1920);
            var iyr = (int.TryParse(IssueYear, out var iy) && iy <= 2020 && iy >= 2010);
            var eyr = (int.TryParse(ExpirationYear, out var ey) && ey <= 2030 && ey >= 2020);

            var hgt = (Height.EndsWith("cm") && int.TryParse(Height.Substring(0,Height.Length-2), out var h1) && h1 >= 150 && h1 <= 193) ||  
                    (Height.EndsWith("in") && int.TryParse(Height.Substring(0,Height.Length-2), out var h2) && h2 >= 59 && h2 <= 76);   

            var hcl = haircolors.Contains(EyeColor);
            var pid = int.TryParse(PassportID, out var res) && PassportID.Length == 9;
            var ecl = rx.IsMatch(HairColor);

            return byr && iyr && eyr && hgt && hcl && pid && ecl;
        }
    }
}