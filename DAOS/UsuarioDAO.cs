﻿using MySql.Data.MySqlClient;
using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;

namespace proyectofinalwebII.DAOS
{
    public class UsuarioDAO
    {
        public Boolean Agregar(MUsuarios obj)
        {
            

            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "INSERT INTO usuario ( Nombre, Primer_Apellido,"+
                    " Segundo_Apellido, Contraseña, Correo, Tipo)" +
                    "('@Nombre', '@Primer_Apellido', '@Segundo_Apellido', '@Contraseña', '@Correo', '@Tipo');";

                sentencia.Parameters.AddWithValue("@Nombre", obj.Nombre);
                sentencia.Parameters.AddWithValue("@Primer_Apellido", obj.Primer_Apellido);
                sentencia.Parameters.AddWithValue("@Segundo_Apellido", obj.Segundo_Apellido);
                sentencia.Parameters.AddWithValue("@Contraseña", obj.Contraseña);
                sentencia.Parameters.AddWithValue("@Correo", obj.Correo);
                sentencia.Parameters.AddWithValue("@Tipo", obj.Tipo);

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


        public List<MUsuarios> GetAll()
        {
            List<MUsuarios> lista = new List<MUsuarios>();

            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "SELECT * FROM usuario;";

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);

                MUsuarios user = new MUsuarios();

                foreach (DataRow fila in tabla.Rows)
                {
                    user.IdUsuario = fila["IdUsuario"].ToString();
                    user.Nombre = fila["Nombre"].ToString();
                    user.Primer_Apellido = fila["Primer_Apellido"].ToString();
                    user.Segundo_Apellido= fila["Segundo_Apellido"].ToString();
                    user.Contraseña = fila["Contraseña"].ToString();
                    user.Correo = fila["Correo"].ToString();
                    user.Tipo = fila["Tipo"].ToString();

                    lista.Add(user);
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

        public MUsuarios Getbyid(String id)
        {

            MUsuarios user = new MUsuarios();
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "SELECT * FROM usuario where idUsuario = @idUsuario;";
                sentencia.Parameters.AddWithValue("@idUsuario", id);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);



                foreach (DataRow fila in tabla.Rows)
                {

                    user.IdUsuario = fila["IdUsuario"].ToString();
                    user.Nombre = fila["Nombre"].ToString();
                    user.Primer_Apellido = fila["Primer_Apellido"].ToString();
                    user.Segundo_Apellido = fila["Segundo_Apellido"].ToString();
                    user.Contraseña = fila["Contraseña"].ToString();
                    user.Correo = fila["Correo"].ToString();
                    user.Tipo = fila["Tipo"].ToString();

                }

                return user;
            }
            catch (Exception)
            {
                return user;
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public MUsuarios GetbyCorreo(String Correo)
        {
            MUsuarios user = new MUsuarios();
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "SELECT * FROM usuario where Correo = '@Correo';";
                sentencia.Parameters.AddWithValue("@Correo", Correo);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);



                foreach (DataRow fila in tabla.Rows)
                {

                    user.IdUsuario = fila["IdUsuario"].ToString();
                    user.Nombre = fila["Nombre"].ToString();
                    user.Primer_Apellido = fila["Primer_Apellido"].ToString();
                    user.Segundo_Apellido = fila["Segundo_Apellido"].ToString();
                    user.Contraseña = fila["Contraseña"].ToString();
                    user.Correo = fila["Correo"].ToString();
                    user.Tipo = fila["Tipo"].ToString();

                }

                return user;
            }
            catch (Exception)
            {
                return user;
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
                sentencia.CommandText = "DELETE FROM usuario WHERE idUsuario =@idUsuario;";
                sentencia.Parameters.AddWithValue("@idUsuario", id);
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



        public Boolean IsUsuario(String Nombre)
        {
            MUsuarios user = new MUsuarios();
            Boolean r = false;
            try
            {
                MySqlCommand sentencia = new MySqlCommand();
                sentencia.CommandText = "SELECT * FROM usuario where Nombre = '@Nombre';";
                sentencia.Parameters.AddWithValue("@Nombre", Nombre);

                DataTable tabla = Conexion.ejecutarConsulta(sentencia);

                

                foreach (DataRow fila in tabla.Rows)
                {

                    if (Nombre.Equals(fila["Nombre"].ToString()))
                    {
                        r = true;
                    }

                }
                return r;
             
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
