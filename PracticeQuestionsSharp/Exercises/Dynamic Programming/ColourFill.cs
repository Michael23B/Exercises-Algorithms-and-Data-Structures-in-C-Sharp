namespace PracticeQuestionsSharp.Exercises.Dynamic_Programming
{
    //Implement a colour fill method, like you would see in a paint application.
    public static class ColourFill
    {
        //Fill each tile until you find a tile of a different colour.
        public static int[,] FillColour(this int[,] canvas, int y, int x, int fillCol)
        {
            int baseCol = canvas[y, x];
            int[,] memo = new int[canvas.GetLength(0), canvas.GetLength(1)];
            memo.Initialize();

            Fill(canvas, memo, y, x, fillCol, baseCol);

            return canvas;
        }

        private static void Fill(int[,] canvas, int[,] memo, int y, int x, int fillCol, int baseCol)
        {
            if (memo[y, x] != 0) return;
            if (canvas[y, x] != baseCol) return;

            memo[y, x] = 1;
            canvas[y, x] = fillCol;

            if (y + 1 < canvas.GetLength(0)) Fill(canvas, memo, y + 1, x, fillCol, baseCol);
            if (y - 1 >= 0) Fill(canvas, memo, y - 1, x, fillCol, baseCol);
            if (x + 1 < canvas.GetLength(1)) Fill(canvas, memo, y, x + 1, fillCol, baseCol);
            if (x - 1 >= 0) Fill(canvas, memo, y, x - 1, fillCol, baseCol);
        }
    }
}
