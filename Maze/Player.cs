using System;
using System.Collections.Generic;

namespace Maze
{
    class Pos
    {
        public Pos(int y, int x) { Y = y; X = x; }
        public int Y;
        public int X;
    }
    class Player
    {
        enum Dir { Up, Left, Down, Right }

        public int PosX { get; private set; }
        public int PosY { get; private set; }

        Random _rand = new Random();
        Board _board;

        int _dir = (int)Dir.Up;
        List<Pos> _points = new List<Pos>();

        public void Initialize(int posY, int posX, Board board)
        {
            PosX = posX;
            PosY = posY;

            _board = board;

            // RandomMovePathFinding();
            // RightHandPathFinding();
            BFSPathFinding();
        }
        private void RandomMovePathFinding()
        {
            _points.Add(new Pos(PosY, PosX));

            while (PosY != _board.DestY || PosX != _board.DestX)
            {
                int randValue = _rand.Next(0, 5); // Up[0], Left[1], Down[2], Right[3]
                switch (randValue)
                {
                    case 0:
                        if (PosY - 1 >= 0 && _board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                            PosY = PosY - 1;
                        _points.Add(new Pos(PosY, PosX));
                        break;
                    case 1:
                        if (PosY + 1 < _board.Size && _board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                            PosY = PosY + 1;
                        _points.Add(new Pos(PosY, PosX));
                        break;
                    case 2:
                        if (PosX - 1 >= 0 && _board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
                            PosX = PosX - 1;
                        _points.Add(new Pos(PosY, PosX));
                        break;
                    case 3:
                        if (PosX + 1 < _board.Size && _board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
                            PosX = PosX + 1;
                        _points.Add(new Pos(PosY, PosX));
                        break;
                }
            }
        }
        private void RightHandPathFinding()
        {
            // Because enum Dir order is up, left, down, right, up-direction is assumed as front state
            int[] frontY = new int[] { -1, 0, 1, 0 };
            int[] frontX = new int[] { 0, -1, 0, 1 };
            int[] rightY = new int[] { 0, -1, 0, 1 };
            int[] rightX = new int[] { 1, 0, -1, 0 };

            _points.Add(new Pos(PosY, PosX));

            while (PosY != _board.DestY || PosX != _board.DestX)
            {
                // check right-hand direction is possible
                if (_board.Tile[PosY + rightY[_dir], PosX + rightX[_dir]] == Board.TileType.Empty)
                {
                    // rotate right-hand at 90 degree
                    _dir = (_dir - 1 + 4) % 4;

                    // one step forward
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];

                    _points.Add(new Pos(PosY, PosX));

                }
                // check forward direction is possible
                else if (_board.Tile[PosY + frontY[_dir], PosX + frontX[_dir]] == Board.TileType.Empty)
                {
                    // one step forward
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];

                    _points.Add(new Pos(PosY, PosX));
                }
                else // turn left 90 degree 
                {
                    _dir = (_dir + 1 + 4) % 4;
                }
            }
        }
        private void BFSPathFinding()
        {
            int[] deltaY = new int[] { -1, 0, 1, 0 };
            int[] deltaX = new int[] { 0, -1, 0, 1 };

            bool[,] found = new bool[_board.Size, _board.Size];
            Pos[,] parent = new Pos[_board.Size, _board.Size];

            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(PosY, PosX));

            found[PosY, PosX] = true;
            parent[PosY, PosX] = new Pos(PosY, PosX);

            while (q.Count > 0)
            {
                Pos pos = q.Dequeue();
                int nowY = pos.Y;
                int nowX = pos.X;

                for (int i = 0; i < 4; i++)
                {
                    int nextY = nowY + deltaY[i];
                    int nextX = nowX + deltaX[i];

                    if (nextX < 0 || nextX >= _board.Size || nextY < 0 || nextY >= _board.Size) continue; // check coord beyound board

                    if (_board.Tile[nextY, nextX] == Board.TileType.Wall) continue; // check next coord is wall

                    if (found[nextY, nextX]) continue; // check next coord already booked

                    q.Enqueue(new Pos(nextY, nextX));

                    found[nextY, nextX] = true;
                    parent[nextY, nextX] = new Pos(nowY, nowX);
                }
            }

            int y = _board.DestY;
            int x = _board.DestX;
            while (parent[y, x].Y != y || parent[y, x].X != x)
            {
                _points.Add(new Pos(y, x));
                Pos pos = parent[y, x];
                y = pos.Y;
                x = pos.X;
            }
            _points.Add(new Pos(y, x));
            _points.Reverse();
        }


        const int MOVE_TICK = 10;
        int _sumTick = 0;
        int _lastIndex = 0;
        public void Update(int deltaTick)
        {
            if (_lastIndex >= _points.Count) return;

            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;

                PosY = _points[_lastIndex].Y;
                PosX = _points[_lastIndex].X;
                _lastIndex++;
            }
        }
    }
}
