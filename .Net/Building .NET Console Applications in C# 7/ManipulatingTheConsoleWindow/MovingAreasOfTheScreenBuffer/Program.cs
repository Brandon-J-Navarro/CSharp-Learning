﻿namespace MovingAreasOfTheScreenBuffer;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("line 1");
        Console.WriteLine("line 2");
        Console.WriteLine("line 3");

        Console.ReadLine();

        //Console.MoveBufferArea(5,0,4,3,0,10);
        Console.MoveBufferArea(5, 0, 1, 3, 0, 10,'x',ConsoleColor.Black,ConsoleColor.White);

        Console.ReadLine();
    }
}