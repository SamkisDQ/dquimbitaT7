using dquimbitaT6.Modelo;
using System.Net;

namespace dquimbitaT6.Vistas;

public partial class vActElim : ContentPage
{
	public vActElim(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text=datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            cliente.UploadValues("http://localhost/appmovil/post.php?codigo="+txtCodigo.Text+"&nombre="+txtNombre.Text+"" +
                "&apellido="+txtApellido.Text+"&edad="+txtEdad.Text, "PUT",parametros);
            Navigation.PushAsync(new vHome());

        }
        catch (Exception ex)
        {

            DisplayAlert("Alerta", ex.Message, "Cerrar");
        }

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);
            cliente.UploadValues("http://localhost/appmovil/post.php" + "?codigo=" + txtCodigo.Text, "DELETE", parametros);
            Navigation.PushAsync(new vHome());

        }
        catch (Exception ex)
        {

            DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }
}