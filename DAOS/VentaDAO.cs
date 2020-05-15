using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace proyectofinalwebII.DAOS
{
    public class VentaDAO
    {
        XmlDocument doc = new XmlDocument();
        string rutaXml = "C:\\Users\\cuyoc\\Desktop\\proyectofinalwebII\\XML\\Datos.xml";



        public void Agregar(string id, string Fecha, double Total, String Descripcion, List<MDetalles> detalles)
        {
            doc.Load(rutaXml);

            XmlNode Venta = Crear_Venta(id, Fecha, Total + "", Descripcion);

            XmlNode nodoRaiz = doc.DocumentElement;

            nodoRaiz.InsertAfter(Venta, nodoRaiz.LastChild);
            foreach (var item in detalles)
            {
                XmlNode detalle = Crear_Detalle(item.idVenta,item.producto ,item.cantidad + "", item.total+"");
                nodoRaiz.InsertAfter(detalle, nodoRaiz.LastChild);
            }

            doc.Save(rutaXml);

        }
        public int nId()
        {
            List<MArticulos> respuesta = new List<MArticulos>();
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Venta");
            return Lista.Count + 1;

        }

        private XmlNode Crear_Venta(string id, string Fecha, string Total, string Descripcion)
        {

            XmlNode Venta = doc.CreateElement("Venta");


            XmlElement xid = doc.CreateElement("IdVenta");
            xid.InnerText = id;
            Venta.AppendChild(xid);

            XmlElement xFecha = doc.CreateElement("Fecha");
            xFecha.InnerText = Fecha;
            Venta.AppendChild(xFecha);

            XmlElement xTotal = doc.CreateElement("Total");
            xTotal.InnerText = Total;
            Venta.AppendChild(xTotal);

            XmlElement xDesc = doc.CreateElement("Descripcion");
            xDesc.InnerText = Descripcion;
            Venta.AppendChild(xDesc);

            return Venta;
        }

        private XmlNode Crear_Detalle(string idVenta, string idProducto, string Cantidad, string Total)
        {

            XmlNode Detalle = doc.CreateElement("Detalle");


            XmlElement xidVenta = doc.CreateElement("IdVenta");
            xidVenta.InnerText = idVenta;
            Detalle.AppendChild(xidVenta);

            XmlElement xidProducto = doc.CreateElement("IdProducto");
            xidProducto.InnerText = idProducto;
            Detalle.AppendChild(xidProducto);

            XmlElement xCantidad = doc.CreateElement("Cantidad");
            xCantidad.InnerText = Cantidad;
            Detalle.AppendChild(xCantidad);

            XmlElement xTotal = doc.CreateElement("Total");
            xTotal.InnerText = Total;
            Detalle.AppendChild(xTotal);

            return Detalle;
        }

        public List<MVentas> GetAll()
        {
            List<MVentas> respuesta = new List<MVentas>();
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Venta");

            MVentas nVenta = new MVentas();
            foreach (XmlNode venta in Lista)
            {
                nVenta = new MVentas();

                nVenta.id = venta.SelectSingleNode("IdVenta").InnerText;
                nVenta.fecha = venta.SelectSingleNode("Fecha").InnerText;
                nVenta.total = Double.Parse(venta.SelectSingleNode("Total").InnerText);
                nVenta.descripccion = venta.SelectSingleNode("Descripcion").InnerText;
                nVenta.Detalles = GetDetalles(nVenta.id);
                respuesta.Add(nVenta);
            }

            return respuesta;
        }
        public List<MDetalles> GetDetalles(String id)
        {
            List<MDetalles> respuesta = new List<MDetalles>();
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Detalle");

            MDetalles nDestalle = new MDetalles();
            foreach (XmlNode detalle in Lista)
            {
                if (id.Equals(detalle.SelectSingleNode("IdVenta").InnerText)) { 
                nDestalle = new MDetalles();
                nDestalle.idVenta = detalle.SelectSingleNode("IdVenta").InnerText;
                nDestalle.producto = detalle.SelectSingleNode("IdProducto").InnerText;
                nDestalle.total = double.Parse(detalle.SelectSingleNode("Total").InnerText);
                nDestalle.cantidad = int.Parse(detalle.SelectSingleNode("Cantidad").InnerText);

                respuesta.Add(nDestalle);
                }
            }

            return respuesta;
        }

        public MVentas Getbyid(String id)
        {
            doc.Load(rutaXml);
            XmlNodeList Lista = doc.SelectNodes("Datos/Venta");

            MVentas nVenta = new MVentas();
            foreach (XmlNode venta in Lista)
            {
                if (venta.SelectSingleNode("IdVenta").InnerText.Equals(id))
                {
                    nVenta.id = venta.SelectSingleNode("IdVenta").InnerText;
                    nVenta.fecha = venta.SelectSingleNode("Fecha").InnerText;
                    nVenta.total = Double.Parse(venta.SelectSingleNode("Total").InnerText);
                    nVenta.descripccion = venta.SelectSingleNode("Descripcion").InnerText;
                    nVenta.Detalles = GetDetalles(nVenta.id);
                    break;
                }
            }

            return nVenta;
        }



        public void Eliminar(string id)
        {
            doc.Load(rutaXml);

            XmlNode Ventas = doc.DocumentElement;

            XmlNodeList listaVentas = doc.SelectNodes("Datos/Venta");

            foreach (XmlNode item in listaVentas)
            {

                if (item.SelectSingleNode("IdVenta").InnerText == id)
                {

                    XmlNode nodoOld = item;
                    Ventas.RemoveChild(nodoOld);
                }
            }

            doc.Save(rutaXml);
            EliminarDetalles(id);
        }
        public void EliminarDetalles(string id)
        {
            doc.Load(rutaXml);

            XmlNode Detalles = doc.DocumentElement;

            XmlNodeList listaDetalles = doc.SelectNodes("Datos/Detalle");

            foreach (XmlNode item in listaDetalles)
            {

                if (item.SelectSingleNode("IdVenta").InnerText == id)
                {

                    XmlNode nodoOld = item;
                    Detalles.RemoveChild(nodoOld);
                }
            }

            doc.Save(rutaXml);
        }

    }
}