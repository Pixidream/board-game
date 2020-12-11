using System;
using System.Threading.Tasks;
using System.Collections;

namespace board_game
{
    class VRPluginSaveGame : IVRPlugin
    {
        Agent agent;
        Game myGame = Game.getInstance();
        string accept;

        public VRPluginSaveGame(Agent agent)
        {
            this.agent = agent;
        }

        public async Task dispatchAction(ArrayList args)
        {
            accept = args[2].ToString();
            if (accept == "Oui, sauvegarder")
            {
                await agent.SynthesisToSpeakerAsync("Partie sauvegardé !");
                myGame.save();
            }
            else
            {
                await agent.SynthesisToSpeakerAsync("La partie ne sera pas sauvegardé !");
            }
        }
    }
}