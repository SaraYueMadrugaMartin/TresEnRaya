namespace Pr01_SaraYueMadrugaMartin;

public partial class InitialPage : ContentPage
{
	public InitialPage()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Metodo que se llama cuando se pulsa el botón de "Comenzar Partida".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnStartClicked(object sender, EventArgs e)
    {
        string player1 = Player1Entry.Text?.Trim();
        string player2 = Player2Entry.Text?.Trim();

        // Aviso para asegurar que los jugadores no dejen en blanco los nombres.
        if (string.IsNullOrEmpty(player1) || string.IsNullOrEmpty(player2))
        {
            await DisplayAlert("Error", "Introduce los nombres de ambos jugadores", "OK");
            return;
        }

        await Navigation.PushAsync(new MainPage(player1, player2)); // Mandamos la info de los nombres para que salga en la partida.
    }
}