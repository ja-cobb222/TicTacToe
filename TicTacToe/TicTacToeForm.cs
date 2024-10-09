using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
   public partial class TicTacToeForm : Form
   {
      private Button[,] buttons;      // 2D array to hold button references
      private TicTacToeGame game;     // Instance of the game logic

      public TicTacToeForm() // Constructor
      {
         InitializeComponent();    // Initialize components defined in the designer
         game = new TicTacToeGame(); // Instantiate the game logic
         InitializeBoard();        // Call to set up the game board
      }

      private void InitializeBoard() // Method to set up buttons on the board
      {
         buttons = new Button[3, 3]; // Create a 3x3 button array
         int buttonSize = 100;        // Define size of each button

         for (int row = 0; row < 3; row++)
         {
            for (int col = 0; col < 3; col++)
            {
               buttons[row, col] = new Button
               {
                  Size = new Size(buttonSize, buttonSize), // Set button size
                  Location = new Point(col * buttonSize, row * buttonSize), // Set location
                  Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold), // Set font style
               };

               // Event handler for button click
               int r = row;
               int c = col;
               buttons[row, col].Click += (sender, e) => ButtonClick(r, c);
               Controls.Add(buttons[row, col]); // Add button to form
            }
         }

         this.ClientSize = new Size(3 * buttonSize, 3 * buttonSize); // Set form size
      }

      private void ButtonClick(int row, int col)
      {
         char playerBeforeMove = game.CurrentPlayer; // Capture the current player before placing the mark
         
         if (game.PlaceMark(row, col)) // Valid move
         {
            buttons[row, col].Text = playerBeforeMove == 'X' ? "X" : "O"; // Place the mark
            buttons[row, col].Enabled = false; // Disable the button

            if (game.GameOver) // Check for game over
            {
               MessageBox.Show($"Player {game.CurrentPlayer} Wins!", "Game Over"); // Show winner
               ResetBoard(); // Reset the board for a new game
            }
         }
      }

      private void ResetBoard() // Method to reset the board
      {
         game.ResetGame(); // Reset game logic
         foreach (var button in buttons) // Iterate through buttons
         {
            button.Text = string.Empty; // Clear button text
            button.Enabled = true; // Enable button
         }
      }

      private void TicTacToeForm_Load(object sender, EventArgs e)
      {

      }
   }
}