using System;

namespace board_game {
   [Serializable()]
   class Player {
        public String name;
        public String Name { 
            get {return name;} 
            set {this.name = value;}
            }
        public int score;
        public int Score { 
            get {return score;} 
            set {this.score = value;}
            }
        public Player(){
        }
        public Player(String name) {
            this.name = name ;
            this.score = 0;
        }
    }
} 