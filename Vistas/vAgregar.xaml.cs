using System.Net;

namespace dquimbitaT6.Vistas;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre",txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://localhost/appmovil/post.php","POST",parametros);
			Navigation.PushAsync(new vHome());

        }
		catch (Exception ex)
		{

			DisplayAlert("Alerta", ex.Message, "Cerrar");
		}       
    }
}