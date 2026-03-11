using Microsoft.Maui.Controls;

namespace Pr01_SaraYueMadrugaMartin;

public partial class MainPage : ContentPage
{
    TicTacToe tictactoeplay = new TicTacToe();

    #region Variables Players
    private string Player1Name;
    private string Player2Name;

    private int Player1Score = 0;
    private int Player2Score = 0;
    #endregion

    public MainPage(string player1, string player2)
    {
        InitializeComponent();

        Player1Name = player1;
        Player2Name = player2;

        // Para que se vean los nombres guardados de los jugadores.
        Player1Label.Text = Player1Name;
        Player2Label.Text = Player2Name;

        // Inicia con el jugador 1.
        TurnLabel.Text = $"Turno de: {Player1Name}";
    }

    /// <summary>
    /// Metodo que se llama cuando se pulsa una de las celdas del juego.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnCellClicked(object sender, EventArgs e)
    {
        ImageButton boton = (ImageButton)sender;

        // Convertimos a string el identificador que añadimos a cada celda para poder saber cual se ha pulsado.
        string parametro = boton.CommandParameter.ToString();
        string[] partes = parametro.Split(',');

        // Lo convertirmos a enteros para luego poder asignarlo al metodo de tictactoe.
        int columna = int.Parse(partes[0]);
        int fila = int.Parse(partes[1]);

        int turno = tictactoeplay.jugada(columna, fila);

        if (turno == -1)
            return;

        // Asignar imagen segun el jugador.
        string currentPlayerName;
        if (turno % 2 != 0)
        {
            currentPlayerName = Player1Name;
            boton.Source = "img_x.jpg";
        }
        else
        {
            currentPlayerName = Player2Name;
            boton.Source = "img_o.jpg";
        }

        boton.IsEnabled = false;

        // Comprobar el ganador.
        int winner = tictactoeplay.Ganador();

        if (winner != 0)
        {
            string winnerName;
            if (winner == 1)
            {
                winnerName = Player1Name;
                Player1Score++;
                Player1Victories.Text = $"Victorias: {Player1Score}"; // Actualizar numero de victorias de Player 1.
            }
            else
            {
                winnerName = Player2Name;
                Player2Score++;
                Player2Victories.Text = $"Victorias: {Player2Score}"; // Actualizar numero de victorias de Player 2.
            }

            await Navigation.PushAsync(new ScorePage(this, winnerName, Player1Name, Player2Name, Player1Score, Player2Score));
        }

        else if (turno == 9) // Si todas las casillas se han llenado y no hay ganador, entonces hay empate.
            await Navigation.PushAsync(new ScorePage(this, "Empate", Player1Name, Player2Name, Player1Score, Player2Score));

        else
        {
            // Turno del siguiente jugador.
            string nextPlayer;
            if (turno % 2 == 0)
                nextPlayer = Player1Name;
            else
                nextPlayer = Player2Name;

            TurnLabel.Text = $"Turno de: {nextPlayer}";
        }
    }

    /// <summary>
    /// Metodo para empezar una partida nueva.
    /// </summary>
    public void NewGame()
    {
        tictactoeplay = new TicTacToe(); // Reiniciamos la logica del juego.

        foreach (var child in TableroGrid.Children) // Reseteamos el tablero.
        {
            if (child is ImageButton boton)
            {
                boton.Source = "img_button.jpg";
                boton.IsEnabled = true;
            }
        }

        TurnLabel.Text = $"Turno de: {Player1Name}"; // Reiniciamos el turno del primer jugador.
    }
}