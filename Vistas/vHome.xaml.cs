using dquimbitaT6.Modelo;
using Newtonsoft.Json;
using System.Collections.ObjectModel;


namespace dquimbitaT6.Vistas;

public partial class vHome : ContentPage
{
    private const string url = "http://localhost/appmovil/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> estuadientes;
    public vHome()
	{
		InitializeComponent();
        obtener();
	}
    public async void obtener()
    {
        var content = await cliente.GetStringAsync(url);
        List<Estudiante> ListEs = JsonConvert.DeserializeObject<List<Estudiante>>(content);
        estuadientes = new ObservableCollection<Estudiante>(ListEs);
        listaEstudiantes.ItemsSource = estuadientes;
    }

    private void btnIr_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vAgregar());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objestudiante = (Estudiante)e.SelectedItem;
        Navigation.PushAsync(new vActElim(objestudiante));
    }
}