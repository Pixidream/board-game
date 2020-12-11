using System.Text.RegularExpressions;
using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace board_game
{
    class Action
    {
        private String value;
        private String plugin;
        private ArrayList args;

        public Action(string value, string plugin)
        {
            this.value = value;
            this.plugin = plugin;
            this.args = new ArrayList();
        }

        public String Value { get => value; }

        public String Plugin { get => plugin; }
        public ArrayList Args { get => args; }

        public static ArrayList GetAllActions()
        {
            ArrayList list = new ArrayList();
            list.Add(new Action(@"(Tirez|tirez|tiré|Attaquer|attaquery) en (?<positionGroup>[a-fA-F] [0-6a-z][a-z]{0,1})", "playerAction"));
            list.Add(new Action(@"Mon nom est (?<playerName>[aA-zZ]+)", "getPlayerName"));
            list.Add(new Action(@"(Oui, sauvegarder|Non, ne pas sauvegarder)", "saveGame"));
            list.Add(new Action(@"(?<boatType>(Cuirassé|Destroyer|Nuclear chip)) en (?<boatPosition>[a-fA-F] [0-6a-z][a-z]{0,1})", "placeBoat"));
            return list;
        }

        public static Action searchAction(string text)
        {
            foreach (Action act in GetAllActions())
            {
                Match result = Regex.Match(text, act.Value);
                if (result.Success)
                {
                    Group pos = result.Groups["positionGroup"];
                    Group pseudo = result.Groups["playerName"];
                    Group posBoat = result.Groups["boatPosition"];
                    Group boatType = result.Groups["boatType"];
                    act.args.Add(pos.Value);
                    act.args.Add(pseudo.Value);
                    act.args.Add(result.Value);
                    act.args.Add(posBoat.Value);
                    act.args.Add(boatType.Value);
                    return act;
                }
            }
            return null;
        }
    }
}