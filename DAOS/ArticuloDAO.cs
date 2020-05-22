using MySql.Data.MySqlClient;
using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Xml;

namespace proyectofinalwebII.DAOS
{
    public class ArticuloDAO
    {

        public Boolean Agregar(MArticulos obj)
        {
            // new MArticulos(Tipo,nom,costo,nId()+"",Descripcion);

            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "INSERT INTO articulos ( Tipo, Nombre, Costo, Descripccion) " +
                    "VALUES('@Tipo','@Nombre',@Costo,'@Descripccion');";

                sentencia.Parameters.AddWithValue("@Tipo", obj.tipo);
                sentencia.Parameters.AddWithValue("@Nombre", obj.nombre);
                sentencia.Parameters.AddWithValue("@Costo", obj.costo);
                sentencia.Parameters.AddWithValue("@Descripccion", obj.descripccion);

                Conexion.ejecutarSentencia(sentencia, true);

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Conexion.desconectar();
            }

        }


        public List<MArticulos> GetAll()
        {
            List<MArticulos> lista = new List<MArticulos>();

            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "SELECT * FROM articulos;";

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);

                MArticulos art = new MArticulos();

                foreach (DataRow fila in tabla.Rows)
                {
                    art.id = fila["ID"].ToString();
                    art.nombre = fila["Nombre"].ToString();
                    art.tipo = fila["Tipo"].ToString();
                    art.costo = double.Parse(fila["Costo"].ToString());
                    art.descripccion = fila["Descripccion"].ToString();
                    lista.Add(art);
                }

                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public MArticulos Getbyid(String id)
        {

            MArticulos art = new MArticulos();
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "SELECT * FROM articulos where ID = @ID;";
                sentencia.Parameters.AddWithValue("@ID", id);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);



                foreach (DataRow fila in tabla.Rows)
                {

                    art.id = fila["ID"].ToString();
                    art.nombre = fila["Nombre"].ToString();
                    art.tipo = fila["Tipo"].ToString();
                    art.costo = double.Parse(fila["Costo"].ToString());
                    art.descripccion = fila["Descripccion"].ToString();

                }

                return art;
            }
            catch (Exception)
            {
                return art;
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public MArticulos GetbyNombre(String Nombre)
        {
            MArticulos art = new MArticulos();
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "SELECT * FROM articulos where Nombre = '@Nombre';";
                sentencia.Parameters.AddWithValue("@Nombre", Nombre);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);



                foreach (DataRow fila in tabla.Rows)
                {

                    art.id = fila["ID"].ToString();
                    art.nombre = fila["Nombre"].ToString();
                    art.tipo = fila["Tipo"].ToString();
                    art.costo = double.Parse(fila["Costo"].ToString());
                    art.descripccion = fila["Descripccion"].ToString();

                }

                return art;
            }
            catch (Exception)
            {
                return art;
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public List<String> GetNombres()
        {
            List<String> lista = new List<String>();

            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "SELECT Nombre FROM articulos;";

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);

                MArticulos art = new MArticulos();

                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(fila["Nombre"].ToString());
                }

                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
            finally
            {
                Conexion.desconectar();
            }
        }


        public Boolean Eliminar(string id)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "DELETE FROM articulos WHERE ID =@ID;";
                sentencia.Parameters.AddWithValue("@ID", id);
                Conexion.ejecutarSentencia(sentencia,false);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Conexion.desconectar();
            }

        }
    }
}