using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;
using negocio;

namespace negocios
{
    public class ArticuloNegocio
    {
        // Declaro la Lista

        public List<Articulo> Listar()
        {
            //Creo la Lista
            List<Articulo> lista = new List<Articulo>();
            //Creo la instancia de base de datos
            AccesodeDatos datos = new AccesodeDatos();

            try
            {
                datos.setearConsulta("  Select Codigo , Nombre , A.Precio , A.Descripcion, ImagenUrl , M.Descripcion as Marca ,C.Descripcion as Categoria , A.IdCategoria, A.IdMarca , A.Id from ARTICULOS A,CATEGORIAS C , MARCAS M  WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria");
                //datos.setearConsulta("Select Id , Codigo from Articulos");
                datos.ejecutarAccion();

                while (datos.lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.lector["Id"];
                    aux.Codigo = (string)datos.lector["Codigo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    aux.urlImage = (string)datos.lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.lector["Precio"];

                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.lector["Id"];
                    aux.Categoria.Descripcion = (string)datos.lector["Categoria"];

                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.lector["Id"];
                    aux.Marca.Descripcion = (string)datos.lector["Marca"];

                    lista.Add(aux);
                }
                datos.conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregar(Articulo articulo_Nuevo)
        {
            AccesodeDatos datos = new AccesodeDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo , Nombre , Descripcion , Precio , ImagenUrl , IdCategoria , IdMarca ) values (@Codigo , @Nombre , @Descripcion , @Precio, @ImagenUrl ,@IdCategoria,@IdMarca )");
                datos.setearParametros("@Codigo", articulo_Nuevo.Codigo);
                datos.setearParametros("@Nombre", articulo_Nuevo.Nombre);
                datos.setearParametros("@Descripcion", articulo_Nuevo.Descripcion);
                datos.setearParametros("@Precio", articulo_Nuevo.Precio);
                datos.setearParametros("@ImagenUrl", articulo_Nuevo.urlImage);
                datos.setearParametros("@IdCategoria", articulo_Nuevo.Categoria.Id);
                datos.setearParametros("@IdMarca", articulo_Nuevo.Marca.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo articulo_modificar)
        {
            AccesodeDatos datos = new AccesodeDatos();
            try
            {
                datos.setearConsulta("Update ARTICULOS set Codigo = @Codigo , Nombre = @Nombre , Descripcion = @Descripcion , ImagenUrl = @urlImage , IdCategoria = @IdCategoria , IdMarca = @IdMarca , Precio = @Precio Where Id = @id");
                datos.setearParametros("@Codigo", articulo_modificar.Codigo);
                datos.setearParametros("@Nombre", articulo_modificar.Nombre);
                datos.setearParametros("@Descripcion", articulo_modificar.Descripcion);
                datos.setearParametros("@urlImage", articulo_modificar.urlImage);
                datos.setearParametros("@IdCategoria", articulo_modificar.Categoria.Id);
                datos.setearParametros("@IdMarca", articulo_modificar.Marca.Id);
                datos.setearParametros("@Precio", articulo_modificar.Precio);
                datos.setearParametros("@Id", articulo_modificar.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int Id)
        {
            AccesodeDatos datos = new AccesodeDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where Id = @Id");
                datos.setearParametros("@Id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesodeDatos datos = new AccesodeDatos();

            try
            {
                string consulta = "Select Codigo , Nombre, A.Descripcion ,ImagenUrl, Precio , M.Descripcion  Marca, C.Descripcion Categoria, A.IdCategoria,A.IdMarca , A.Id  from ARTICULOS A , MARCAS M , CATEGORIAS C  where M.Id = A.IdMarca AND C.Id = A.IdCategoria AND ";
                Console.WriteLine(consulta);
                Console.WriteLine(filtro);
                if (campo == "Codigo")
                {
                    consulta += "Codigo = '" + filtro + "'";

                }
                else if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like'%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Descripcion")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarAccion();

                while (datos.lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.lector["Id"];
                    aux.Codigo = (string)datos.lector["Codigo"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Precio = (decimal)datos.lector["Precio"];
                    if (!(datos.lector["ImagenUrl"] is DBNull))
                        aux.urlImage = (string)datos.lector["ImagenUrl"];

                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.lector["Categoria"];

                    articulos.Add(aux);
                }
                return articulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
