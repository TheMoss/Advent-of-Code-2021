using System;

namespace AoC_Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
                        
            CommandToCoordinatesParser parser = new CommandToCoordinatesParser();
            Console.WriteLine(parser.ExecuteCommands());

        }
    }


    public class CommandToCoordinatesParser
    {

       string[] commands = System.IO.File.ReadAllLines(@"D:\Projects\AoC\AoC Day 2\AoC Day 2\Commands.txt");



        public int ExecuteCommands()
        {
            Submarine submarine = new();
            
            foreach(var command in commands)
            {
                var splitCommand = command.Split(' ');
                var direction = splitCommand[0];
                var value = Int32.Parse(splitCommand[1]);
                MoveSubmarine(submarine, value, direction );
            }

            // var point = submarine.GetCoordinates();
            // var x = point.x;
            // var y = point.y;
            // x - horizontal
            // y - high
            var (x, y, aim) = submarine.GetCoordinates();
            return x * y;

        }

        public int MoveSubmarine(Submarine submarine, int value, string direction)
        {
                      

            switch (direction)
            {
                case ("forward"):
                    submarine.Forward(value);
                    break;
                case ("up"):
                    submarine.Up(value);
                    break;
                case ("down"):
                   submarine.Down(value);
                    break;
                case ("backward"):
                    submarine.Backward(value);
                    break;
            }
            
            return 0;

        }




    }

    public class Submarine
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Aim { get; private set; }

        // x+ - forward
        // x- - backward
        // y+ - down
        // y- - up

        public void Forward(int n)
        {
            Y += Aim * n;
            X += n;
        }

        public void Backward(int n) => X -= n;

        public void Down(int n) => Aim += n;

        public void Up(int n) => Aim -= n;

        
        

       

        // Tuple<int, int> tuple = (x = X, y = Y)
        // tuple.x tuple.Item1
        // tuple.y tuple.Item2
        public (int, int, int) GetCoordinates() => (x: X, y: Y, aim:Aim);

    }
}