﻿using proyectofinalwebII.DAOS;
using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text.RegularExpressions;

namespace proyectofinalwebII.WS
{
    /// <summary>
    /// Descripción breve de WSUsuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
     [System.Web.Script.Services.ScriptService]
    public class WSUsuario : System.Web.Services.WebService
    {
        private UsuarioDAO DAO = new UsuarioDAO();

        [WebMethod(EnableSession = true)]
        public void Agregar( string nom, string primer_apellido, string segundo_apellido, string contraseña, string Correo, string Tipo)
        {
            //Aqui
            String ExpresionNom = @"[A-ZÁÉÍÓÚ][a-z]+";
            String ExpresionCor = @"[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+";
            if (Regex.IsMatch(nom,ExpresionNom) && Regex.IsMatch(primer_apellido,ExpresionNom) && Regex.IsMatch(segundo_apellido,ExpresionNom) && Regex.IsMatch(Correo,ExpresionCor)) {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                DAO.Agregar(new MUsuarios("", nom, primer_apellido, segundo_apellido, BitConverter.ToString(hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(contraseña))), Correo, Tipo));
            }
        }

        [WebMethod(EnableSession = true)]
        public List<MUsuarios> GetAll()
        {
            return DAO.GetAll();
        }

        [WebMethod(EnableSession = true)]
        public MUsuarios Getbyid(String id)
        {
            return DAO.Getbyid(id);
        }

        [WebMethod(EnableSession = true)]
        public Boolean IsUsuario(String Nombre)
        {
            return DAO.IsUsuario(Nombre);
        }

        [WebMethod(EnableSession = true)]
        public MUsuarios Getbycorreo(String correo)
        {
            return DAO.GetbyCorreo(correo);
        }

        [WebMethod]
        public Boolean Confirmar(String correo,String pw)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            if (DAO.GetbyCorreo(correo).Contraseña.Equals(BitConverter.ToString(hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(pw)))))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        [WebMethod(EnableSession = true)]
        public void Eliminar(string id)
        {
            DAO.Eliminar(id);
        }

       
    }
}
