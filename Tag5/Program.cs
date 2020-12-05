using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tag5
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("input.txt");
            var seats = new List<Seat>();
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                try{  
                    var s = new Seat(){
                        Code = line
                    };
                    s.Traverse();

                    seats.Add(s);

                }catch(Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine(line);
                }
            }

            reader.Close();
                        
            Console.WriteLine($"{seats.Max(e => e.Id)} - highest id");
            var seats2 = new List<Seat>();
            for(var i = 0; i <= 127; i++){
                for(var o = 0; o <= 7; o++){
                    var seat = new Seat(){
                        Row = i,
                        Column = o,
                        Id = i*8+o
                    };
                    seats2.Add(seat);
                }
            }

            foreach(var seat in seats2){
                var found = seats.FirstOrDefault(e => e.Column == seat.Column  && e.Row == seat.Row);
                if(found == null){
                    var up = seats.FirstOrDefault(e => e.Id == seat.Id+1);
                    var down = seats.FirstOrDefault(e => e.Id == seat.Id-1);

                    if(up != null && down != null){
                        Console.WriteLine($"{seat.Id} - {seat.Row}/{seat.Column} is yours");
                    }
                }
            }
        }

        public static void getC(string s){
            int upper = 7;
            int lower = 0;
            int currentSeat = -1;
            int i = 0;
            while(i < 3){
                var c = s[i];
                i++;
                switch(c){
                    case 'R':
                        if(i-1 == 9){
                            currentSeat = upper;
                            continue; 
                        }   
                        currentSeat = (int) Math.Ceiling((upper+lower)/2.0);
                        lower = currentSeat;
                        break;
                    case 'L':
                        if(i-1 == 9){
                            currentSeat = lower;
                            continue; 
                        }   
                        currentSeat = (int) Math.Floor((upper+lower)/2.0);
                        upper = currentSeat;
                        break;
                    default:
                        throw new Exception();
                }
            }

            Console.WriteLine(currentSeat);
        }
    }

    class Seat
    {
        public string Code;
        public int Id, Row, Column;
        
        public void Traverse(){
            int upper = 127;
            int lower = 0;
            int currentRow = -1;
            var i = 0;
            while(i < 7){
                var c = Code[i];

                switch(c){
                    case 'F':
                        currentRow = (int) Math.Floor((upper+lower)/2.0);
                        upper = currentRow;
                        break;
                    case 'B':
                        currentRow = (int) Math.Ceiling((upper+lower)/2.0);
                        lower = currentRow;
                        break;
                    default:
                        throw new Exception();
                }

                i++;
            }
            
            upper = 7;
            lower = 0;
            int currentSeat = -1;
            
            while(i < 10){
                var c = Code[i];
                i++;
                switch(c){
                    case 'R':
                        if(i-1 == 9){
                            currentSeat = upper;
                            continue; 
                        }   
                        currentSeat = (int) Math.Ceiling((upper+lower)/2.0);
                        lower = currentSeat;
                        break;
                    case 'L':
                        if(i-1 == 9){
                            currentSeat = lower;
                            continue; 
                        }   
                        currentSeat = (int) Math.Floor((upper+lower)/2.0);
                        upper = currentSeat;
                        break;
                    default:
                        throw new Exception();
                }
            }
            Id = currentRow*8 + currentSeat;
            Column = currentSeat;
            Row = currentRow;
        } 

    }
}
