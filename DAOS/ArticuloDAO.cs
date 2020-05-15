using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Xml;

namespace proyectofinalwebII.DAOS
{
    public class ArticuloDAO
    {
        XmlDocument doc = new XmlDocument();
        string rutaXml = "C:\\Users\\cuyoc\\Desktop\\proyectofinalwebII\\XML\\Datos.xml";



        public void Agregar(string id, string nom,double costo,String Descripcion, String Tipo)
        {
            doc.Load(rutaXml);

            XmlNode Producto = Crear_Producto(id, nom,costo+"",Descripcion,Tipo);

            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(Producto, nodoRaiz.LastChild);

            doc.Save(rutaXml);

        }
        public int nId()
        {
            List<MArticulos> respuesta = new List<MArticulos>();
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Producto");
            return Lista.Count + 1;

        }

        private XmlNode Crear_Producto(string id, string nom, string costo, String Descripcion, String Tipo)
        {

            XmlNode Producto = doc.CreateElement("Producto");


            XmlElement xid = doc.CreateElement("IdProducto");
            xid.InnerText = id;
            Producto.AppendChild(xid);

            XmlElement xNombre = doc.CreateElement("Nombre");
            xNombre.InnerText = nom;
            Producto.AppendChild(xNombre);

            XmlElement xCosto = doc.CreateElement("Costo");
            xCosto.InnerText = costo;
            Producto.AppendChild(xCosto);

            XmlElement xDesc = doc.CreateElement("Descripcion");
            xDesc.InnerText = Descripcion;
            Producto.AppendChild(xDesc);


            XmlElement xTipo = doc.CreateElement("Tipo");
            xTipo.InnerText = Tipo;
            Producto.AppendChild(xTipo);

            return Producto;
        }

        public List<MArticulos> GetAll()
        {
            List<MArticulos> respuesta = new List<MArticulos>();
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Producto");

            MArticulos nProducto = new MArticulos();
            foreach (XmlNode Producto in Lista)
            {
                nProducto = new MArticulos();

                nProducto.id = Producto.SelectSingleNode("IdProducto").InnerText;
                nProducto.nombre = Producto.SelectSingleNode("Nombre").InnerText;
                nProducto.costo = Double.Parse(Producto.SelectSingleNode("Costo").InnerText);
                nProducto.descripccion = Producto.SelectSingleNode("Descripcion").InnerText;
                nProducto.tipo = Producto.SelectSingleNode("Tipo").InnerText;
                respuesta.Add(nProducto);
            }

            return respuesta;
        }

        public MArticulos Getbyid(String id)
        {
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Producto");

            MArticulos nProducto = new MArticulos();
            foreach (XmlNode Producto in Lista)
            {
                if (Producto.SelectSingleNode("IdProducto").InnerText.Equals(id))
                {
                    nProducto.id = Producto.SelectSingleNode("IdProducto").InnerText;
                    nProducto.nombre = Producto.SelectSingleNode("Nombre").InnerText;
                    nProducto.costo = Double.Parse(Producto.SelectSingleNode("Costo").InnerText);
                    nProducto.descripccion = Producto.SelectSingleNode("Descripcion").InnerText;
                    nProducto.tipo = Producto.SelectSingleNode("Tipo").InnerText;
                    break;
                }
            }

            return nProducto;
        }

       

        public void Eliminar(string id)
        {
            doc.Load(rutaXml);

            XmlNode empleados = doc.DocumentElement;

            XmlNodeList listaEmpleados = doc.SelectNodes("Datos/Producto");

            foreach (XmlNode item in listaEmpleados)
            {

                if (item.SelectSingleNode("IdProducto").InnerText == id)
                {

                    XmlNode nodoOld = item;

                    empleados.RemoveChild(nodoOld);
                }
            }

            doc.Save(rutaXml);
        }

        public void Editar(string id, string nom, double costo, String Descripcion, String Tipo)
        {

            XmlElement Productos = doc.DocumentElement;

            XmlNodeList lista = doc.SelectNodes("Datos/Producto");

            XmlNode nuevo_Producto = Crear_Producto(id, nom,costo+"",Descripcion,Tipo);

            foreach (XmlNode item in lista)
            {

                if (item.FirstChild.InnerText == id)
                {
                    XmlNode nodoOld = item;
                    Productos.ReplaceChild(nuevo_Producto, nodoOld);

                }
            }

            doc.Save(rutaXml);
        }

    }
}