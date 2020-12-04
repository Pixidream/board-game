using System;

namespace board_game {
    class Player {

        public String name;

        public String Name { 
            get {return name;} 
            set {this.name = value;}
            }
        public Player(){
        }
        public Player(String name) {
            this.name = name ;
        }
    }
} 