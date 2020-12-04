using System.Collections.Generic;
using System.Collections;
using System;
using System.Threading.Tasks;

namespace board_game {
    class IALevelOne: IA {
        private int x;
        private int y;
        Random rand;
        private List<int> action;
        public IALevelOne(List<int> action) {
            this.action = action;
        }

        public Task playComputerTurn(ArrayList args) {
            rand = new Random();
            x = rand.Next(0, 6);
            y = rand.Next(0,6);
            action.Add(x);
            action.Add(y);
            return Task.FromResult<List<int>>(action);
        }
    }
}