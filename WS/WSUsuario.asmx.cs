using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace proyectofinalwebII.WS
{
    /// <summary>
    /// Descripción breve de WSUsuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]
    public class WSUsuario : System.Web.Services.WebService
    {

        
        XmlDocument doc = new XmlDocument();
        string rutaXml = "C:\\Users\\cuyoc\\Desktop\\proyectofinalwebII\\XML\\Datos.xml";



        [WebMethod]
        public void Agregar(string id, string nom, string primer_apellido, string segundo_apellido, string contraseña, string Correo, string Tipo)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            doc.Load(rutaXml);

            XmlNode Usuario = Crear_Usuario(id, nom, primer_apellido, segundo_apellido, BitConverter.ToString(hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(contraseña))), Correo, Tipo);

            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(Usuario, nodoRaiz.LastChild);

            doc.Save(rutaXml);

        }

        [WebMethod]
        public int nId()
        {
            List<MUsuarios> respuesta = new List<MUsuarios>();
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Usuario");
            return Lista.Count + 1;

        }

        [WebMethod]
        private XmlNode Crear_Usuario(string id, string nom, string primer_apellido, string segundo_apellido, string contraseña, string Correo, string Tipo)
        {

            XmlNode Usuario = doc.CreateElement("Usuario");


            XmlElement xid = doc.CreateElement("IdUsuario");
            xid.InnerText = id;
            Usuario.AppendChild(xid);

            XmlElement xNombre = doc.CreateElement("Nombre");
            xNombre.InnerText = nom;
            Usuario.AppendChild(xNombre);

            XmlElement xPrimer_Apellido = doc.CreateElement("Primer_Apellido");
            xPrimer_Apellido.InnerText = primer_apellido;
            Usuario.AppendChild(xPrimer_Apellido);

            XmlElement xSegundo_Apellido = doc.CreateElement("Segundo_Apellido");
            xSegundo_Apellido.InnerText = segundo_apellido;
            Usuario.AppendChild(xSegundo_Apellido);

            XmlElement xContraseña = doc.CreateElement("Contraseña");
            xContraseña.InnerText = contraseña;
            Usuario.AppendChild(xContraseña);

            XmlElement xCorreo = doc.CreateElement("Correo");
            xCorreo.InnerText = Correo;
            Usuario.AppendChild(xCorreo);


            XmlElement xTipo = doc.CreateElement("Tipo");
            xTipo.InnerText = Tipo;
            Usuario.AppendChild(xTipo);

            return Usuario;
        }

        [WebMethod]
        public List<MUsuarios> GetAll()
        {
            List<MUsuarios> respuesta = new List<MUsuarios>();
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Usuario");

            MUsuarios nUsuario = new MUsuarios();
            foreach (XmlNode Usuario in Lista)
            {
                nUsuario = new MUsuarios();
                nUsuario.IdUsuario = Usuario.SelectSingleNode("IdUsuario").InnerText;
                nUsuario.Nombre = Usuario.SelectSingleNode("Nombre").InnerText;
                nUsuario.Primer_Apellido = Usuario.SelectSingleNode("Primer_Apellido").InnerText;
                nUsuario.Segundo_Apellido = Usuario.SelectSingleNode("Segundo_Apellido").InnerText;
                nUsuario.Contraseña = Usuario.SelectSingleNode("Contraseña").InnerText;
                nUsuario.Correo = Usuario.SelectSingleNode("Correo").InnerText;
                nUsuario.Tipo = Usuario.SelectSingleNode("Tipo").InnerText;
                respuesta.Add(nUsuario);
            }

            return respuesta;
        }

        [WebMethod]
        public MUsuarios Getbyid(String id)
        {
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Usuario");

            MUsuarios nUsuario = new MUsuarios();
            foreach (XmlNode Usuario in Lista)
            {
                if (Usuario.SelectSingleNode("IdUsuario").InnerText.Equals(id))
                {
                    nUsuario.IdUsuario = Usuario.SelectSingleNode("IdUsuario").InnerText;
                    nUsuario.Nombre = Usuario.SelectSingleNode("Nombre").InnerText;
                    nUsuario.Contraseña = Usuario.SelectSingleNode("Contraseña").InnerText;
                    nUsuario.Primer_Apellido = Usuario.SelectSingleNode("Primer_Apellido").InnerText;
                    nUsuario.Segundo_Apellido = Usuario.SelectSingleNode("Segundo_Apellido").InnerText;
                    nUsuario.Correo = Usuario.SelectSingleNode("Correo").InnerText;
                    nUsuario.Tipo = Usuario.SelectSingleNode("Tipo").InnerText;
                }
            }

            return nUsuario;
        }

        [WebMethod]
        public Boolean IsUsuario(String Nombre)
        {
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Usuario");
            Boolean resp = false;

            foreach (XmlNode Usuario in Lista)
            {
                if (Usuario.SelectSingleNode("Nombre").InnerText.Equals(Nombre))
                {
                    resp = true;
                }
            }

            return resp;
        }

        [WebMethod]
        public MUsuarios Getbycorreo(String correo)
        {
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Usuario");

            MUsuarios nUsuario = new MUsuarios();
            foreach (XmlNode Usuario in Lista)
            {
                if (Usuario.SelectSingleNode("Correo").InnerText.Equals(correo))
                {
                    nUsuario.IdUsuario = Usuario.SelectSingleNode("IdUsuario").InnerText;
                    nUsuario.Nombre = Usuario.SelectSingleNode("Nombre").InnerText;
                    nUsuario.Contraseña = Usuario.SelectSingleNode("Contraseña").InnerText;
                    nUsuario.Primer_Apellido = Usuario.SelectSingleNode("Primer_Apellido").InnerText;
                    nUsuario.Segundo_Apellido = Usuario.SelectSingleNode("Segundo_Apellido").InnerText;
                    nUsuario.Correo = Usuario.SelectSingleNode("Correo").InnerText;
                    nUsuario.Tipo = Usuario.SelectSingleNode("Tipo").InnerText;
                }
            }

            return nUsuario;
        }

        [WebMethod]
        public void Eliminar(string id)
        {
            doc.Load(rutaXml);

            XmlNode empleados = doc.DocumentElement;

            XmlNodeList listaEmpleados = doc.SelectNodes("Datos/Usuario");

            foreach (XmlNode item in listaEmpleados)
            {

                if (item.SelectSingleNode("IdUsuario").InnerText == id)
                {

                    XmlNode nodoOld = item;

                    empleados.RemoveChild(nodoOld);
                }
            }

            doc.Save(rutaXml);
        }

        [WebMethod]
        public void Editar(string id, string nom, string primer_apellido, string segundo_apellido, string contraseña, string Correo, string Tipo)
        {

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            XmlElement Usuarios = doc.DocumentElement;

            XmlNodeList lista = doc.SelectNodes("Datos/Usuario");

            XmlNode nuevo_Usuario = Crear_Usuario(id, nom, primer_apellido, segundo_apellido, BitConverter.ToString(hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(contraseña))), Correo, Tipo);

            foreach (XmlNode item in lista)
            {

                if (item.FirstChild.InnerText == id)
                {
                    XmlNode nodoOld = item;
                    Usuarios.ReplaceChild(nuevo_Usuario, nodoOld);

                }
            }

            doc.Save(rutaXml);
        }
    }
}
