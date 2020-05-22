using MySql.Data.MySqlClient;
using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace proyectofinalwebII.DAOS
{
    public class VentaDAO
    {
        public Boolean Agregar(MVentas obj)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "INSERT INTO ventas (fecha, total, Descripcion) " +
                    "VALUES('@fecha',@total,'@Descripcion');";

                sentencia.Parameters.AddWithValue("@fecha", obj.fecha);
                sentencia.Parameters.AddWithValue("@total", obj.total);
                sentencia.Parameters.AddWithValue("@Descripcion", obj.descripccion);

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


        public List<MVentas> GetAll()
        {
            List<MVentas> lista = new List<MVentas>();

            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "SELECT * FROM ventas;";

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);

                MVentas ven = new MVentas();

                foreach (DataRow fila in tabla.Rows)
                {
                    ven.id = fila["idVentas"].ToString();
                    ven.fecha = fila["fecha"].ToString();
                    ven.total = Double.Parse(fila["total"].ToString());
                    ven.descripccion = fila["descripcion"].ToString();
                    lista.Add(ven);
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

        public MVentas Getbyid(String id)
        {

            MVentas ven = new MVentas();
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "SELECT * FROM ventas where idVentas = @idVentas;";
                sentencia.Parameters.AddWithValue("@idVentas", id);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);



                foreach (DataRow fila in tabla.Rows)
                {

                    ven.id = fila["idVentas"].ToString();
                    ven.fecha = fila["fecha"].ToString();
                    ven.total = Double.Parse(fila["total"].ToString());
                    ven.descripccion = fila["descripcion"].ToString();
                    

                }

                return ven;
            }
            catch (Exception)
            {
                return ven;
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
                sentencia.CommandText = "DELETE FROM ventas WHERE idVentas =@idVentas;";
                sentencia.Parameters.AddWithValue("@idVentas", id);
                Conexion.ejecutarSentencia(sentencia, false);

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

        public Boolean Agregar_Detalles(MDetalles obj)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "INSERT INTO detalles (idVenta ,Producto ,Tipo , Cantidad,"+
                    " Total) " +
                    "VALUES(@idVenta ,@Producto ,'@Tipo' , @Cantidad, @Total);";

                sentencia.Parameters.AddWithValue("@idVenta", obj.idVenta);
                sentencia.Parameters.AddWithValue("@Producto", obj.producto);
                sentencia.Parameters.AddWithValue("@Tipo", obj.Tipo);
                sentencia.Parameters.AddWithValue("@Cantidad", obj.cantidad);
                sentencia.Parameters.AddWithValue("@Total", obj.total);


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
        public List<MDetalles> GetDetalles(String id)
        {
            List<MDetalles> lista = new List<MDetalles>();
            MDetalles det = new MDetalles();
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "SELECT * FROM detalles where idVenta = @idVenta;";
                sentencia.Parameters.AddWithValue("@idVenta", id);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);



                foreach (DataRow fila in tabla.Rows)
                {

                    det.idVenta = fila["idVentas"].ToString();
                    det.producto = fila["Producto"].ToString();
                    det.Tipo = fila["Tipo"].ToString();
                    det.cantidad =int.Parse(fila["Cantidad"].ToString());
                    det.total = double.Parse(fila["Total"].ToString());
                    lista.Add(det);
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

        public Boolean EliminarDetalles(string id)
        {
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "DELETE FROM detalles WHERE idVenta =@idVenta;";
                sentencia.Parameters.AddWithValue("@idVenta", id);
                Conexion.ejecutarSentencia(sentencia, false);

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