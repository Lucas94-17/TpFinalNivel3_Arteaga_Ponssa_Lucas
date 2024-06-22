using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
namespace TpFinalNivel3_Arteaga_Ponssa_Lucas
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    
                        Validacion validacion = new Validacion();
                        Trainee trainee = (Trainee)Session["trainee"];
                        txtEmail.Text = trainee.Email;
                        txtNombre.Text = trainee.Nombre;
                        txtApellido.Text = trainee.Apellido;
                        txtPass.Text = trainee.Pass;
                        txtEmail.Text = trainee.Email;
                        txtEmail.ReadOnly = true;
                        txtImagen.Text = trainee.urlImagenPerfil;
                        txtImagen_TextChanged(sender, e);
                        //if (!string.IsNullOrEmpty(trainee.urlImagenPerfil))
                        //    imgNuevoPerfil.ImageUrl = trainee.urlImagenPerfil;
                        string imagenUrl = trainee.urlImagenPerfil;
                        if (!string.IsNullOrEmpty(imagenUrl))
                        {
                            bool isValid = validacion.IsValidImageUrl(imagenUrl);
                            if (isValid)
                            {
                                imgNuevoPerfil.ImageUrl = trainee.urlImagenPerfil;
                                imgNuevoPerfil.Visible = true;

                            }
                    }
                    else
                    {
                        imgNuevoPerfil.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr64U1qrn_mnXFwQoOmiuJs1zp0aLvApc1WmtDk-_IywS0eg7pzlSCsqDNbUzJuPSRupo&usqp=CAU";
                    }
                    
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                Trainee user = (Trainee)Session["trainee"];
                //if (txtImagen.PostedFile.FileName != "")
                //{
                //    string ruta = Server.MapPath("./Img/");
                //    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                //    user.urlImagenPerfil = "perfil-" + user.Id + ".jpg";

                //}

                user.Nombre = txtNombre.Text;
                user.Email = txtEmail.Text;
                user.Apellido = txtApellido.Text;
                user.Pass = txtPass.Text;
                user.Email = txtEmail.Text;
                user.urlImagenPerfil = txtImagen.ToString();
                traineeNegocio.actualizar(user);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imgNuevoPerfil.ImageUrl = txtImagen.Text;
        }
    }
}