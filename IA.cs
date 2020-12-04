using System.Collections;
using System.Threading.Tasks;

namespace board_game {
    interface IA {
        Task playComputerTurn(ArrayList args);
    }
}