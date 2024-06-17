using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using negocios;

namespace TpFinalNivel3_Arteaga_Ponssa_Lucas
{
    public partial class Pagina_detalle : System.Web.UI.Page
    {
        Articulo articulo = new Articulo();
        ArticuloNegocio negocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            //imgArticulo=articulo.urlImage;
            List<Articulo> lista = negocio.listar();
            Articulo seleccionado = (negocio.listar(id))[0];
            Session.Add("articuloSeleccionado",seleccionado);
            //cargar los elementos 
            imgArticulo.ImageUrl = seleccionado.urlImage.ToString();
            lblDescripcion.Text = seleccionado.Descripcion;
            lblNombre.Text = seleccionado.Nombre.ToString();
        } 
    }
}