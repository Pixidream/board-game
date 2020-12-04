using System.IO.Compression;
using System;
using System.Collections.Generic;

namespace board_game
{
    class Game
    {
        public Game() { }
        public void displayGrid()
        {
            Grid grid = new Grid();
            for (int i = 0; i < grid.board.GetLength(0); i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                for (int j = 0; j < grid.board.GetLength(1); j++)
                {
                    Console.Write(grid.board[i, j]);
                    if (j != 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("|");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n");
            }
        }
        public void initPlayer()
        {

            Console.WriteLine("Enter your name");
            String playerName = Console.ReadLine();
            Player player = new Player();
            player.Name = playerName;
        }
        public void initShip1()
        {
            List<Boat> boats = new List<Boat>();

                bool resultx = false;
                bool resulty = false;
                int x;
                int y;
            
                Console.Write("\n Choose the location of your first Ship : Cuirasse ");  
            do{
                string inputx;
                Console.Write("\n Enter the coordinates of x: ");
                inputx = Console.ReadLine();
                resultx = int.TryParse(inputx, out x);
                if (resultx == false || x > 5)
                {
                    Console.WriteLine(resultx +"t"+  x);
                    Console.Write("\n Please Enter Numbers between 0 and 5 Only.");
                }
                else
                {
                    Console.Write("\n you choose x = "+ (x));
                    break;
                }
            } while (resultx == false || x > 5);

            do{
                string inputy;
                Console.WriteLine("\n Enter the coordinates of y: ");
                inputy = Console.ReadLine();
                resulty = int.TryParse(inputy, out y);
                if (resulty == false || y > 5)
                {
                    Console.WriteLine("Please Enter Numbers between 0 and 5 Only.");
                }
                else
                {
                    Console.WriteLine("you choose y = "+(y));
                    break;
                }
            }while (resulty == false || y >5);

            BoatCuirasse boatCuirasse = new BoatCuirasse();

            Console.WriteLine("In which direction do you want the ship to be oriented ?");
            var t = 0;
            char input = ' ';
            if (x > 0 && x < 5 && y > 0 && y < 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for north, S for South, E for East, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'S' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x == 0 && x < 5 && y > 0 && y < 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, S for South, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'E' || input == 'N') t = 1;
                }
            }
            else if (x > 0 && x == 5 && y > 0 && y < 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, S for South, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'S' || input == 'W') t = 1;
                }
            }
            else if (x > 0 && x < 5 && y == 0 && y < 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, E for East, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'E' || input == 'S' || input == 'W') t = 1;
                }
            }
            else if (x > 0 && x < 5 && y > 0 && y == 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, E for East, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'E' || input == 'N' || input == 'W') t = 1;
                }
            }
            else if (x == 0 && x < 5 && y > 0 && y == 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'E') t = 1;
                }
            }
            else if (x == 0 && x < 5 && y == 0 && y < 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'E') t = 1;
                }
            }
            else if (x > 0 && x == 5 && y == 0 && y < 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'W') t = 1;
                }
            }
            else if (x > 0 && x == 5 && y > 0 && y == 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'W') t = 1;
                }
            }
            int[] xx;
            int[] yy;

            switch (input)
            {
                case 'N':
                    xx = new int[] { x, x };
                    yy = new int[] { y, y - 1 };
                    boatCuirasse.X = xx;
                    boatCuirasse.Y = yy;
                    break;
                case 'S':
                    xx = new int[] { x, x };
                    yy = new int[] { y, y + 1 };
                    boatCuirasse.X = xx;
                    boatCuirasse.Y = yy;
                    break;
                case 'E':
                    xx = new int[] { x, x + 1 };
                    yy = new int[] { y, y };
                    boatCuirasse.X = xx;
                    boatCuirasse.Y = yy;
                    break;
                case 'W':
                    xx = new int[] { x, x - 1 };
                    yy = new int[] { y, y };
                    boatCuirasse.X = xx;
                    boatCuirasse.Y = yy;
                    break;
                default:
                    Console.WriteLine("Type N for North, E for East, W for West");
                    break;
            }
            //test getter
            Console.WriteLine(boatCuirasse.X[1].ToString() + ", " + boatCuirasse.Y[1].ToString());
        }
        public void initShip2()
        {
            List<Boat> boats = new List<Boat>();

                bool resultx = false;
                bool resulty = false;
                int x;
                int y;
                Console.Write("\n Choose the location of your second Ship : Destroyer ");
            do{
                string inputx;
                Console.Write("\n Enter the coordinates of x: ");
                inputx = Console.ReadLine();
                resultx = int.TryParse(inputx, out x);
                if (resultx == false || x > 5)
                {
                    Console.WriteLine(resultx +"t"+  x);
                    Console.Write("\n Please Enter Numbers between 0 and 5 Only.");
                }
                else
                {
                    Console.Write("\n you choose x = "+ (x));
                    break;
                }
            } while (resultx == false || x > 5);

            do{
                string inputy;
                Console.WriteLine("\n Enter the coordinates of y: ");
                inputy = Console.ReadLine();
                resulty = int.TryParse(inputy, out y);
                if (resulty == false || y > 5)
                {
                    Console.WriteLine("Please Enter Numbers between 0 and 5 Only.");
                }
                else
                {
                    Console.WriteLine("you choose y = "+(y));
                    break;
                }
            }while (resulty == false || y >5);

            BoatDestroyer boatDestroyer = new BoatDestroyer();

            Console.WriteLine("In which direction do you want the ship to be oriented ?");
            var t = 0;
            char input = ' ';
            if (x > 1 && x < 4 && y > 1 && y < 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for north, S for South, E for East, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'S' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x <= 1 && x < 4 && y > 1 && y < 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, S for South, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'E' || input == 'N') t = 1;
                }
            }
            else if (x > 1 && x >= 4 && y > 1 && y < 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, S for South, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'S' || input == 'W') t = 1;
                }
            }
            else if (x > 1 && x < 4 && y <= 1 && y < 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, E for East, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'E' || input == 'S' || input == 'W') t = 1;
                }
            }
            else if (x > 1 && x < 4 && y > 1 && y <= 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, E for East, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'E' || input == 'N' || input == 'W') t = 1;
                }
            }
            else if (x <= 1 && x < 4 && y > 1 && y >= 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'E') t = 1;
                }
            }
            else if (x <= 1 && x < 4 && y <= 1 && y < 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'E') t = 1;
                }
            }
            else if (x > 1 && x >= 4 && y <= 1 && y < 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'W') t = 1;
                }
            }
            else if (x > 1 && x >= 4 && y > 1 && y >= 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'W') t = 1;
                }
            }
            int[] xx;
            int[] yy;

            switch (input)
            {
                case 'N':
                    xx = new int[] { x, x, x };
                    yy = new int[] { y, y - 1, y - 2 };
                    boatDestroyer.X = xx;
                    boatDestroyer.Y = yy;
                    break;
                case 'S':
                    xx = new int[] { x, x, x };
                    yy = new int[] { y, y + 1, y + 2 };
                    boatDestroyer.X = xx;
                    boatDestroyer.Y = yy;
                    break;
                case 'E':
                    xx = new int[] { x, x + 1, x + 2 };
                    yy = new int[] { y, y, y };
                    boatDestroyer.X = xx;
                    boatDestroyer.Y = yy;
                    break;
                case 'W':
                    xx = new int[] { x, x - 1, x - 2 };
                    yy = new int[] { y, y, y };
                    boatDestroyer.X = xx;
                    boatDestroyer.Y = yy;
                    break;
                default:
                    Console.WriteLine("Type N for North, E for East, W for West");
                    break;
            }
            //test getter
            Console.WriteLine(boatDestroyer.X[2].ToString() + ", " + boatDestroyer.Y[2].ToString());
        }
        public void initShip3()
        {
            List<Boat> boats = new List<Boat>();

                bool resultx = false;
                bool resulty = false;
                int x;
                int y;
                Console.Write("\n Choose the location of your third Ship : NuclearShip ");
            do{
                string inputx;
                Console.Write("\n Enter the coordinates of x: ");
                inputx = Console.ReadLine();
                resultx = int.TryParse(inputx, out x);
                if (resultx == false || x > 5)
                {
                    Console.WriteLine(resultx +"t"+  x);
                    Console.Write("\n Please Enter Numbers between 0 and 5 Only.");
                }
                else
                {
                    Console.Write("\n you choose x = "+ (x));
                    break;
                }
            } while (resultx == false || x > 5);

            do{
                string inputy;
                Console.WriteLine("\n Enter the coordinates of y: ");
                inputy = Console.ReadLine();
                resulty = int.TryParse(inputy, out y);
                if (resulty == false || y > 5)
                {
                    Console.WriteLine("Please Enter Numbers between 0 and 5 Only.");
                }
                else
                {
                    Console.WriteLine("you choose y = "+(y));
                    break;
                }
            }while (resulty == false || y >5);

            BoatNuclearShip boatNuclearShip = new BoatNuclearShip();

            Console.WriteLine("In which direction do you want the ship to be oriented ?");
            var t = 0;
            char input = ' ';
            if (x > 3 && x <= 3 && y > 3 && y <= 3)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for north, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'W') t = 1;
                }
            }
            else if (x < 3 && x >= 3 && y > 3 && y <= 3)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for north, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'E') t = 1;
                }
            }
            else if (x < 3 && x >= 3 && y < 3 && y >= 3)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'E') t = 1;
                }
            }
            else if (x > 3 && x <= 3 && y < 3 && y >= 3)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'W') t = 1;
                }
            }
            int[] xx;
            int[] yy;

            switch (input)
            {
                case 'N':
                    xx = new int[] { x, x, x };
                    yy = new int[] { y, y - 1, y - 2, y - 3 };
                    boatNuclearShip.X = xx;
                    boatNuclearShip.Y = yy;
                    break;
                case 'S':
                    xx = new int[] { x, x, x };
                    yy = new int[] { y, y + 1, y + 2, y - 3 };
                    boatNuclearShip.X = xx;
                    boatNuclearShip.Y = yy;
                    break;
                case 'E':
                    xx = new int[] { x, x + 1, x + 2, x + 3 };
                    yy = new int[] { y, y, y };
                    boatNuclearShip.X = xx;
                    boatNuclearShip.Y = yy;
                    break;
                case 'W':
                    xx = new int[] { x, x - 1, x - 2, x -3 };
                    yy = new int[] { y, y, y };
                    boatNuclearShip.X = xx;
                    boatNuclearShip.Y = yy;
                    break;
                default:
                    Console.WriteLine("Type N for North, E for East, W for West");
                    break;
            }
            //test getter
            Console.WriteLine(boatNuclearShip.X[3].ToString() + ", " + boatNuclearShip.Y[3].ToString());
        }

        public void PlayerInput(Grid grid)
        {
            Console.WriteLine("Enter coordinates to Attack on ship");
            Console.WriteLine("Cordinate X:");
            var temp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cordinate Y:");
            var temp1 = Convert.ToInt32(Console.ReadLine());
        }
    }
}

