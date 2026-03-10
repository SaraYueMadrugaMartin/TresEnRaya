using Microsoft.Maui.Controls;

namespace Pr01_SaraYueMadrugaMartin;

public partial class MainPage : ContentPage
{
    TicTacToe tictactoeplay = new TicTacToe();

    public MainPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Método que se llama cuando se pulsan los botones (casillas).
    /// </summary>
    /// <param name="objectClicked"></param>
    /// <param name="e"></param>
    private async void OnCellClicked(object objectClicked, EventArgs e)
    {
        // Pasar la info del botón en el que se ha hecho click.
        ImageButton boton = (ImageButton)objectClicked;

        string parametro = boton.CommandParameter.ToString();
        string[] partes = parametro.Split(',');

        int columna = int.Parse(partes[0]);
        int fila = int.Parse(partes[1]);

        int turno = tictactoeplay.jugada(columna, fila);

        if (turno == -1)
            return;

        // Habilitar imagen correspondiente al jugador.
        if (turno % 2 != 0)
            boton.Source = "img_x.png";
        else
            boton.Source = "img_o.png";

        boton.IsEnabled = false;

        // Comprobar el ganador.
        int winner = tictactoeplay.Ganador();

        if (winner != 0)
        {
            TurnLabel.Text = "Ha ganado el jugador: " + winner;

            foreach (ImageButton child in TableroGrid.Children.Cast<ImageButton>())
                child.IsEnabled = false;
        }
        else // Actualizar el nombre del jugador en el turno.
        {
            int currentPlayer;

            if (turno % 2 == 0)
                currentPlayer = 1;
            else
                currentPlayer = 2;

            TurnLabel.Text = $"Turno de: Jugador {currentPlayer}";
        }
    }
}