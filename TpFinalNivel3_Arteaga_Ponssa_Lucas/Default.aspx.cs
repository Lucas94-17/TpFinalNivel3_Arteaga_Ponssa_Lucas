using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using negocios;

namespace TpFinalNivel3_Arteaga_Ponssa_Lucas
{
    public partial class Default : System.Web.UI.Page
    {
        // creo una lista de articulos
        public List<Articulo> ListaArticulos { get; set; }
        public void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio Articulo = new ArticuloNegocio();
            ListaArticulos = Articulo.listar();
            Articulo art = new Articulo();
            //art.urlImage.Load
            if (!IsPostBack)
            {
                Repetidor.DataSource = ListaArticulos;
                
                Repetidor.DataBind();
            }
           
        }
        protected void btnDetalle_click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            string valor = ((Button)sender).CommandArgument;
            Response.Redirect("paginaDetalle.aspx?&id="+ valor);
            
        }
    }
}