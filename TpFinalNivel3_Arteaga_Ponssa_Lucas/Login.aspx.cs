using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TpFinalNivel3_Arteaga_Ponssa_Lucas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void btnLoguearse_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio Negocio = new TraineeNegocio();
            try
            {
                //Validacion de texto vacio por backend
                if (Validacion.validaTextoVacio(txtEmail.Text) || Validacion.validaTextoVacio(txtPass.Text))
                {
                    Session.Add("error", "Debe completar ambos campos");
                    //Response.Redirect("Error.aspx", false);
                }
                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPass.Text;

                if (Negocio.Login(trainee))
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Debe completar ambos campos");
                    //Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}