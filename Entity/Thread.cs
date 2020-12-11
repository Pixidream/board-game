using System;

namespace board_game
{
    class ReadlineThread
    {
        public delegate void handler();

        public handler callback;

        public void ThreadLoop()
        {
            Console.ReadLine();
        }
    }
}