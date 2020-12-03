using System;
using System.Collections.Generic;

namespace board_game {
    class Game {

    public Game() {}
        public void displayGrid(){
            Grid grid = new Grid();
            for (int i=0; i< grid.board.GetLength(0); i++) {
                Console.BackgroundColor = ConsoleColor.White;
                for (int j=0; j<grid.board.GetLength(1); j++) {
                    Console.Write(grid.board[i,j]);
                    if (j!=5) {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("|");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n");
        }
    }

        public void InitShips (){
            List<Boat> boats = new List<Boat>();
            Console.WriteLine("Enter coordinates to create the first ship with a 2 case length");

            Console.WriteLine("Cordinate X:");
            var x = (Console.ReadLine().ToCharArray());
            Console.WriteLine("Cordinate Y:");
            var y = (Console.ReadLine().ToCharArray());
            BoatCuirasse boatCuirasse = new BoatCuirasse(x,y);
            boats.Add(boatCuirasse);
            Console.WriteLine(boatCuirasse.X[0].ToString()+ ', ' +  boatCuirasse.Y[0].ToString());
        }

        public void PlayerInput(Grid grid) {
            Console.WriteLine("Enter coordinates to Attack on ship");
            Console.WriteLine("Cordinate X:");
            var temp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cordinate Y:");
            var temp1 = Convert.ToInt32(Console.ReadLine());
        }
    }
}