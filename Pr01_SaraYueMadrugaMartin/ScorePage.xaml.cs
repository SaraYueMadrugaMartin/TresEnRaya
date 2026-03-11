namespace Pr01_SaraYueMadrugaMartin;

public partial class ScorePage : ContentPage
{
    private MainPage mainPage;

    /// <summary>
    /// Constructor de la ultima pantalla de resultados.
    /// Recibe los datos necesarios para poder guardar la info de victorias de cada jugador.
    /// </summary>
    /// <param name="_mainPage"></param>
    /// <param name="_winner"></param>
    /// <param name="_player1"></param>
    /// <param name="_player2"></param>
    /// <param name="_player1Score"></param>
    /// <param name="_player2Score"></param>
    public ScorePage(MainPage _mainPage, string _winner, string _player1, string _player2, int _player1Score, int _player2Score)
	{
		InitializeComponent();

        mainPage = _mainPage;

        if (_winner == "Empate")
            WinnerLabel.Text = "Ha habido empate...";
        else
            WinnerLabel.Text = $"¡Ha ganado {_winner}!";

        Player1Score.Text = $"{_player1}: {_player1Score}";
        Player2Score.Text = $"{_player2}: {_player2Score}";
    }

    /// <summary>
    /// Metodo que se llama cuando se pulsa el boton de "NuevaPartida".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnPlayAgainClicked(object sender, EventArgs e)
    {
        mainPage.NewGame(); // Llamamos al metodo de NewGame de la clase de MainPage.

        await Navigation.PopAsync();
    }

    /// <summary>
    /// Metodo que se llama cuando se pulsa el botón de "Salir".
    /// Sale de la aplicación por completo.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnExitClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}