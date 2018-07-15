using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Dynamic_Programming
{
    //Given a grid, find a path from the top left to the bottom right using only right and down movements.
    // Some squares are off limits and the path cannot contain them.
    public static class PathThroughGrid
    {
        public static List<Coordinate> FindPathThroughGrid(this bool[,] grid)
        {
            int height = grid.GetLength(0);
            int width = grid.GetLength(1);
            List<Coordinate> path = new List<Coordinate>();

            SearchPath(grid, height - 1, width - 1, path);

            return path;
        }

        private static bool SearchPath(bool[,] grid, int y, int x, List<Coordinate> path)
        {
            if (y < 0 || x < 0 || !grid[y, x]) return false;

            //If this grid is passable and we are at our destination or recursing from our destination
            if (y == 0 && x == 0 || SearchPath(grid, y - 1, x, path) || SearchPath(grid, y, x - 1, path))
            {
                path.Add(new Coordinate { X = x, Y = y });
                return true;
            }

            return false;
        }
    }

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
