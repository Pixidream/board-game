using System.Threading.Tasks;
using System.Collections;
using System;

namespace board_game
{
    class VRPluginPlaceBoat : IVRPlugin
    {
        Agent agent;
        Game myGame = Game.getInstance();
        int x;
        int y;
        string letterX;
        string text;
        string boatType;

        public VRPluginPlaceBoat(Agent agent)
        {
            this.agent = agent;
        }

        public async Task dispatchAction(ArrayList args)
        {
            text = args[3].ToString();
            string[] getXY = text.Split(new string[] { " " }, StringSplitOptions.None);
            letterX = getXY[0];
            y = Convert.ToInt32(getXY[1]);
            if (letterX == "a") x = 0;
            else if (letterX == "b") x = 1;
            else if (letterX == "c") x = 2;
            else if (letterX == "d") x = 3;
            else if (letterX == "e") x = 4;
            else if (letterX == "f") x = 5;

            if (getXY[1] == "un") y = 1;
            else if (getXY[1] == "deux") y = 2;
            else if (getXY[1] == "trois") y = 3;
            else if (getXY[1] == "quatre") y = 4;
            else if (getXY[1] == "cinq") y = 5;
            else if (getXY[1] == "six") y = 6;
            else y = Convert.ToInt32(getXY[1]);

            boatType = args[4].ToString();

            if (boatType == "Cuirassé")
            {
                await myGame.initShip1(x, y);
                myGame.displayGrid();
                await agent.startListening();
            }
            else if (boatType == "Destroyer")
            {
                await myGame.initShip2(x, y);
                myGame.displayGrid();
                await agent.startListening();
            }
            else if (boatType == "Nuclear chip")
            {
                await myGame.initShip3(x, y);
                myGame.displayGrid();
                await agent.startListening();
            }

            if (myGame.boat1Init && myGame.boat2Init && myGame.boat3Init)
            {
                myGame.initShipIa1();
                myGame.initShipIa2();
                myGame.initShipIa3();
                myGame.displayGrid();
                myGame.displayGridAttack();
                await agent.SynthesisToSpeakerAsync("Tous les bateaux ennemis sont positionnés, à vous de jouer !");
            }
        }
    }
}