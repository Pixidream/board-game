using System.IO.Compression;
using System;
using System.Collections.Generic;

namespace board_game
{
    class Game
    {
        Grid grille;
        Grid grilleIa;
        Grid grilleAttack;
        private int level = 0;
        public int Level {
            get{ return level;}
            set{ level = value;}
        } 

        public Game() {
            this.grille = new Grid();
            this.grilleIa = new Grid();
            this.grilleAttack = new Grid();
        }
        public void displayGrid()
        {
            for (int k = 0; k < this.grille.Board.GetLength(1); k++)
            {
                switch(k)
                {
                    case 0:
                        Console.Write(" A");
                        Console.Write("|");
                        break;
                    case 1:
                        Console.Write("B");
                        Console.Write("|");
                        break;
                    case 2:
                        Console.Write("C");
                        Console.Write("|");
                        break;
                    case 3:
                        Console.Write("D");
                        Console.Write("|");
                        break;
                    case 4:
                        Console.Write("E");
                        Console.Write("|");
                        break;
                    case 5:
                        Console.Write("F");
                        break;
                }
            }
           Console.Write("\n");
           for (int i = 0; i < this.grille.Board.GetLength(0); i++)
            {   
                Console.Write(i);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                for (int j = 0; j < this.grille.Board.GetLength(1); j++)
                {
                    Console.Write(this.grille.Board[i, j]);
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
                    Console.WriteLine("Type  S for South, W for West, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x > 0 && x == 5 && y > 0 && y < 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, E for East, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x > 0 && x < 5 && y == 0 && y < 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, S for South, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'E' || input == 'S' || input == 'N') t = 1;
                }
            }
            else if (x > 0 && x < 5 && y > 0 && y == 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, S for South, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'N' || input == 'W') t = 1;
                }
            }
            else if (x == 0 && x < 5 && y > 0 && y == 5)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'W') t = 1;
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
                    Console.WriteLine("Type N for North, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'E') t = 1;
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
                case 'W':
                    xx = new int[] { x, x };
                    yy = new int[] { y, y - 1 };
                    boatCuirasse.X = xx;
                    boatCuirasse.Y = yy;
                    break;
                case 'E':
                    xx = new int[] { x, x };
                    yy = new int[] { y, y + 1 };
                    boatCuirasse.X = xx;
                    boatCuirasse.Y = yy;
                    break;
                case 'S':
                    xx = new int[] { x, x + 1 };
                    yy = new int[] { y, y };
                    boatCuirasse.X = xx;
                    boatCuirasse.Y = yy;
                    break;
                case 'N':
                    xx = new int[] { x, x - 1 };
                    yy = new int[] { y, y };
                    boatCuirasse.X = xx;
                    boatCuirasse.Y = yy;
                    break;
                default:
                    Console.WriteLine("Type N for North, E for East, W for West");
                    break;
            }
            this.grille.Board[boatCuirasse.X[0], boatCuirasse.Y[0]] = '1';
            this.grille.Board[boatCuirasse.X[1], boatCuirasse.Y[1]] = '1';
            //test getter
            Console.WriteLine(boatCuirasse.X[0].ToString() + ", " + boatCuirasse.Y[0].ToString());
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
                } while (resultx == false || x > 5 );

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
            }while (this.grille.Board[x,y].Equals('1'));
   

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
                    Console.WriteLine("Type W for West, S for South, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x > 1 && x >= 4 && y > 1 && y < 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, E for East, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x > 1 && x < 4 && y <= 1 && y < 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, E for East, N for North");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'E' || input == 'S' || input == 'N') t = 1;
                }
            }
            else if (x > 1 && x < 4 && y > 1 && y >= 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, S for South, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'N' || input == 'W') t = 1;
                }
            }
            else if (x <= 1 && x < 4 && y > 1 && y >= 4)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'W') t = 1;
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
                    Console.WriteLine("Type N for North, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'E') t = 1;
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
                case 'W':
                    xx = new int[] { x, x, x };
                    yy = new int[] { y, y - 1, y - 2 };
                    boatDestroyer.X = xx;
                    boatDestroyer.Y = yy;
                    break;
                case 'E':
                    xx = new int[] { x, x, x };
                    yy = new int[] { y, y + 1, y + 2 };
                    boatDestroyer.X = xx;
                    boatDestroyer.Y = yy;
                    break;
                case 'S':
                    xx = new int[] { x, x + 1, x + 2 };
                    yy = new int[] { y, y, y };
                    boatDestroyer.X = xx;
                    boatDestroyer.Y = yy;
                    break;
                case 'N':
                    xx = new int[] { x, x - 1, x - 2 };
                    yy = new int[] { y, y, y };
                    boatDestroyer.X = xx;
                    boatDestroyer.Y = yy;
                    break;
                default:
                    Console.WriteLine("Type N for North, E for East, W for West");
                    break;
            }
            this.grille.Board[boatDestroyer.X[0], boatDestroyer.Y[0]] = '1';
            this.grille.Board[boatDestroyer.X[1], boatDestroyer.Y[1]] = '1';
            this.grille.Board[boatDestroyer.X[2], boatDestroyer.Y[2]] = '1';
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
            }while (this.grille.Board[x,y].Equals('1'));

            BoatNuclearShip boatNuclearShip = new BoatNuclearShip();

            Console.WriteLine("In which direction do you want the ship to be oriented ?");
            var t = 0;
            char input = ' ';
            if (x <= 2 && y <= 2)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type S for South, E for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'S' || input == 'E') t = 1;
                }
            }
            else if (x >= 3 && y >= 3)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for north, W for West");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'W') t = 1;
                }
            }
            else if (x >= 3 && y <= 2)
            {
                while (t == 0)
                {
                    Console.WriteLine("Type N for North, 2 for East");
                    input = char.ToUpper(Console.ReadKey().KeyChar);
                    if (input == 'N' || input == 'E') t = 1;
                }
            }
            else if (x <= 2 && y >= 3)
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
                case 'W':
                    xx = new int[] { x, x, x, x };
                    yy = new int[] { y, y - 1, y - 2, y - 3 };
                    boatNuclearShip.X = xx;
                    boatNuclearShip.Y = yy;
                    break;
                case 'E':
                    xx = new int[] { x, x, x, x };
                    yy = new int[] { y, y + 1, y + 2, y + 3 };
                    boatNuclearShip.X = xx;
                    boatNuclearShip.Y = yy;
                    break;
                case 'S':
                    xx = new int[] { x, x + 1, x + 2, x + 3 };
                    yy = new int[] { y, y, y, y };
                    boatNuclearShip.X = xx;
                    boatNuclearShip.Y = yy;
                    break;
                case 'N':
                    xx = new int[] { x, x - 1, x - 2, x - 3 };
                    yy = new int[] { y, y, y, y };
                    boatNuclearShip.X = xx;
                    boatNuclearShip.Y = yy;
                    break;
                default:
                    Console.WriteLine("Type N for North, E for East, W for West");
                    break;
            }
            this.grille.Board[boatNuclearShip.X[0], boatNuclearShip.Y[0]] = '1';
            this.grille.Board[boatNuclearShip.X[1], boatNuclearShip.Y[1]] = '1';
            this.grille.Board[boatNuclearShip.X[2], boatNuclearShip.Y[2]] = '1';
            this.grille.Board[boatNuclearShip.X[3], boatNuclearShip.Y[3]] = '1';
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

        public bool isWin(){
            var total = 0;
            for (int i = 0; i < this.grille.Board.GetLength(0); i++)
            {
                for (int j = 0; j < this.grille.Board.GetLength(1); j++)
                {
                    if(this.grilleIa.Board[i,j] == '2'){
                        total++;
                    }
                }
            }
            if(total == 9){
            return true;
            }
            else{
                return false;
            }
        }

        public void displayGridIa()
        {
            for (int k = 0; k < this.grille.Board.GetLength(1); k++)
            {
                switch(k)
                {
                    case 0:
                        Console.Write(" A");
                        Console.Write("|");
                        break;
                    case 1:
                        Console.Write("B");
                        Console.Write("|");
                        break;
                    case 2:
                        Console.Write("C");
                        Console.Write("|");
                        break;
                    case 3:
                        Console.Write("D");
                        Console.Write("|");
                        break;
                    case 4:
                        Console.Write("E");
                        Console.Write("|");
                        break;
                    case 5:
                        Console.Write("F");
                        break;
                }
            }
           Console.Write("\n");
           for (int i = 0; i < this.grilleIa.Board.GetLength(0); i++)
            {
                Console.Write(i);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                for (int j = 0; j < this.grilleIa.Board.GetLength(1); j++)
                {
                    Console.Write(this.grilleIa.Board[i, j]);
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

        public void displayGridAttack()
        {
            for (int k = 0; k < this.grilleAttack.Board.GetLength(1); k++)
            {
                switch(k)
                {
                    case 0:
                        Console.Write(" A");
                        Console.Write("|");
                        break;
                    case 1:
                        Console.Write("B");
                        Console.Write("|");
                        break;
                    case 2:
                        Console.Write("C");
                        Console.Write("|");
                        break;
                    case 3:
                        Console.Write("D");
                        Console.Write("|");
                        break;
                    case 4:
                        Console.Write("E");
                        Console.Write("|");
                        break;
                    case 5:
                        Console.Write("F");
                        break;
                }
            }
           Console.Write("\n");
           for (int i = 0; i < this.grilleAttack.Board.GetLength(0); i++)
            {   
                Console.Write(i);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                for (int j = 0; j < this.grilleAttack.Board.GetLength(1); j++)
                {
                    Console.Write(this.grilleAttack.Board[i, j]);
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
        public void initShipIa(){

                List<Boat> boats = new List<Boat>();
                Random rand = new Random();
                var x = rand.Next(0,5);
                var y = rand.Next(0,5);
                // string[] letter = new string[]{"n","s","e","w"} // tu rajouteras le reste

            BoatCuirasse boatCuirasseIA = new BoatCuirasse();
            var t = 0;
            char input = ' ';
            if (x > 0 && x < 5 && y > 0 && y < 5)
            {
                while (t == 0)
                {
                    var possibilities = "NSEW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'N' || input == 'S' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x == 0 && x < 5 && y > 0 && y < 5)
            {
                while (t == 0)
                {
                    var possibilities = "SEW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'S' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x > 0 && x == 5 && y > 0 && y < 5)
            {
                while (t == 0)
                {
                    var possibilities = "NEW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'N' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x > 0 && x < 5 && y == 0 && y < 5)
            {
                while (t == 0)
                {
                    var possibilities = "NSE";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'E' || input == 'S' || input == 'N') t = 1;
                }
            }
            else if (x > 0 && x < 5 && y > 0 && y == 5)
            {
                while (t == 0)
                {
                    var possibilities = "NSW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'S' || input == 'N' || input == 'W') t = 1;
                }
            }
            else if (x == 0 && x < 5 && y > 0 && y == 5)
            {
                while (t == 0)
                {
                    var possibilities = "SW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'S' || input == 'W') t = 1;
                }
            }
            else if (x == 0 && x < 5 && y == 0 && y < 5)
            {
                while (t == 0)
                {
                    var possibilities = "SE";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'S' || input == 'E') t = 1;
                }
            }
            else if (x > 0 && x == 5 && y == 0 && y < 5)
            {
                while (t == 0)
                {
                    var possibilities = "NE";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'N' || input == 'E') t = 1;
                }
            }
            else if (x > 0 && x == 5 && y > 0 && y == 5)
            {
                while (t == 0)
                {
                    var possibilities = "NW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'N' || input == 'W') t = 1;
                }
            }
            int[] xx;
            int[] yy;
            switch (input)
            {
                case 'W':
                    xx = new int[] { x, x };
                    yy = new int[] { y, y - 1 };
                    boatCuirasseIA.X = xx;
                    boatCuirasseIA.Y = yy;
                    break;
                case 'E':
                    xx = new int[] { x, x };
                    yy = new int[] { y, y + 1 };
                    boatCuirasseIA.X = xx;
                    boatCuirasseIA.Y = yy;
                    break;
                case 'S':
                    xx = new int[] { x, x + 1 };
                    yy = new int[] { y, y };
                    boatCuirasseIA.X = xx;
                    boatCuirasseIA.Y = yy;
                    break;
                case 'N':
                    xx = new int[] { x, x - 1 };
                    yy = new int[] { y, y };
                    boatCuirasseIA.X = xx;
                    boatCuirasseIA.Y = yy;
                    break;
                default:
                    Console.WriteLine("Type N for North, E for East, W for West");
                    break;
            }
            this.grilleIa.Board[boatCuirasseIA.X[0], boatCuirasseIA.Y[0]] = '1';
            this.grilleIa.Board[boatCuirasseIA.X[1], boatCuirasseIA.Y[1]] = '1';
        }
        
        public void initShipIa2()
        {
            List<Boat> boats = new List<Boat>();
            Random rand = new Random();
            var x = rand.Next(0,5);
            var y = rand.Next(0,5);

            BoatDestroyer boatDestroyerIa = new BoatDestroyer();

            var t = 0;
            char input = ' ';
            if (x > 1 && x < 4 && y > 1 && y < 4)
            {
                while (t == 0)
                {
                    var possibilities = "NSEW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'N' || input == 'S' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x <= 1 && x < 4 && y > 1 && y < 4)
            {
                while (t == 0)
                {
                    var possibilities = "SEW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'S' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x > 1 && x >= 4 && y > 1 && y < 4)
            {
                while (t == 0)
                {
                    var possibilities = "NEW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'N' || input == 'E' || input == 'W') t = 1;
                }
            }
            else if (x > 1 && x < 4 && y <= 1 && y < 4)
            {
                while (t == 0)
                {
                    var possibilities = "NSE";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'E' || input == 'S' || input == 'N') t = 1;
                }
            }
            else if (x > 1 && x < 4 && y > 1 && y >= 4)
            {
                while (t == 0)
                {
                    var possibilities = "NSW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'S' || input == 'N' || input == 'W') t = 1;
                }
            }
            else if (x <= 1 && x < 4 && y > 1 && y >= 4)
            {
                while (t == 0)
                {
                    var possibilities = "SW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'S' || input == 'W') t = 1;
                }
            }
            else if (x <= 1 && x < 4 && y <= 1 && y < 4)
            {
                while (t == 0)
                {
                    var possibilities = "SE";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'S' || input == 'E') t = 1;
                }
            }
            else if (x > 1 && x >= 4 && y <= 1 && y < 4)
            {
                while (t == 0)
                {
                    var possibilities = "NE";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'N' || input == 'E') t = 1;
                }
            }
            else if (x > 1 && x >= 4 && y > 1 && y >= 4)
            {
                while (t == 0)
                {
                    var possibilities = "NW";
                    input = possibilities[rand.Next(possibilities.Length)];
                    if (input == 'N' || input == 'W') t = 1;
                }
            }
            int[] xx;
            int[] yy;

            switch (input)
            {
                case 'W':
                    xx = new int[] { x, x, x };
                    yy = new int[] { y, y - 1, y - 2 };
                    boatDestroyerIa.X = xx;
                    boatDestroyerIa.Y = yy;
                    break;
                case 'E':
                    xx = new int[] { x, x, x };
                    yy = new int[] { y, y + 1, y + 2 };
                    boatDestroyerIa.X = xx;
                    boatDestroyerIa.Y = yy;
                    break;
                case 'S':
                    xx = new int[] { x, x + 1, x + 2 };
                    yy = new int[] { y, y, y };
                    boatDestroyerIa.X = xx;
                    boatDestroyerIa.Y = yy;
                    break;
                case 'N':
                    xx = new int[] { x, x - 1, x - 2 };
                    yy = new int[] { y, y, y };
                    boatDestroyerIa.X = xx;
                    boatDestroyerIa.Y = yy;
                    break;
                default:
                    Console.WriteLine("Type N for North, E for East, W for West");
                    break;
            }
            this.grilleIa.Board[boatDestroyerIa.X[0], boatDestroyerIa.Y[0]] = '1';
            this.grilleIa.Board[boatDestroyerIa.X[1], boatDestroyerIa.Y[1]] = '1';
            this.grilleIa.Board[boatDestroyerIa.X[2], boatDestroyerIa.Y[2]] = '1';
        }

        public void Attack(){
            bool resultx = false;
                bool resulty = false;
                int x;
                int y;
                Console.Write("\n Choose attack location");
            do{
                string inputx;
                Console.Write("\n Enter the coordinates of x: ");
                inputx = Console.ReadLine();
                resultx = int.TryParse(inputx, out x);
                if (resultx == false || x > 5){
                    Console.WriteLine(resultx +"t"+  x);
                    Console.Write("\n Please Enter Numbers between 0 and 5 Only.");
                }
                else{
                    Console.Write("\n you choose x = "+ (x));
                    break;
                }
            }while (resultx == false || x > 5);

            do{
                string inputy;
                Console.WriteLine("\n Enter the coordinates of y: ");
                inputy = Console.ReadLine();
                resulty = int.TryParse(inputy, out y);
                if (resulty == false || y > 5){
                    Console.WriteLine("Please Enter Numbers between 0 and 5 Only.");
                }
                else{
                    Console.WriteLine("you choose y = "+(y));
                    break;
                }
            }while (resulty == false || y >5);

            if(this.grilleIa.Board[x,y].Equals('1')){
                this.grilleIa.Board[x,y] = '2';
                this.grilleAttack.Board[x,y] = 'X';
                Console.WriteLine("Bateau touché en x : "+x+" y : "+y);
            }
            else if(this.grilleIa.Board[x,y].Equals(' ')){
                    this.grilleAttack.Board[x,y] = 'o';
            }
         
            // if (getBoatPosition()) {
            //     this.grilleIa.Board[x,y] = '2';
            //     this.grilleAttack.Board[x,y] = 'X';
            //     Console.WriteLine($"Bateau touché en {x};{y}");
            // } else {
            //     this.grilleAttack.Board[x,y] = 'O';
            //     Console.WriteLine($"Coup loupé pour: {x};{y}");
            // }
        }

        private Boolean getBoatPosition() {
            for(int i = 0; i < this.grilleIa.Board.GetLength(0); i++) {
                for (int j = 0; j < this.grilleIa.Board.GetLength(1); j++) {
                    if (this.grilleIa.Board[i, j].Equals('1')) return true;
                    else return false;
                }
            }
            return false;
        }
    }
}

