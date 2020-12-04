using System;
using DotNetEnv;

namespace board_game {
    class Program {
        static Agent warshipAgent = Agent.getInstance(DotNetEnv.Env.GetString("AZURE_API_KEY"), DotNetEnv.Env.GetString("AZURE_API_LOCATION"));
        static void Main(string[] args) {
            // load env variables
            DotNetEnv.Env.Load();
            warshipAgent.onSpeech += CallbackVoice;
            warshipAgent.startListening();
            Game myGame = new Game();
        	myGame.displayGrid();
            myGame.initPlayer();
            Save save = new Save();
            myGame.initShip1();
            myGame.initShip2();
            myGame.initShip3();
        }

        static async void CallbackVoice(string text) {
            await warshipAgent.stopListening();
            await warshipAgent.SynthesisToSpeackerAsync(text);
        }
    }
}