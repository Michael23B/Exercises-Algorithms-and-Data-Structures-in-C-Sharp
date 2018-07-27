namespace PracticeQuestionsSharp.Exercises.Searching_and_Sorting
{
    //Write a function that determines the winner of a game of Tic Tac Toe
    public static class TicTacToeWinner
    {
        //Returns 0 for no winner, 1 for X and 2 for O.
        public static int FindWinner(int[,] board)
        {
            int boardSize = board.GetLength(0);
            //Top-left has diagonal, vertical and horizontal win conditions
            if (CheckLine(board, boardSize, 0, 0, 1, 0) 
                || CheckLine(board, boardSize, 0, 0, 0, 1) 
                || CheckLine(board, boardSize, 0, 0, 1, 1)) return board[0, 0];

            //Top-Right has diagonal and vertical win conditions
            if (CheckLine(board, boardSize, 0, boardSize - 1, 1, 0)
                || CheckLine(board, boardSize, 0, boardSize - 1, 1, -1)) return board[0, boardSize - 1];

            //Excluding top-left and top-right, all other tiles on the left-most and top edges have a single win condition

            //Top edge has vertical a win condition
            for (int i = 1; i < boardSize - 1; ++i)
                if (CheckLine(board, boardSize, 0, i, 1, 0)) return board[0, i];

            //Left edge has a horizontal win condition
            for (int i = 1; i < boardSize - 1; ++i)
                if (CheckLine(board, boardSize, i, 0, 0, 1)) return board[i, 0];

            return 0;
        }

        private static bool CheckLine(int[,] board, int boardSize, int y, int x, int yDir, int xDir)
        {
            int player = board[y, x];
            if (player == 0) return false;
            y += yDir;
            x += xDir;

            while (x < boardSize && y < boardSize)
            {
                if (board[y, x] != player) return false;
                y += yDir;
                x += xDir;
            }

            return true;
        }
    }
}
