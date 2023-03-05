using System;

namespace Maze
{
    class Board
    {
        public enum TileType { Empty, Wall }

        public TileType[,] Tile;
        public int Size { get; private set; }
        public int DestY { get; private set; }
        public int DestX { get; private set; }

        private const char CIRCLE = '\u25cf';
        private Player _player;

        public void Initialize(int size, Player player)
        {
            // if even number was input as a size, then deny to execute function, because a index starts from 0
            if (size % 2 == 0) return;

            _player = player;

            Tile = new TileType[size, size];
            Size = size;

            DestY = Size - 2;
            DestX = Size - 2;

            // GenerateBinaryTreeMaze();
            GenerateSideWinderMaze();
            // GenerateRecursiveBacktracking();
        }
        private void GenerateBinaryTreeMaze()
        {
            // Blocking the tile at even number turn
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }

            // Making the path
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    // Limiting the logic of making the path
                    if (x % 2 == 0 || y % 2 == 0) continue;
                    if (y == Size - 2 && x == Size - 2) continue;
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    // executing the logic at empty point
                    if (rand.Next(0, 2) == 0)
                        Tile[y, x + 1] = TileType.Empty;
                    else
                        Tile[y + 1, x] = TileType.Empty;
                }
            }
        }
        private void GenerateSideWinderMaze()
        {
            // Blocking the tile at even number turn       
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }

            // Making the path
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                int count = 1;
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0) continue;
                    if (y == Size - 2 && x == Size - 2) continue;
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    // executing the logic
                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        Tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }
        private void GenerateRecursiveBacktracking()
        {
            // https://developer-kua.tistory.com/27
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    // player move
                    if (y == _player.PosY && x == _player.PosX)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (y == DestY && x == DestX)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);

                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = prevColor;
        }
        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Gray;
            }
        }
    }
}
