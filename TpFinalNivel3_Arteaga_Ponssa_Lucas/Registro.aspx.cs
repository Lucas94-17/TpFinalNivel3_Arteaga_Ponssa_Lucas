using dominio;
using negocio;
using negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalNivel3_Arteaga_Ponssa_Lucas
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            
            try
            {
                Trainee user = new Trainee();
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;
                user.urlImagenPerfil = txtUrlImagen.Text;
                user.Id = traineeNegocio.insertarNuevo(user);
                Session.Add("trainee", user);              
                Response.Redirect("Default.aspx", false);
                

            }
            catch (Exception ex )
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}