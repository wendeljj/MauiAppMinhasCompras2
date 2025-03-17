using MauiAppMinhasCompras2.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras2.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{
		InitializeComponent();

		lista_produtos.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {
        List<Produto> tmp = await App.Db.GetAll();

		tmp.ForEach(i => lista.Add(i));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {

		try
		{
			Navigation.PushAsync(new Views.NovoProduto());
		}
		catch (Exception ex)
		{
			DisplayAlert("Ops...", ex.Message, "OK");
		}

    }

	//Ajuda da Inteligência Artificial para otimizar a performance do APP (adiciona intervalos às buscas)
	private CancellationTokenSource token_cancelar;
	private readonly TimeSpan tempo_refresh = TimeSpan.FromMilliseconds(400);

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
		try
		{
			if (token_cancelar != null)
			{
				token_cancelar.Cancel();
			}

			token_cancelar = new CancellationTokenSource();

			try
			{
				await Task.Delay(tempo_refresh, token_cancelar.Token);

			}
            catch (TaskCanceledException)
            {
				return;
            }
            if (token_cancelar.Token.IsCancellationRequested)
			{
				return;
			}
        
            string q = e.NewTextValue;

			lista.Clear();

			List<Produto> tmp = await App.Db.Search(q);
			tmp.ForEach(i => lista.Add(i));

		} catch (Exception ex)
		{
			await DisplayAlert("Ops...", ex.Message, "OK");
		}
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
		try 
		{
			double soma = lista.Sum(i => i.Total);

			string msg = $"O Valor Total é {soma:C}";

			DisplayAlert("Total", msg, "OK");
		} catch(Exception ex)
		{
			DisplayAlert("Ops...", ex.Message, "OK");
		}
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {
		try 
		{ 

		}catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
    }
}