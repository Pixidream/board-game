namespace board_game
{
    class VRPluginFactory
    {
        public static IVRPlugin GetPlugin(Agent agent, Action action)
        {
            if (action.Plugin.Equals("playerAction")) return new VRPlayerActionPlugin(agent);
            else return null;
        }
    }
}