namespace board_game
{
    class VRPluginFactory
    {
        public static IVRPlugin GetPlugin(Agent agent, Action action)
        {
            if (action.Plugin.Equals("playerAction")) return new VRPlayerActionPlugin(agent);
            if (action.Plugin.Equals("getPlayerName")) return new VRPluginPlayerName(agent);
            if (action.Plugin.Equals("saveGame")) return new VRPluginSaveGame(agent);
            if (action.Plugin.Equals("placeBoat")) return new VRPluginPlaceBoat(agent);
            else return null;
        }
    }
}