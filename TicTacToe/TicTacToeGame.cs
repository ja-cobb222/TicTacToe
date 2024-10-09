using System;

namespace TicTacToe
{
   public class TicTacToeGame
   {
      private char[,] board;         // 2D array to represent the game board
      public char CurrentPlayer { get; private set; } // Current player ('X' or 'O')
      public bool GameOver { get; private set; } // Flag to indicate if the game is over

      public TicTacToeGame() // Constructor
      {
         ResetGame(); // Initialize the game
      }

      public void ResetGame() // Method to reset the game
      {
         board = new char[3, 3]; // Create a new 3x3 board
         CurrentPlayer = 'X'; // Set starting player
         GameOver = false; // Reset game over flag
      }

      public bool PlaceMark(int row, int col)
      {
         // Ensure indices are valid and the cell is empty
         if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == '\0')
         {
            board[row, col] = CurrentPlayer; // Place the mark

            // Check if the current player has won
            if (CheckWin())
            {
               GameOver = true; // Set game over flag
               return true;
            }

            // Switch to the next player if no win is detected
            CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
            return true; // Successful placement
         }
         return false; // Invalid move
      }

      private bool CheckWin() // Method to check for a winning condition
      {
         // Check rows, columns, and diagonals for a win
         for (int i = 0; i < 3; i++)
         {
            if ((board[i, 0] == CurrentPlayer && board[i, 1] == CurrentPlayer && board[i, 2] == CurrentPlayer) ||
                (board[0, i] == CurrentPlayer && board[1, i] == CurrentPlayer && board[2, i] == CurrentPlayer))
            {
               return true; // Win found
            }
         }
         if ((board[0, 0] == CurrentPlayer && board[1, 1] == CurrentPlayer && board[2, 2] == CurrentPlayer) ||
             (board[0, 2] == CurrentPlayer && board[1, 1] == CurrentPlayer && board[2, 0] == CurrentPlayer))
         {
            return true; // Win found
         }
         return false; // No win found
      }
   }
}