using Microsoft.Maui.Controls;

namespace Pr01_SaraYueMadrugaMartin;

public partial class MainPage : ContentPage
{
    TicTacToe tictactoeplay = new TicTacToe();

    private string Player1Name;
    private string Player2Name;

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

    private async void OnCellClicked(object sender, EventArgs e)
    {
        ImageButton boton = (ImageButton)sender;

        string parametro = boton.CommandParameter.ToString();
        string[] partes = parametro.Split(',');

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
            boton.Source = "img_x.png";
        }
        else
        {
            currentPlayerName = Player2Name;
            boton.Source = "img_o.png";
        }

        boton.IsEnabled = false;

        // Comprobar el ganador.
        int winner = tictactoeplay.Ganador();

        if (winner != 0)
        {
            string winnerName;
            if (winner == 1)
                winnerName = Player1Name;
            else
                winnerName = Player2Name;

            TurnLabel.Text = $"¡Ha ganado: {winnerName}!";

            foreach (ImageButton child in TableroGrid.Children.Cast<ImageButton>())
                child.IsEnabled = false;

            await DisplayAlert("Fin de partida", $"¡Ha ganado {winnerName}!", "OK");
        }
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
}