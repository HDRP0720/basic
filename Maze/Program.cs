using System;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();

            board.Initialize(25, player);
            player.Initialize(1, 1, board);

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;
            int lastTick = 0;
            while (true)
            {
                #region frame managing only execute at standardard 30fps 
                // frame per second
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < WAIT_TICK) continue;

                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion

                // input

                // logic
                player.Update(deltaTick);

                // rendering
                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
}
