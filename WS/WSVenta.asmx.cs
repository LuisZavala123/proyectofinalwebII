using proyectofinalwebII.DAOS;
using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text.RegularExpressions;

namespace proyectofinalwebII.WS
{
    /// <summary>
    /// Descripción breve de WSVenta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WSVenta : System.Web.Services.WebService
    {


        private VentaDAO DAO = new VentaDAO();
        private static List<MDetalles> detalles = new List<MDetalles>();


        [WebMethod(EnableSession = true)]
        public void Agregar(String Total, String Descripcion)
        {

            DateTime fecha = DateTime.Today;
            String fech = fecha.Year + "-";
            if (fecha.Month.ToString().Length < 2)
            {
                fech = fech + "0" + fecha.Month + "-";
            }
            else {
                fech = fech + fecha.Month + "-";
            }
            if (fecha.Day.ToString().Length < 2)
            {
                fech = fech + "0" + fecha.Day;
            }
            else
            {
                fech = fech + fecha.Day + "";
            }
            String Expresion = @"[0-9]+[\.][0-9][0-9]?";
            //Aqui
            if (Regex.IsMatch(Total, Expresion)) { }
                DAO.Agregar(new MVentas(fech, double.Parse(Total), "", Descripcion));
                int id = DAO.lastid();
                foreach (var item in detalles)
                {
                    DAO.Agregar_Detalles(new MDetalles(id + "", item.producto, item.Tipo, item.cantidad, item.total));
                }
            }
            
        }
        [WebMethod(EnableSession = true)]
        public List<MDetalles> detalle(String producto, String Cantidad)
        {
            ArticuloDAO artdao = new ArticuloDAO();
            MArticulos art = artdao.GetbyNombre(producto);
            bool si = true;
            if (detalles.Count < 1)
            {
                detalles.Add(new MDetalles("", art.id, art.tipo, int.Parse(Cantidad), int.Parse(Cantidad) * art.costo));
            }
            else {
                foreach (var item in detalles)
                {
                    if (item.producto.Equals(art.id))
                    {
                        item.cantidad += int.Parse(Cantidad);
                        item.total += int.Parse(Cantidad) * art.costo;
                        
                    }
                    else
                    {
                        si = false;
                    }
                }
                if (!si) {
                    detalles.Add(new MDetalles("", art.id, art.tipo, int.Parse(Cantidad), int.Parse(Cantidad) * art.costo));
                }
            }
            
            return detalles;
        }

        [WebMethod(EnableSession = true)]
        public List<MVentas> GetAll()
        {
            return DAO.GetAll();
        }

        [WebMethod(EnableSession = true)]
        public List<MDetalles> GetDetalles(String id)
        {
            return DAO.GetDetalles(id);
        }
        [WebMethod]
        public List<MReporte> GetallDetalles(String fecha)
        {
            List<MReporte> lista2= new List<MReporte>();
            List<MDetalles> lista1 = DAO.GetallDetalles();
            MReporte rep = new MReporte();

            foreach (var item in DAO.GetAll())
            {
                foreach (var item2 in lista1)
                {
                    if (item.fecha.Equals(fecha)&&item.id.Equals(item2.idVenta))
                    {
                        rep.Tipo = item2.Tipo;
                        rep.Cantidad = item2.cantidad;
                        rep.Total = item2.total;

                        if (lista2.Contains(rep))
                        {
                            lista2.ElementAt(lista2.IndexOf(rep)).Total += rep.Total;
                            lista2.ElementAt(lista2.IndexOf(rep)).Cantidad += rep.Cantidad;
                        }
                        else {
                            lista2.Add(rep);
                        }
                        
                    }
                }
            }

            return lista2;
        }

        [WebMethod(EnableSession = true)]
        public MVentas Getbyid(String id)
        {
            return DAO.Getbyid(id);
        }

        [WebMethod(EnableSession = true)]
        public void Eliminar(string id)
        {
            DAO.Eliminar(id);
        }

        [WebMethod(EnableSession = true)]
        public void EliminarDetalles(string id)
        {
            DAO.EliminarDetalles(id);
        }

        [WebMethod(EnableSession = true)]
        public List<MDetalles> quitarDetalle(string id)
        {
            foreach (var item in detalles)
            {
                if (item.producto.Equals(id))
                {
                    detalles.Remove(item);
                }
            }
            return detalles;
        }
    }
}
