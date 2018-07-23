using System;
using System.Diagnostics;

namespace _2048
{
    public class Game
    {

        public int[,] Tiles { get; set; } = new int[4, 4];

        private const bool shouldGenerateNewTiles = true;

        public int GetScore()
        {
            int score = 0;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    score += Tiles[x, y];
                }
            }
            return score;
        }

        public void ResetGame()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    Tiles[x, y] = 0;
                }
            }
            if (shouldGenerateNewTiles)
            {
                PopulateRandomTile();
                PopulateRandomTile();
            }
            else
            {
                PopulateTile(0, 0, 2);
                PopulateTile(3, 0, 2);
            }
        }

        private void PopulateTile(int x, int y, int value)
        {
            if (Tiles[x, y] != 0)
            {
                Console.WriteLine("Attempting to populate a populated tile!!!");
            }
            else
            {
                Tiles[x, y] = value;
            }
        }

        private void PopulateRandomTile()
        {
            Random rnd = new Random();
            bool hasPlaced = false;
            do
            {
                int x = rnd.Next(4);
                int y = rnd.Next(4);
                if (Tiles[x, y] == 0)
                {
                    Tiles[x, y] = rnd.Next(100) < 90 ? 2 : 4;
                    hasPlaced = true;
                    Console.WriteLine("New tile placed at " + x + ", " + y);
                }
            } while (!hasPlaced);
        }

        public MoveResponse RegisterDirection(Direction direction)
        {
            Debug.WriteLine("Attempt move " + direction.ToString());
            if (GameFinished())
            {
                return MoveResponse.END_GAME;
            }
            if (!CanMove(direction))
            {
                return MoveResponse.CANNOT_MOVE;
            }
            Debug.WriteLine("Can move " + direction.ToString());
            Move(direction);
            if (shouldGenerateNewTiles)
            {
                PopulateRandomTile();
            }
            return MoveResponse.CAN_MOVE;
        }

        private void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    MoveUp();
                    break;
                case Direction.DOWN:
                    MoveDown();
                    break;
                case Direction.LEFT:
                    MoveLeft();
                    break;
                case Direction.RIGHT:
                    MoveRight();
                    break;
            }
        }

        private void MoveToNewLocation(int x, int y, int newX, int newY)
        {
            Debug.WriteLine("Moving " + x + ", " + y + " to " + newX + ", " + newY);
            if (Tiles[newX, newY] == 0)
            {
                int temp = Tiles[x, y];
                Tiles[x, y] = 0;
                Tiles[newX, newY] = temp;
            }
            else if (Tiles[newX, newY] == Tiles[x, y])
            {
                int temp = Tiles[x, y];
                Tiles[x, y] = 0;
                Tiles[newX, newY] += temp;
            }
        }

        private int[] CheckMerge(int value, int[] newLocation, Direction direction)
        {
            int x = newLocation[0];
            int y = newLocation[1];
            switch (direction)
            {
                case Direction.UP:
                    if (y - 1 >= 0 && Tiles[x, y - 1] == value)
                    {
                        newLocation[0] = x;
                        newLocation[1] = y - 1;
                    }
                    break;
                case Direction.DOWN:
                    if (y + 1 < 4 && Tiles[x, y + 1] == value)
                    {
                        newLocation[0] = x;
                        newLocation[1] = y + 1;
                    }
                    break;
                case Direction.LEFT:
                    if (x - 1 >= 0 && Tiles[x - 1, y] == value)
                    {
                        newLocation[0] = x - 1;
                        newLocation[1] = y;
                    }
                    break;
                case Direction.RIGHT:
                    if (x + 1 < 4 && Tiles[x + 1, y] == value)
                    {
                        newLocation[0] = x + 1;
                        newLocation[1] = y;
                    }
                    break;
            }
            return newLocation;
        }

        private void MoveUp()
        {
            for (int y = 1; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (Tiles[x, y] == 0)
                    {
                        continue;
                    }
                    int[] newLocation = FindNewLocation(x, y, Direction.UP);
                    newLocation = CheckMerge(Tiles[x, y], newLocation, Direction.UP);
                    MoveToNewLocation(x, y, newLocation[0], newLocation[1]);
                }
            }
        }

        private void MoveDown()
        {
            for (int y = 2; y >= 0; y--)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (Tiles[x, y] == 0)
                    {
                        continue;
                    }
                    int[] newLocation = FindNewLocation(x, y, Direction.DOWN);
                    newLocation = CheckMerge(Tiles[x, y], newLocation, Direction.DOWN);
                    MoveToNewLocation(x, y, newLocation[0], newLocation[1]);
                }
            }
        }

        private void MoveLeft()
        {
            for (int x = 1; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (Tiles[x, y] == 0)
                    {
                        continue;
                    }
                    int[] newLocation = FindNewLocation(x, y, Direction.LEFT);
                    newLocation = CheckMerge(Tiles[x, y], newLocation, Direction.LEFT);
                    MoveToNewLocation(x, y, newLocation[0], newLocation[1]);
                }
            }
        }

        private void MoveRight()
        {
            for (int x = 2; x >= 0; x--)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (Tiles[x, y] == 0)
                    {
                        continue;
                    }
                    int[] newLocation = FindNewLocation(x, y, Direction.RIGHT);
                    newLocation = CheckMerge(Tiles[x, y], newLocation, Direction.RIGHT);
                    MoveToNewLocation(x, y, newLocation[0], newLocation[1]);
                }
            }
        }

        private int[] FindNewLocation(int x, int y, Direction direction)
        {
            int[] newLocation = new int[2];
            for (int i = 3; i >= 1; i--)
            {
                switch (direction)
                {
                    case Direction.UP:
                        if (y - i >= 0 && Tiles[x, y - i] == 0)
                        {
                            newLocation[0] = x;
                            newLocation[1] = y - i;
                            return newLocation;
                        }
                        break;
                    case Direction.DOWN:
                        if (y + i < 4 && Tiles[x, y + i] == 0)
                        {
                            newLocation[0] = x;
                            newLocation[1] = y + i;
                            return newLocation;
                        }
                        break;
                    case Direction.LEFT:
                        if (x - i >= 0 && Tiles[x - i, y] == 0)
                        {
                            newLocation[0] = x - i;
                            newLocation[1] = y;
                            return newLocation;
                        }
                        break;
                    case Direction.RIGHT:
                        if (x + i < 4 && Tiles[x + i, y] == 0)
                        {
                            newLocation[0] = x + i;
                            newLocation[1] = y;
                            return newLocation;
                        }
                        break;

                }
            }
            newLocation[0] = x;
            newLocation[1] = y;
            return newLocation;
        }

        private bool GameFinished()
        {
            return !CanMove(Direction.UP) && !CanMove(Direction.DOWN) && !CanMove(Direction.LEFT) && !CanMove(Direction.RIGHT);
        }

        private bool CanMove(Direction direction)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (Tiles[x, y] == 0)
                    {
                        continue;
                    }
                    switch (direction)
                    {
                        case Direction.LEFT:
                            if (x >= 1 && (Tiles[x - 1, y] == 0 || Tiles[x - 1, y] == Tiles[x, y]))
                            {
                                return true;
                            }
                            break;
                        case Direction.RIGHT:
                            if (x <= 2 && (Tiles[x + 1, y] == 0 || Tiles[x + 1, y] == Tiles[x, y]))
                            {
                                return true;
                            }
                            break;
                        case Direction.UP:
                            if (y >= 1 && (Tiles[x, y - 1] == 0 || Tiles[x, y - 1] == Tiles[x, y]))
                            {
                                return true;
                            }
                            break;
                        case Direction.DOWN:
                            if (y <= 2 && (Tiles[x, y + 1] == 0 || Tiles[x, y + 1] == Tiles[x, y]))
                            {
                                return true;
                            }
                            break;
                    }
                }
            }
            return false;
        }
    }
}
