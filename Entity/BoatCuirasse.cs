using System;

namespace board_game {
    class BoatCuirasse : Boat {
        private String nom;
        public String Nom {get => nom;}
        public char[] x = new char[] {' ',' '};
        public char[] y = new char[] {' ',' '};
        public int size;
        public int Size {get => size; set => size = value;}
        public char[] X { 
            get { return x ;}
            set { x = value ;}
            }
        public char[] Y {
             get { return y ;}
             set { y = value ;}
            }
        public BoatCuirasse(char[] coordX, char[] coordY){
            this.x = coordX; 
            this.Y = coordY;
            this.size = 2;
            this.nom = "Cuirasse";
        }
    }
}